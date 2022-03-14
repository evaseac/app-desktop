# DB.cs
This class is where all the MySQL Database Connection is implemented, so it is really IMPORTANT to create it when you want to deploy. Otherwise you won't be able to perform all the tasks Database-related

## Code
The code has the following structure
```C#
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;
using System;

namespace Evaseac
{
    public class DB
    {
        private static MySqlConnection connection;
        private readonly string IP = "#.#.#.#";

        public DB()
        {
            string server = IP;
            string database = "evaseacdb";
            string port = "#";
            string uid = "••••••";
            string pwd = "••••••";

            string connectionString = "Server=" + server + ";Port=" + port + ";Database=" + database + ";Uid=" + uid + ";Pwd=" + pwd + ";";

            connection = new MySqlConnection(connectionString);
        }

        public static bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("No se puede conectar al servidor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 1045:
                        MessageBox.Show("Usuario o contraseña errónea", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                
                Environment.Exit(1);
                return false;
            }
        }

        public static bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static void Insert(string query)
        {
            try
            {
                if (OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    //MessageBox.Show("La operación se ha realizado con exito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CloseConnection();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static DataTable Table(string query)
        {
            MySqlDataAdapter Adapter = new MySqlDataAdapter();
            DataTable dtTable = new DataTable();
            try
            {
                //Abre la conexion.
                if (OpenConnection() == true)
                {
                    dtTable.Clear();
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    Adapter.SelectCommand = cmd;
                    Adapter.Fill(dtTable);

                    //Se ejecuta el quuery
                    cmd.ExecuteNonQuery();


                    //Se cierra la conexion
                    CloseConnection();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtTable;
        }

        public static DataTable Select(string query)
        {
            MySqlDataAdapter Adapter = new MySqlDataAdapter();
            DataTable dtTable = new DataTable();

            try
            {
                //Abre la conexion.
                if (OpenConnection() == true)
                {
                    dtTable.Clear();

                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    Adapter.SelectCommand = cmd;
                    Adapter.Fill(dtTable);


                    //Se ejecuta el query
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //Se cierra la conexion
                CloseConnection();
            }
            return dtTable;
        }
        
        public static string GetID(string table, object name)
        {
            return Select("SELECT ID FROM " + table + " WHERE nombre = '" + name.ToString() + "'").Rows[0][0].ToString();
        }

        public static string GetID(string table, string column, string value)
        {
            //int val;
            if (int.TryParse(value, out int val))
                return Select("SELECT ID FROM " + table + " WHERE " + column + " = " + value).Rows[0][0].ToString();
            else
                return Select("SELECT ID FROM " + table + " WHERE " + column + " = '" + value + "'").Rows[0][0].ToString();
        }

        public static void FillCombobox(string column, string table, ComboBox cbo)
        {
            cbo.Items.Clear();
            DataTable dtSelect = DB.Select("SELECT " + column + " FROM " + table);
            for (int i = 0; i < dtSelect.Rows.Count; i++)
                cbo.Items.AddRange(new object[] { dtSelect.Rows[i][0] });
        }
        public static void FillCombobox(string column, string table, string orderby, ComboBox cbo)
        {
            cbo.Items.Clear();
            DataTable dtSelect = DB.Select("SELECT " + column + " FROM " + table + " ORDER BY " + orderby);
            for (int i = 0; i < dtSelect.Rows.Count; i++)
                cbo.Items.AddRange(new object[] { dtSelect.Rows[i][0] });
        }

        public static void InsertDefaultTaxons()
        {
            int i;

            //Clases
            string[] cls = {"('Arachnida')", "('Bivalvia')", "('Clitellata')", "('Entognatha')", "('Gasteropoda')", "('Nematomorpha')", "('Insecta')",
            "('Malacostraca')", "('Ostracoda')", "('Rhabditophora')"}; //Falta Gordioidea
            for (i = 0; i < cls.Length; i++)
                Insert("INSERT INTO Clase (Nombre) VALUES " + cls[i]);

            //Orden
            string c1 = GetID("Clase", "Arachnida");
            string c2 = GetID("Clase", "Bivalvia");
            string c3 = GetID("Clase", "Clitellata");
            string c4 = GetID("Clase", "Entognatha");
            string c5 = GetID("Clase", "Gasteropoda");
            string c6 = GetID("Clase", "Nematomorpha");
            string c7 = GetID("Clase", "Insecta");
            string c8 = GetID("Clase", "Malacostraca");
            string c9 = GetID("Clase", "Ostracoda");
            string c10 = GetID("Clase", "Rhabditophora");
            string[] ord = {"('no identificado', " + c1 + ")", "('Veneroida', " + c2 + ")","('Poduromorpha', " + c4 + ")", "('no identificado', " + c3 + ")",
                "('Basommatophora', " + c5 + ")","('Neotaenioglossa', " + c5 + ")","('Gordioidea', " + c6 + ")","('Blattodea', " + c7 + ")",
                "('Coleoptera', " + c7 + ")","('Diptera', " + c7 + ")","('Ephemeroptera', " + c7 + ")","('Hemiptera', " + c7 + ")","('Lepidoptera', " + c7 + ")",
                "('Megaloptera', " + c7 + ")", "('Odonata', " + c7 + ")","('Orthoptera', " + c7 + ")","('Plecoptera', " + c7 + ")","('Trichoptera', " + c7 + ")",
                "('Amphipoda', " + c8 + ")","('Decapoda', " + c8 + ")","('Podocopida', " + c9 + ")", "('Neoophora', " + c10 + ")"};
            for (i = 0; i < ord.Length; i++)
                Insert("INSERT INTO Orden (Nombre, IdClase) VALUES " + ord[i]);

            //Familia
            string o1 = Select("SELECT ID FROM Orden WHERE Nombre = 'no identificado' AND IdClase = " + GetID("Clase", "Arachnida")).Rows[0][0].ToString();
            string o2 = GetID("Orden", "Veneroida");
            string o3 = GetID("Orden", "Poduromorpha");
            string o4 = Select("SELECT ID FROM Orden WHERE Nombre = 'no identificado' AND IdClase = " + GetID("Clase", "Clitellata")).Rows[0][0].ToString();
            string o5 = GetID("Orden", "Basommatophora");
            string o6 = GetID("Orden", "Neotaenioglossa");
            string o7 = GetID("Orden", "Gordioidea");
            string o8 = GetID("Orden", "Blattodea");
            string o9 = GetID("Orden", "Coleoptera");
            string o10 = GetID("Orden", "Diptera");
            string o11 = GetID("Orden", "Ephemeroptera");
            string o12 = GetID("Orden", "Hemiptera");
            string o13 = GetID("Orden", "Lepidoptera");
            string o14 = GetID("Orden", "Megaloptera");
            string o15 = GetID("Orden", "Odonata");
            string o16 = GetID("Orden", "Orthoptera");
            string o17 = GetID("Orden", "Plecoptera");
            string o18 = GetID("Orden", "Trichoptera");
            string o19 = GetID("Orden", "Amphipoda");
            string o20 = GetID("Orden", "Decapoda");
            string o21 = GetID("Orden", "Podocopida");
            string o22 = GetID("Orden", "Neoophora");
            string[] fam = { "('Acari', " + o1 + ")","('Corbiculidae', " + o2 + ")","('Sphaeriidae', " + o2 + ")","('Hirudinea', " + o4 + ")",
                "('Oligochaeta', " + o4 + ")","('Hypogastruridae', " + o3 + ")","('Ancylidae', " + o5 + ")","('Physidae', " + o5 + ")","('Planorbidae', " + o5 + ")",
                "('Hydrobiidae', " + o6 + ")","('Thiaridae', " + o6 + ")","('Gordiidae', " + o7 + ")","('Blaberidae', " + o8 + ")","('Carabidae', " + o9 + ")",
                "('Curculionidae', " + o9 + ")","('Dryopidae', " + o9 + ")","('Dytiscidae', " + o9 + ")","('Elmidae', " + o9 + ")","('Georyssidae', " + o9 + ")",
                "('Gyrinidae', " + o9 + ")","('Haliplidae', " + o9 + ")","('Hydraenidae', " + o9 + ")","('Hydrophilidae', " + o9 + ")","('Lampyridae', " + o9 + ")",
                "('Lutrochidae', " + o9 + ")","('Melyridae ', " + o9 + ")","('Noteridae', " + o9 + ")","('Psephenidae', " + o9 + ")","('Ptilodactylidae', " + o9 + ")",
                "('Scirtidae', " + o9 + ")","('Staphylinidae', " + o9 + ")","('Blephariceridae ', " + o10 + ")","('Ceratopogonidae', " + o10 + ")",
                "('Chironomidae', " + o10 + ")","('Culicidae', " + o10 + ")","('Dixidae', " + o10 + ")","('Dolichopodidae', " + o10 + ")","('Empididae', " + o10 + ")",
                "('Ephydridae', " + o10 + ")","('Phoridae', " + o10 + ")","('Psychodidae', " + o10 + ")","('Scathophagidae', " + o10 + ")","('Simuliidae', " + o10 + ")",
                "('Stratiomyidae', " + o10 + ")","('Tabanidae', " + o10 + ")","('Tipulidae', " + o10 + ")","('Baetidae', " + o11 + ")","('Caenidae', " + o11 + ")",
                "('Heptageniidae', " + o11 + ")","('Leptohyphidae', " + o11 + ")","('Leptophlebiidae', " + o11 + ")","('Siphlonuridae', " + o11 + ")",
                "('Aphididae', " + o12 + ")","('Belostomatidae', " + o12 + ")","('Cicadellidae', " + o12 + ")","('Corixidae', " + o12 + ")","('Gerridae', " + o12 + ")",
                "('Hebridae', " + o12 + ")","('Hydrometridae', " + o12 + ")","('Macrovellidae', " + o12 + ")","('Mesoveliidae', " + o12 + ")","('Naucoridae', " + o12 + ")",
                "('Nepidae', " + o12 + ")","('Notonectidae', " + o12 + ")","('Octheridae', " + o12 + ")","('Saldidae', " + o12 + ")","('Veliidae', " + o12 + ")",
                "('Crambidae', " + o13 + ")","('Pyralidae', " + o13 + ")","('Noctuidae', " + o13 + ")","('Corydalidae', " + o14 + ")","('Sialidae', " + o14 + ")",
                "('Aeshnidae', " + o15 + ")","('Calopterygidae', " + o15 + ")","('Coenagrionidae', " + o15 + ")","('Corduliidae', " + o15 + ")","('Gomphidae', " + o15 + ")",
                "('Lestidae', " + o15 + ")","('Libellulidae', " + o15 + ")","('Macromiidae', " + o15 + ")","('Platystictidae', " + o15 + ")","('Tridactylidae', " + o16 + ")",
                "('Nemouridae', " + o17 + ")","('Perlidae', " + o17 + ")","('Calamoceratidae', " + o18 + ")","('Glossosomatidae', " + o18 + ")","('Helicopsychidae', " + o18 + ")",
                "('Hydrobiosidae', " + o18 + ")","('Hydropsychidae', " + o18 + ")","('Hydroptilidae', " + o18 + ")","('Leptoceridae', " + o18 + ")","('Odontoceridae', " + o18 + ")",
                "('Philopotamidae', " + o18 + ")","('Phryganeidae', " + o18 + ")","('Polycentropodidae', " + o18 + ")","('Gammaridae', " + o19 + ")","('Hyalellidae', " + o19 + ")",
                "('Atyidae', " + o20 + ")","('Cambaridae', " + o20 + ")","('Palaemonidae', " + o20 + ")","('Notodromadidae', " + o21 + ")","('Planariidae', " + o22 + ")"};
            for (i = 0; i < fam.Length; i++)
                Insert("INSERT INTO Familia (Nombre, IdOrden) VALUES " + fam[i]);

        }

        public static string getData(string column, string table, string condition)
        {
            try
            {
                return Select("SELECT " + column + " FROM " + table + " " + condition).Rows[0][0].ToString();
            }
            catch 
            {
                return null;
            }
        }

        public static bool AlreadyExists(string column, string table, string value)
        {
            if (DB.Select("SELECT * FROM " + table + " WHERE " + column + " = '" + value + "'").Rows.Count > 0)
                return true;

            return false;
        }
    
        public static string GetSqlValue(string value)
        {
            if (String.IsNullOrEmpty(value))
                return "NULL";
            if (!double.TryParse(value, out double res))
            {
                // if it is a string
                if (!value.Contains("12:00:00"))
                    return "'" + value + "'";

                // Converting to SQL datetime format
                string date = DateTime.Parse(value.Split()[0]).ToString("yyyy'-'MM'-'dd");
                string time = "00:00:00";
                return "'" + date + " " + time + "'";
            }

            return value;
        }
    }
}
```