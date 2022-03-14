using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading;
using System.Web;
using System.Windows.Forms;

namespace Evaseac.User.Google_Drive
{
    public static class APIv3
    {
        public static string RootName = "Raiz (root)";

        private static string[] Scopes = { DriveService.Scope.Drive };
        private static string ApplicationName = "Evaseac";

        /// <summary>
        /// Gets the service for Google Drive for current account logged in
        /// </summary>
        /// <returns>A DriveService service</returns>
        private static DriveService GetService()
        {
            try
            {
                UserCredential credential = null;

                using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
                {
                    // The file token.json stores the user's access and refresh tokens, and is created
                    // automatically when the authorization flow completes for the first time.
                    string credPath = "token.json";
                    // Temporary solution for timeout authorization
                    Thread thread = new Thread(() =>
                    {
                        credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                    })
                    { IsBackground = true };

                    thread.Start();
                    if (!thread.Join(3000))
                    {
                        Validation.ControlValidation.ShowInformationMessage("Complete la autenticación de Google en el navegador web, con la cuenta donde se obtuvo las credenciales.\n\nSi no se completa esta acción, la aplicación continuará pidiendo la autenticación y hasta no hacerla de manera correcta, no se podrán usar los servicios de Google Drive");
                        return null;
                    }
                }

                // Create Drive API service.
                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });

                return service;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la requisición del servicio de Google Drive APIv3\n\nException: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Verifies if the Google Drive Service is up
        /// </summary>
        /// <returns><code>true</code> when the service is up<code>false</code>otherwise</returns>
        public static bool VerifyService() =>
            true ? GetService() != null : false;

        // Managing files methods

        /// <summary>
        /// Uploads a file in a specific folder within Google Drive
        /// </summary>
        /// <param name="filePath">Path of the file to be uploaded</param>
        /// <param name="folderID">ID of the folder in which the file will be uploaded</param>
        /// <returns>Id of the uploaded file</returns>
        public static string Upload(string filePath, string folderID)
        {
            try
            {
                FilesResource.CreateMediaUpload request;

                var body = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = Path.GetFileName(filePath),
                    MimeType = MimeMapping.GetMimeMapping(filePath),
                    Parents = new List<string>
                    {
                        folderID
                    }
                };

                using (var stream = new System.IO.FileStream(filePath, System.IO.FileMode.Open))
                {
                    request = GetService().Files.Create(body, stream, body.MimeType);
                    request.Fields = "id";
                    request.Upload();
                }

                MessageBox.Show("Archivo subido correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return request.ResponseBody.Id;
            }
            catch (NullReferenceException nre)
            {
                MessageBox.Show("Error en la creación y subida del archivo\n\nNullReferenceException: " + nre.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la creación y subida del archivo\n\nException: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        /// <summary>
        /// Uploads a file in a specific folder within Google Drive, and if shared=true, shares it
        /// </summary>
        /// <param name="filePath">Path of the file to be uploaded</param>
        /// <param name="folderID">ID of the folder in which the file will be uploaded</param>
        /// <param name="shared">Indicates if the file will be shared or not</param>
        /// <returns>Sharable link of the uploaded file or Id of the uploaded file</returns>
        public static string Upload(string filePath, string folderID, bool shared)
        {
            string fileId = Upload(filePath, folderID);

            if (!shared)
                return fileId;

            return ShareFile(fileId);
        }

        /// <summary>
        /// Share any file in Google Drive via its Id
        /// </summary>
        /// <param name="fileId">ID of the file to be shared</param>
        /// <returns>The sharable link</returns>
        public static string ShareFile(string fileId)
        {
            // Getting sharable link
            var service = GetService();
            try
            {
                // Creating permission
                var permission = new Google.Apis.Drive.v3.Data.Permission
                {
                    Type = "anyone",
                    Role = "reader"
                };

                service.Permissions.Create(permission, fileId).Execute();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la creación del permiso para compartir el archivo\n\nException: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            // Actually getting the link
            try
            {
                var file = service.Files.Get(fileId);
                file.Fields = "webViewLink";
                file.SupportsAllDrives = true;

                var result = file.Execute();

                return result.WebViewLink;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la obtención del link para compartir\n(El archivo está en la nube, sus permisos para compartir fueron creados, pero no se ha podido obtener el link para compartir)\n\nException: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Get all files of Google Drive (It has a limit)
        /// </summary>
        /// <returns>All files included folders</returns>
        public static DataTable GetFiles()
        {
            DataTable dtFiles = new DataTable();
            var service = GetService();

            // Define parameters of request.
            FilesResource.ListRequest listRequest = service.Files.List();
            listRequest.Fields = "nextPageToken, files(id, name, size, createdTime, parents)";

            // List files.
            IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute().Files;
            if (files != null && files.Count > 0)
            {
                dtFiles.Columns.Add("id");
                dtFiles.Columns.Add("name");
                dtFiles.Columns.Add("size");
                dtFiles.Columns.Add("type");
                dtFiles.Columns.Add("createdTime");
                dtFiles.Columns.Add("parents");

                foreach (var file in files)
                {
                    DataRow drFile = dtFiles.NewRow();
                    drFile["id"] = file.Id;
                    drFile["name"] = file.Name;
                    drFile["size"] = file.Size;
                    if (file.Size.ToString() == string.Empty)
                        drFile["type"] = "Folder";
                    else
                        drFile["type"] = "File";
                    drFile["createdTime"] = file.CreatedTime;
                    drFile["parents"] = file.Parents[0].ToString();

                    dtFiles.Rows.Add(drFile);
                }
            }
            else
            {
                MessageBox.Show("No se encontraron archivos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dtFiles;
        }

        /// <summary>
        /// Get just folders within another folder
        /// </summary>
        /// <param name="folderId">ID of the parent folder</param>
        /// <returns>All folders contained in the parent folder</returns>
        public static DataTable GetFoldersInFolder(string folderId)
        {
            DataTable dtFolders = new DataTable();
            var service = GetService();

            // Define parameters of request.
            FilesResource.ListRequest listRequest = service.Files.List();
            listRequest.Q = "mimeType = 'application/vnd.google-apps.folder' and '" + folderId + "' in parents";
            listRequest.Fields = "nextPageToken, files(id, name, parents)";

            // List files.
            IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute().Files;
            //MessageBox.Show("Files:");
            if (files != null && files.Count > 0)
            {
                dtFolders.Columns.Add("id");
                dtFolders.Columns.Add("name");

                foreach (var file in files)
                {
                    // Retrieving folders within folder (folderId)
                    DataRow drFolders = dtFolders.NewRow();

                    drFolders["id"] = file.Id;
                    drFolders["name"] = file.Name;

                    dtFolders.Rows.Add(drFolders);
                }
            }

            return dtFolders;
        }

        /// <summary>
        /// Gets files in a folder via Folder Id
        /// </summary>
        /// <param name="folderId">ID of the parent folder</param>
        /// <returns>All files contained in the parent folder</returns>
        public static DataTable GetFilesInFolder(string folderId)
        {
            DataTable dtFiles = new DataTable();
            var service = GetService();

            // Define parameters of request.
            FilesResource.ListRequest listRequest = service.Files.List();
            listRequest.Q = "mimeType != 'application/vnd.google-apps.folder' and '" + folderId + "' in parents";
            listRequest.Fields = "nextPageToken, files(id, name)";

            // List files.
            IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute().Files;
            //MessageBox.Show("Files:");
            if (files != null && files.Count > 0)
            {
                dtFiles.Columns.Add("id");
                dtFiles.Columns.Add("name");

                foreach (var file in files)
                {
                    // Retrieving folders within folder (folderId)
                    DataRow drFiles = dtFiles.NewRow();

                    drFiles["id"] = file.Id;
                    drFiles["name"] = file.Name;

                    dtFiles.Rows.Add(drFiles);
                }
            }

            return dtFiles;
        }

        /// <summary>
        /// Get a folder ID
        /// </summary>
        /// <returns>Without parameters, it returns the root folder ID</returns>
        public static string GetFolderId()
        {
            try
            {
                var request = GetService().Files.Get("root");
                request.Fields = "id";
                return request.Execute().Id;
            }
            catch
            {
                throw new Exception("Cannot connect to Google Drive service");
            }
        }

        /// <summary>
        /// Get a folder ID through its name
        /// </summary>
        /// <param name="folderName">The name of the folder that it is its ID wanted</param>
        /// <returns>The first folder ID with the given name</returns>
        public static string GetFolderId(string folderName)
        {
            var request = GetService().Files.List();
            request.Q = "mimeType = 'application/vnd.google-apps.folder' and name = '" + folderName + "'";
            request.Fields = "nextPageToken, files(id)";

            var files = request.Execute().Files;
            if (files != null && files.Count > 0)
                return files[0].Id;

            return null;
        }

        /// <summary>
        /// Get a folder ID through its name and its parent
        /// </summary>
        /// <param name="folderName">The name of the folder that it is its ID wanted</param>
        /// <param name="parentId">The ID of the parent folder</param>
        /// <returns>The first folder found, it may misbehave if there is another parent folder with a same name and no folder child as wanted</returns>
        public static string GetFolderId(string folderName, string parentId)
        {
            var request = GetService().Files.List();
            request.Q = "mimeType = 'application/vnd.google-apps.folder' and name = '" + folderName + "' and '" + parentId + "' in parents";
            request.Fields = "nextPageToken, files(id)";

            var files = request.Execute().Files;
            if (files != null && files.Count > 0)
                return files[0].Id;

            return null;
        }

        /// <summary>
        /// Get a file ID through its name
        /// </summary>
        /// <param name="fileName">Name of the file to be searched</param>
        /// <returns>The Id of the first ocurrance according to GD API v3</returns>
        public static string GetFileId(string fileName)
        {
            var request = GetService().Files.List();
            request.Q = "mimeType != 'application/vnd.google-apps.folder' and name = '" + fileName + "'";
            request.Fields = "nextPageToken, files(id)";

            var files = request.Execute().Files;
            if (files != null && files.Count > 0)
                return files[0].Id;

            return null;
        }

        /// <summary>
        /// Gets Google Drive directories (just folders) nodes
        /// </summary>
        /// <param name="folderName">Name of parent folder</param>
        /// <param name="folderId">Id of parent folder</param>
        /// <returns>A TreeNode that can be used in TreeView</returns>
        public static TreeNode GetDriveDirectoryNode(string folderName, string folderId)
        {
            TreeNode directoryNode;
            if (folderName == null)
                directoryNode = new TreeNode(RootName);
            else
                directoryNode = new TreeNode(folderName);

            foreach (DataRow row in GetFoldersInFolder(folderId).Rows)
            {
                string name = row["name"].ToString();
                directoryNode.Nodes.Add(GetDriveDirectoryNode(name, GetFolderId(name, folderId)));
            }

            return directoryNode;
        }

        /// <summary>
        /// Gets Google Drive files directory nodes
        /// </summary>
        /// <param name="fileName">Name of parent file</param>
        /// <param name="folderId">Id of parent folder</param>
        /// <returns>A TreeNode that can be used in TreeView</returns>
        public static TreeNode GetDriveFilesNode(string fileName, string folderId)
        {
            TreeNode filesNode;
            if (fileName == null)
                filesNode = new TreeNode(RootName);
            else
                filesNode = new TreeNode(fileName);

            foreach (DataRow folder in GetFoldersInFolder(folderId).Rows)
            {
                string name = folder["name"].ToString();
                filesNode.Nodes.Add(GetDriveFilesNode(name, GetFolderId(name, folderId)));
            }
            foreach (DataRow file in GetFilesInFolder(folderId).Rows)
            {
                filesNode.Nodes.Add(new TreeNode(file["name"].ToString()));
            }

            return filesNode;
        }
    }
}
