using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Evaseac
{
    public partial class frmExport : Form
    {
        private string idTmpsPrsRng = "", idTmpsMcrsRng = "", idTmpsTstsRng = "";

        private List<string> idPrms = new List<string>();
        private List<string> idMcrs = new List<string>();
        private List<string> idTsts = new List<string>();

        private List<string> lsTitle = new List<string>();
        private List<string> lsQuery = new List<string>();

        public frmExport()
        {
            InitializeComponent();
            idTemps = new List<string>();
        }

        public List<string> idTemps { get; set; }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (chkOtherTsts.Checked || chkRawPrms.Checked || chkCalculatedPrms.Checked || chkMacro.Checked)
            {
                int i, j, k;
                var xlApp = new Excel.Application();

                lblProgress.Text = "Creando excel";

                if (xlApp == null) //Verifying if excel is installed properly
                {
                    lblProgress.Text = "";
                    MessageBox.Show("Excel no esta bien instalado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //Workbook and worksheets
                object misValue = System.Reflection.Missing.Value;
                Excel.Workbook Workbook = xlApp.Workbooks.Add(misValue);
                Excel.Worksheet[] xlWorkSheets = new Excel.Worksheet[lsQuery.Count];
                lblProgress.Text = "Creando hojas de trabajo";
                for (i = 0; i < xlWorkSheets.Length; i++)
                {
                    if (i == 0)
                        xlWorkSheets[i] = (Excel.Worksheet)Workbook.Worksheets.get_Item(1);
                    else
                        xlWorkSheets[i] = Workbook.Sheets.Add(After: Workbook.Sheets[Workbook.Sheets.Count]);

                    xlWorkSheets[i].Name = lsTitle[i];
                }

                //Data
                Excel.Range cell = xlWorkSheets[0].UsedRange;

                for (i = 0; i < xlWorkSheets.Length; i++)
                {
                    lblProgress.Text = "Creando " + lsTitle[i] + "(" + i + "/" + (xlWorkSheets.Length - 1) + ")";
                    DataTable xData = DB.Select(lsQuery[i]);

                    //Headers
                    xlWorkSheets[i].Range[xlWorkSheets[i].Cells[1, 1], xlWorkSheets[i].Cells[1, xData.Columns.Count]].Style.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    for (j = 0; j < xData.Columns.Count; j++)
                    {
                        DataColumn col = xData.Columns[j];
                        xlWorkSheets[i].Cells[1, j + 1] = col.ColumnName;
                        cell = xlWorkSheets[i].UsedRange.Cells[1, j + 1];

                        lblProgress.Text = "Creando " + lsTitle[i] + "(" + i + "/" + (xlWorkSheets.Length - 1) + ") - Columna:" + col.ColumnName;
                    }

                    //Data (Cells)
                    for (j = 0; j < xData.Rows.Count; j++)
                        for (k = 0; k < xData.Columns.Count; k++)
                        {
                            xlWorkSheets[i].Cells[2 + j, k + 1] = xData.Rows[j][k].ToString();
                            cell = xlWorkSheets[i].UsedRange.Cells[2 + j, k + 1];

                            lblProgress.Text = "Creando " + lsTitle[i] + "(" + i + "/" + (xlWorkSheets.Length - 1) + ") - Celda:" + xData.Rows[j][k];
                        }

                    lblProgress.Text = "Finalizado " + lsTitle[i] + "(" + i + "/" + (xlWorkSheets.Length - 1) + ")";
                }

                //Saving file
                lblProgress.Text = "Guardando archivo";
                var desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Getting desktop route
                string file = desktopFolder + "\\" + txtFileName.Text + ".xlsx";
                Workbook.SaveAs(file, Excel.XlFileFormat.xlOpenXMLWorkbook, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

                //Closing
                lblProgress.Text = "Finalizando";
                Workbook.Close(true, misValue, misValue);
                xlApp.Quit();

                for (i = 0; i < xlWorkSheets.Length; i++)
                    Marshal.ReleaseComObject(xlWorkSheets[i]);
                Marshal.ReleaseComObject(Workbook);
                Marshal.ReleaseComObject(xlApp);

                lblProgress.Text = "";
            }
        }

        private void frmExport_Load(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i < idTemps.Count; i++)
            {
                if (i < idTemps.Count - 1)
                    //Getting sites' names
                    lblSites.Text += " " + DB.Select("SELECT Nombre FROM Sitio WHERE ID = " + DB.Select("SELECT IdSitio FROM Temporada WHERE ID = " + idTemps[i]).Rows[0][0] + "").Rows[0][0].ToString() + ",";
                else
                    lblSites.Text += " " + DB.Select("SELECT Nombre FROM Sitio WHERE ID = " + DB.Select("SELECT IdSitio FROM Temporada WHERE ID = " + idTemps[i]).Rows[0][0] + "").Rows[0][0].ToString();
                //Getting available
                if (DB.Select("SELECT OD FROM Parametros WHERE IdTemporada = " + idTemps[i]).Rows.Count != 0)
                    idPrms.Add(idTemps[i]);
                if (DB.Select("SELECT Numero FROM FamiliasSitios WHERE IdTemporada = " + idTemps[i]).Rows.Count != 0)
                    idMcrs.Add(idTemps[i]);
                if (DB.Select("SELECT Valor FROM ParametrosPSitios WHERE IdTemporada = " + idTemps[i]).Rows.Count != 0)
                    idTsts.Add(idTemps[i]);
            }
            //Setting available
            for (i = 0; i < idPrms.Count; i++)
                if (i < idPrms.Count - 1)
                {
                    idTmpsPrsRng += " " + idPrms[i] + ",";
                    lblAvailableStsRawPrms.Text = lblAvailableStsPrms.Text
                        += " " + DB.Select("SELECT Nombre FROM Sitio AS S, Temporada AS T WHERE S.ID = T.IdSitio AND T.ID = " + idPrms[i]).Rows[0][0].ToString() + ",";
                }
                else
                {
                    idTmpsPrsRng += " " + idPrms[i];
                    lblAvailableStsRawPrms.Text = lblAvailableStsPrms.Text
                        += " " + DB.Select("SELECT Nombre FROM Sitio AS S, Temporada AS T WHERE S.ID = T.IdSitio AND T.ID = " + idPrms[i]).Rows[0][0].ToString();
                }
            for (i = 0; i < idMcrs.Count; i++)
                if (i < idMcrs.Count - 1)
                {
                    idTmpsMcrsRng += " " + idMcrs[i] + ",";
                    lblAvailableStsMacro.Text
                        += " " + DB.Select("SELECT Nombre FROM Sitio AS S, Temporada AS T WHERE S.ID = T.IdSitio AND T.ID = " + idMcrs[i]).Rows[0][0].ToString() + ",";
                }
                else
                {
                    idTmpsMcrsRng += " " + idMcrs[i];
                    lblAvailableStsMacro.Text
                        += " " + DB.Select("SELECT Nombre FROM Sitio AS S, Temporada AS T WHERE S.ID = T.IdSitio AND T.ID = " + idMcrs[i]).Rows[0][0].ToString();
                }
            for (i = 0; i < idTsts.Count; i++)
                if (i < idTsts.Count - 1)
                {
                    idTmpsTstsRng += " " + idTsts[i] + ",";
                    lblAvailableStsOtherTsts.Text
                        += " " + DB.Select("SELECT Nombre FROM Sitio AS S, Temporada AS T WHERE S.ID = T.IdSitio AND T.ID = " + idTsts[i]).Rows[0][0].ToString() + ",";
                }
                else
                {
                    idTmpsTstsRng += " " + idTsts[i];
                    lblAvailableStsOtherTsts.Text
                        += " " + DB.Select("SELECT Nombre FROM Sitio AS S, Temporada AS T WHERE S.ID = T.IdSitio AND T.ID = " + idTsts[i]).Rows[0][0].ToString();
                }

            txtFileName.Text = DB.Select("SELECT P.Nombre FROM Proyecto AS P, Sitio AS S WHERE P.ID = S.IdProyecto AND S.ID = "
                + DB.Select("SELECT S.ID FROM Sitio AS S, Temporada AS T WHERE S.ID = T.IdSitio AND T.ID = " + idTemps[0]).Rows[0][0].ToString()).Rows[0][0].ToString()
                + "_Temporada" + DB.Select("SELECT Temporada FROM Temporada WHERE ID = " + idTemps[0]).Rows[0][0].ToString().Replace("/", "-").Remove(9);
        }

        private void chkMacro_CheckedChanged(object sender, EventArgs e)
        {
            if (!lblAvailableStsMacro.Text.Equals("Sitios Disponibles:"))
            {
                /*
SELECT a.* FROM ( 
SELECT T.ID AS ID, Estado, RioCuenca, S.Nombre, Abreviatura, DATE_FORMAT(Temporada, '%m-%Y') AS Temp, C.Nombre AS Clase, O.Nombre AS Orden, F.Nombre AS Familia, 
NULL AS Género, FS.Numero AS Número, FS.Habitat AS Hábitat, Responsable FROM Clase AS C, Orden AS O, Familia AS F, Temporada AS T, Sitio AS S, FamiliasSitios AS FS 
WHERE F.Nombre <> 'no identificado' AND C.ID = O.IdClase AND O.ID = F.IdOrden AND T.IdSitio = S.ID
AND FS.IdFamilia = F.ID AND FS.IdTemporada = T.ID AND FS.IdTemporada IN(4)
UNION ALL
SELECT T.ID AS ID, Estado, RioCuenca, S.Nombre, Abreviatura, DATE_FORMAT(Temporada, "%m-%Y") AS Temp, C.Nombre AS Clase, O.Nombre AS Orden, F.Nombre AS Familia, 
G.Nombre AS Género, GS.Numero AS Número, GS.Habitat AS Hábitat, Responsable FROM Clase AS C, Orden AS O, Familia AS F, Temporada AS T, Sitio AS S, Genero AS G, GenerosSitios AS GS 
WHERE G.Nombre <> 'no identificado' AND C.ID = O.IdClase AND O.ID = F.IdOrden AND T.IdSitio = S.ID AND F.ID = G.IdFamilia AND GS.IdGenero = G.ID AND GS.IdTemporada = T.ID AND GS.IdTemporada IN(4)
) AS a ORDER BY a.Responsable, a.Familia, a.Género
                */
                string whr = "C.ID = O.IdClase AND O.ID = F.IdOrden AND T.IdSitio = S.ID",
                        prms = "T.ID AS ID, Estado, RioCuenca, S.Nombre, Abreviatura, DATE_FORMAT(Temporada, '%m-%Y') AS Temp, C.Nombre AS Clase, O.Nombre AS Orden, F.Nombre AS Familia",
                        frm = "Clase AS C, Orden AS O, Familia AS F, Temporada AS T, Sitio AS S",
                        ttl = "Macroinvertebrados";
                string query = "SELECT a.* FROM ( "
                    + "SELECT " + prms + ", NULL AS Género, FS.Numero AS Número, FS.Habitat AS Hábitat, Responsable FROM " + frm + ", FamiliasSitios AS FS "
                        + "WHERE F.Nombre <> 'no identificado' AND " + whr + " AND FS.IdFamilia = F.ID AND FS.IdTemporada = T.ID AND FS.IdTemporada IN(" + idTmpsMcrsRng + ")"
                    + " UNION ALL "
                    + "SELECT " + prms + ", G.Nombre AS Género, GS.Numero AS Número, GS.Habitat AS Hábitat, Responsable FROM " + frm + ", Genero AS G, GenerosSitios AS GS "
                        + "WHERE G.Nombre <> 'no identificado' AND " + whr + " AND F.ID = G.IdFamilia AND GS.IdGenero = G.ID AND GS.IdTemporada = T.ID AND GS.IdTemporada IN(" + idTmpsMcrsRng + ")"
                    + ") AS a ORDER BY a.Responsable, a.Familia, a.Género";

                if (chkMacro.Checked)
                {
                    lsTitle.Add(ttl);
                    lsQuery.Add(query);
                }
                else
                {
                    lsTitle.Remove(ttl);
                    lsQuery.Remove(query);
                }
            }
        }

        private void chkRawPrms_CheckedChanged(object sender, EventArgs e)
        {
            if (!lblAvailableStsRawPrms.Text.Equals("Sitios Disponibles:"))
            {
                string whr = "IdTemporada IN(" + idTmpsPrsRng + ") AND T.ID = IdTemporada AND S.ID = T.IdSitio",
                        prms = "Ps.ID AS ID, Estado, S.Nombre AS Sitio, RioCuenca, Abreviatura, Norte, Oeste, Altitud, DATE_FORMAT(Temporada, '%m-%Y') AS Temporada",
                        frm = "ParametrosCrudo AS Ps, Temporada AS T, Sitio AS S",
                        ttl = "Parámetros crudos";
                string query = "SELECT a.* FROM ("
                        + "SELECT " + prms + ", 'Saturacion_1' AS Parámetro, Saturacion_1 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'Saturacion_2' AS Parámetro, Saturacion_2 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'Conductividad_1' AS Parámetro, Conductividad_1 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'Conductividad_2' AS Parámetro, Conductividad_2 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'OD_1' AS Parámetro, OD_1 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'OD_2' AS Parámetro, OD_2 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'pH_1' AS Parámetro, pH_1 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'pH_2' AS Parámetro, pH_2 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'Salinidad_1' AS Parámetro, Salinidad_1 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'Salinidad_2' AS Parámetro, Salinidad_2 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'TempAgua_1' AS Parámetro, TempAgua_1 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'TempAgua_2' AS Parámetro, TempAgua_2 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'TempAire_1' AS Parámetro, TempAire_1 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'TempAire_2' AS Parámetro, TempAire_2 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'Turbiedad_1' AS Parámetro, Turbiedad_1 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'Turbiedad_2' AS Parámetro, Turbiedad_2 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'VelocidadCorriente_1' AS Parámetro, VelocidadCorriente_1 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'VelocidadCorriente_2' AS Parámetro, VelocidadCorriente_2 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'Altura_1' AS Parámetro, Altura_1 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'Altura_2' AS Parámetro, Altura_2 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'VelocidadViento_1' AS Parámetro, VelocidadViento_1 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'VelocidadViento_2' AS Parámetro, VelocidadViento_2 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'Alcalinidad_1' AS Parámetro, Alcalinidad_1 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'Alcalinidad_2' AS Parámetro, Alcalinidad_2 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'Cloro_a1' AS Parámetro, Cloro_a1 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'Cloro_a2' AS Parámetro, Cloro_a2 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'ColFec' AS Parámetro, ColFec AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'ColTotal' AS Parámetro, ColTotal AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'Color_1' AS Parámetro, Color_1 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'Color_2' AS Parámetro, Color_2 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'DBOOD1_a1' AS Parámetro, DBOOD1_a1 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'DBOOD1_a2' AS Parámetro, DBOOD1_a2 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'DBOOD1_e1' AS Parámetro, DBOOD1_e1 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'DBOOD1_e2' AS Parámetro, DBOOD1_e2 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'DBOOD5_a1' AS Parámetro, DBOOD5_a1 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'DBOOD5_a2' AS Parámetro, DBOOD5_a2 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'DBOOD5_e1' AS Parámetro, DBOOD5_e1 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'DBOOD5_e2' AS Parámetro, DBOOD5_e2 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'NH3_1' AS Parámetro, NH3_1 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'NH3_2' AS Parámetro, NH3_2 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'NO2_1' AS Parámetro, NO2_1 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'NO2_2' AS Parámetro, NO2_2 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'NO3_1' AS Parámetro, NO3_1 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'NO3_2' AS Parámetro, NO3_2 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'NT_1' AS Parámetro, NT_1 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'NT_2' AS Parámetro, NT_2 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'OPO4_1' AS Parámetro, OPO4_1 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'OPO4_2' AS Parámetro, OPO4_2 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'PT_1' AS Parámetro, PT_1 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'PT_2' AS Parámetro, PT_2 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + ") AS a ORDER BY a.Responsable, a.Parámetro";

                if (chkRawPrms.Checked)
                {
                    lsTitle.Add(ttl);
                    lsQuery.Add(query);
                }
                else
                {
                    lsTitle.Remove(ttl);
                    lsQuery.Remove(query);
                }
            }
        }

        private void chkCalculatedPrms_CheckedChanged(object sender, EventArgs e)
        {
            if (!lblAvailableStsPrms.Text.Equals("Sitios Disponibles:"))
            {
                string whr = "IdTemporada IN(" + idTmpsPrsRng + ") AND T.ID = IdTemporada AND S.ID = T.IdSitio",
                        prms = "Ps.ID AS ID, Estado, S.Nombre AS Sitio, RioCuenca, Abreviatura, Norte, Oeste, Altitud, DATE_FORMAT(Temporada, '%m-%Y') AS Temporada",
                        frm = "Parametros AS Ps, Temporada AS T, Sitio AS S",
                        ttl = "Parámetros";
                string query = "SELECT a.* FROM ("
                        + "SELECT " + prms + ", 'Saturación' AS Parámetro, Saturacion AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'Conductividad' AS Parámetro, Conductividad AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'OD' AS Parámetro, OD AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'pH' AS Parámetro, pH AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'Salinidad' AS Parámetro, Salinidad AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'TempAgua' AS Parámetro, TempAgua AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'TempAire' AS Parámetro, TempAire AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'Turbiedad' AS Parámetro, Turbiedad AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'VelocidadCorriente' AS Parámetro, VelocidadCorriente AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'Altura' AS Parámetro, Altura AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'VelocidadViento' AS Parámetro, VelocidadViento AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'Alcalinidad' AS Parámetro, Alcalinidad AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'Cloro' AS Parámetro, Cloro AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'ColFec' AS Parámetro, ColFec AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'ColTotal' AS Parámetro, ColTotal AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'DBO' AS Parámetro, DBO AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'Dureza' AS Parámetro, Dureza AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'NH3' AS Parámetro, NH3 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'NO2' AS Parámetro, NO2 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'NO3' AS Parámetro, NO3 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'NT' AS Parámetro, NT AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'OPO4' AS Parámetro, OPO4 AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'PT' AS Parámetro, PT AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + " UNION ALL "
                        + "SELECT " + prms + ", 'Color' AS Parámetro, Color AS Valor, Responsable FROM " + frm + " WHERE " + whr
                        + ") AS a ORDER BY a.Responsable";

                if (chkCalculatedPrms.Checked)
                {
                    lsTitle.Add(ttl);
                    lsQuery.Add(query);
                }
                else
                {
                    lsTitle.Remove(ttl);
                    lsQuery.Remove(query);
                }
            }
        }

        private void chkOtherTsts_CheckedChanged(object sender, EventArgs e)
        {
            if (!lblAvailableStsOtherTsts.Equals("Sitios Disponibles:"))
            {
                string whr = "P.ID = Pp.IdPrueba AND Pp.ID = Pps.IdParametrosP AND IdTemporada = T.ID AND IdSitio = S.ID AND IdTemporada IN(" + idTmpsMcrsRng + ")",
                        prms = "IdTemporada AS ID, Estado, RioCuenca, Abreviatura, Norte, Oeste, Altitud, DATE_FORMAT(Temporada, '%m-%Y') AS Temp, S.Nombre AS Sitio, Pp.Nombre AS Parámetro, Valor, Responsable",
                        frm = "ParametrosPSitios AS Pps, ParametrosP AS Pp, Prueba AS P, Temporada AS T, Sitio AS S",
                        ttl = "Otras Pruebas";
                string query = "SELECT " + prms + " FROM " + frm + " WHERE " + whr;
                
                if (chkOtherTsts.Checked)
                {
                    lsTitle.Add(ttl);
                    lsQuery.Add(query);
                }
                else
                {
                    lsTitle.Remove(ttl);
                    lsQuery.Remove(query);
                }
            }
        }
    }
}
