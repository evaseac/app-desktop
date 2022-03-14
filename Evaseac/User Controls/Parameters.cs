using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Evaseac.Properties;

namespace Evaseac
{
    public partial class Parameters : UserControl
    {
        private int radAl = 0, radCl = 0, radOD1 = 0, radOD2 = 0, radHard = 0;
        private bool byParams; //True when default
        private string fieldValues, labValues, fieldRaw, labRaw;
        private string[] fldValues, lbValues, fldRaw, lbRaw; //When filled by Sites
        private string OD5, OD1; //by sites

        public bool editMode, passwordNotRequired = false;

        private bool hasAdmin;

        public Parameters()
        {
            InitializeComponent();
            sites = new List<string>();
            idTemps = new List<string>();
        }

        //Attributes

        public List<string> idTemps { get; set; }
        public List<string> sites { get; set; }

        //Methods

        private string getFieldValues()
        {
            return ((float.Parse(CtxtSat1.Text) + float.Parse(CtxtSat2.Text)) / 2f).ToString()
                        + ", " + ((float.Parse(CtxtCond1.Text) + float.Parse(CtxtCond2.Text)) / 2f).ToString()
                        + ", " + ((float.Parse(CtxtOD1.Text) + float.Parse(CtxtOD2.Text)) / 2f).ToString()
                        + ", " + ((float.Parse(CtxtPH1.Text) + float.Parse(CtxtPH2.Text)) / 2f).ToString()
                        + ", " + ((float.Parse(CtxtSalinity1.Text) + float.Parse(CtxtSalinity2.Text)) / 2f).ToString()
                        + ", " + ((float.Parse(CtxtWaterTemp1.Text) + float.Parse(CtxtWaterTemp2.Text)) / 2f).ToString()
                        + ", " + ((float.Parse(CtxtAirTemp1.Text) + float.Parse(CtxtAirTemp2.Text)) / 2f).ToString()
                        + ", " + ((float.Parse(CtxtTurb1.Text) + float.Parse(CtxtTurb2.Text)) / 2f).ToString()
                        + ", " + ((float.Parse(CtxtStreamSp1.Text) + float.Parse(CtxtStreamSp2.Text)) / 2f).ToString()
                        + ", " + ((float.Parse(CtxtHeight1.Text) + float.Parse(CtxtHeight2.Text)) / 2f).ToString()
                        + ", " + ((float.Parse(CtxtAirSp1.Text) + float.Parse(CtxtAirSp2.Text)) / 2f).ToString(); //11
        }

        private string getRawFieldVls()
        {
            return CtxtSat1.Text + ", " + CtxtSat2.Text + ", " + CtxtCond1.Text + ", " + CtxtCond2.Text + ", " + CtxtOD1.Text + ", " + CtxtOD2.Text
                        + ", " + CtxtPH1.Text + ", " + CtxtPH2.Text + ", " + CtxtSalinity1.Text + ", " + CtxtSalinity2.Text + ", " + CtxtWaterTemp1.Text + ", " + CtxtWaterTemp2.Text
                        + ", " + CtxtAirTemp1.Text + ", " + CtxtAirTemp2.Text + ", " + CtxtTurb1.Text + ", " + CtxtTurb2.Text + ", " + CtxtStreamSp1.Text + ", " + CtxtStreamSp2.Text
                        + ", " + CtxtHeight1.Text + ", " + CtxtHeight2.Text + ", " + CtxtAirSp1.Text + ", " + CtxtAirSp2.Text;//22
        }

        public void LoadField() 
        {
            CleanLab();
            CleanField();
            grpAlcalinity.Visible = LgrpCloro.Visible = LgrpColFec.Visible = LgrpColTotal.Visible = LgrpColor.Visible = LgrpDBOOD.Visible = LgrpDbo.Visible = lgrpOd2.Visible =
                LgrpHardness.Visible = LgrpNh3.Visible = LgrpNo2.Visible = LgrpNo3.Visible = LgrpNt.Visible = LgrpOpo4.Visible = LgrpPt.Visible = true;
            grpAlcalinity.Enabled = LgrpCloro.Enabled = LgrpColFec.Enabled = LgrpColTotal.Enabled = LgrpColor.Enabled = LgrpDBOOD.Enabled = LgrpDbo.Enabled = lgrpOd2.Enabled =
                LgrpHardness.Enabled = LgrpNh3.Enabled = LgrpNo2.Enabled = LgrpNo3.Enabled = LgrpNt.Enabled = LgrpOpo4.Enabled = LgrpPt.Enabled = true;

            tabParam.SelectedIndex = 0;

            editMode = CcboSite.Enabled = LcboSite.Enabled = true;
            CcboSite.Items.Clear();
            LcboSite.Items.Clear();
            for (int i = 0; i < idTemps.Count; i++)
            {
                CcboSite.Items.AddRange(new object[] { DB.Select("SELECT Nombre FROM Sitio WHERE ID = " + DB.Select("SELECT IdSitio FROM Temporada WHERE ID = " + idTemps[i]).Rows[0][0] + "").Rows[0][0] });
                LcboSite.Items.AddRange(new object[] { DB.Select("SELECT Nombre FROM Sitio WHERE ID = " + DB.Select("SELECT IdSitio FROM Temporada WHERE ID = " + idTemps[i]).Rows[0][0] + "").Rows[0][0] });
            }
            LcboSite.SelectedIndex = CcboSite.SelectedIndex = 0;
            CtxtSat1.Focus();

            if (!Settings.Default.askEdtParams && CtxtAirSp1.Enabled)
                using (frmEditMode frm = new frmEditMode())
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        Settings.Default.dftParams = frm.parameters;
                        Settings.Default.Save();
                    }

            byParams = Settings.Default.dftParams; //False when it's by sites
            if (!byParams && CtxtSat1.Enabled) //error when it's just read and don't ask true
            {
                CcboSite.Enabled = LcboSite.Enabled = false;
                fldValues = new string[CcboSite.Items.Count];
                fldRaw = new string[CcboSite.Items.Count];
                lbValues = new string[CcboSite.Items.Count];
                lbRaw = new string[CcboSite.Items.Count];

                for (int i = 0; i < CcboSite.Items.Count; i++)
                    if (DB.Select("SELECT OD FROM Parametros WHERE IdTemporada = " + idTemps[i]).Rows.Count != 0)
                    {
                        byParams = true;
                        break;
                    }

                if (byParams)
                    CcboSite.Enabled = LcboSite.Enabled = true;
            }
            else if (!byParams && !CtxtSat1.Enabled)
                byParams = true;

            if (!Settings.Default.dftParams && byParams && CtxtSat1.Enabled)
                MessageBox.Show("Los parametros no pueden ser llenados \"Por sitios\", debido a que se ha seleccionado un sitio con parametros ya ingresados\nPara poder usar esta modalidad todos los sitios seleccionados no deben de tener parametros previamente ingresados", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SetNoEditMode()
        {
            editMode = false;

            radCl = 0; radOD1 = 0; radHard = 0;

            CtxtAirSp2.Visible = CtxtAirTemp2.Visible = CtxtCond2.Visible = CtxtHeight2.Visible = CtxtOD2.Visible = CtxtPH2.Visible = CtxtSalinity2.Visible
                    = CtxtSat2.Visible = CtxtStreamSp2.Visible = CtxtTurb2.Visible = CtxtWaterTemp2.Visible = false;
            txtAlcA2.Visible = LtxtColFNo.Visible = LtxtColor2.Visible = LtxtColTNo.Visible = LtxtNH32.Visible = LtxtNO22.Visible = LtxtNO32.Visible
                = LtxtNT2.Visible = LtxtOPO42.Visible = LtxtPT2.Visible = label19.Visible = label20.Visible = false;
            CtxtAirSp1.Enabled = CtxtAirTemp1.Enabled = CtxtCond1.Enabled = CtxtHeight1.Enabled = CtxtOD1.Enabled = CtxtPH1.Enabled = CtxtSalinity1.Enabled = CtxtSat1.Enabled
                = CtxtStreamSp1.Enabled = CtxtTurb1.Enabled = CtxtWaterTemp1.Enabled = false;
            LtxtAlc1.Enabled = LtxtColFSerie.Enabled = LtxtColor1.Enabled = LtxtColTSerie.Enabled = LtxtNH31.Enabled = LtxtNO21.Enabled = LtxtNO31.Enabled = LtxtNT1.Enabled
                = LtxtOPO41.Enabled = LtxtPT1.Enabled = LtxtClA1.Enabled = LtxtDBOA1.Enabled = LtxtHard1.Enabled = LtxtDBO2A1.Enabled = false;

            CtxtAirSp1.Size = CtxtAirTemp1.Size = CtxtCond1.Size = CtxtHeight1.Size = CtxtOD1.Size = CtxtPH1.Size = CtxtSalinity1.Size = CtxtSat1.Size
                = CtxtStreamSp1.Size = CtxtTurb1.Size = CtxtWaterTemp1.Size = new System.Drawing.Size(475, 28);
            LtxtAlc1.Size = LtxtColFSerie.Size = LtxtColor1.Size = LtxtColTSerie.Size = LtxtNH31.Size = LtxtNO21.Size = LtxtNO31.Size = LtxtNT1.Size
                = LtxtOPO41.Size = LtxtPT1.Size = new System.Drawing.Size(467, 28);

            LradDBOFinalVal2.Visible = radAlc.Visible = lradClFinalVal.Visible = LradDBOFinalVal.Visible = LradHardFinalVal.Visible = false;
            LradDBOFinalVal2.Checked = radAlc.Checked = lradClFinalVal.Checked = LradDBOFinalVal.Checked = LradHardFinalVal.Checked = false;

            if (LgrpCloro.Size != new System.Drawing.Size(638, 113))
                RelocateCl(-300);
            if (LgrpDbo.Size != new System.Drawing.Size(638, 110))
                RelocateDBO(-310);
            if (grpAlcalinity.Size != new System.Drawing.Size(638, 110))
                RelocateAlc(-260);
            if (lgrpOd2.Size != new System.Drawing.Size(638, 110))
                RelocateOD2(-310);
            LradHardFinalVal.Checked = false;
            LlblNoHard.Visible = LtxtHard2.Visible = false;
            LtxtHard1.Size = new System.Drawing.Size(500, 28);
            LlblSerie.Text = "Final";

            CbtnNext.Visible = LbtnEnd.Visible = false;
        }

        private void SetEditMode()
        {
            editMode = true;

            radCl = 0; radOD1 = 0; radHard = 0;
            tabParam.SelectedIndex = 0;

            CleanField();
            CleanLab();

            CtxtAirSp2.Visible = CtxtAirTemp2.Visible = CtxtCond2.Visible = CtxtHeight2.Visible = CtxtOD2.Visible = CtxtPH2.Visible = CtxtSalinity2.Visible
                    = CtxtSat2.Visible = CtxtStreamSp2.Visible = CtxtTurb2.Visible = CtxtWaterTemp2.Visible = true;
            txtAlcA2.Visible = LtxtColFNo.Visible = LtxtColor2.Visible = LtxtColTNo.Visible = LtxtNH32.Visible = LtxtNO22.Visible = LtxtNO32.Visible
                = LtxtNT2.Visible = LtxtOPO42.Visible = LtxtPT2.Visible = label19.Visible = label20.Visible = true;
            CtxtAirSp1.Enabled = CtxtAirTemp1.Enabled = CtxtCond1.Enabled = CtxtHeight1.Enabled = CtxtOD1.Enabled = CtxtPH1.Enabled = CtxtSalinity1.Enabled = CtxtSat1.Enabled
                = CtxtStreamSp1.Enabled = CtxtTurb1.Enabled = CtxtWaterTemp1.Enabled = true;
            LtxtAlc1.Enabled = LtxtColFSerie.Enabled = LtxtColor1.Enabled = LtxtColTSerie.Enabled = LtxtNH31.Enabled = LtxtNO21.Enabled = LtxtNO31.Enabled = LtxtNT1.Enabled
                = LtxtOPO41.Enabled = LtxtPT1.Enabled = LtxtClA1.Enabled = LtxtDBOA1.Enabled = LtxtHard1.Enabled = LtxtDBO2A1.Visible = LtxtDBO2A1.Enabled = true;

            CtxtAirSp1.Size = CtxtAirTemp1.Size = CtxtCond1.Size = CtxtHeight1.Size = CtxtOD1.Size = CtxtPH1.Size = CtxtSalinity1.Size = CtxtSat1.Size
                = CtxtStreamSp1.Size = CtxtTurb1.Size = CtxtWaterTemp1.Size = new System.Drawing.Size(220, 28);
            LtxtAlc1.Size = LtxtColFSerie.Size = LtxtColor1.Size = LtxtColTSerie.Size = LtxtNH31.Size = LtxtNO21.Size = LtxtNO31.Size = LtxtNT1.Size
                = LtxtOPO41.Size = LtxtPT1.Size = new System.Drawing.Size(220, 28);

            LradDBOFinalVal2.Visible = radAlc.Visible = lradClFinalVal.Visible = LradDBOFinalVal.Visible = LradHardFinalVal.Visible = true;
            LradDBOFinalVal2.Checked = radAlc.Checked = lradClFinalVal.Checked = LradDBOFinalVal.Checked = LradHardFinalVal.Checked = false;

            //638, 263
            if (LgrpCloro.Size != new System.Drawing.Size(638, 413))
                RelocateCl(300);
            if (LgrpDbo.Size != new System.Drawing.Size(638, 420))
                RelocateDBO(310);
            if (grpAlcalinity.Size != new System.Drawing.Size(638, 370))
                RelocateAlc(260);
            if (lgrpOd2.Size != new System.Drawing.Size(638, 420))
                RelocateOD2(310);
            LradHardFinalVal.Checked = false;
            LlblNoHard.Visible = LtxtHard2.Visible = true;
            LtxtHard1.Size = new System.Drawing.Size(220, 28);
            LlblSerie.Text = "Gasto EDTA";


            CbtnNext.Visible = LbtnEnd.Visible = true;
        }

        private void CleanField()
        {
            CtxtAirSp1.Text = CtxtAirSp2.Text = CtxtAirTemp1.Text = CtxtAirTemp2.Text = CtxtCond1.Text = CtxtCond2.Text = CtxtHeight1.Text = CtxtHeight2.Text
                = CtxtOD1.Text = CtxtOD2.Text = CtxtPH1.Text = CtxtPH2.Text = CtxtSalinity1.Text = CtxtSalinity2.Text = CtxtSat1.Text = CtxtSat2.Text = CtxtStreamSp1.Text
                = CtxtStreamSp2.Text = CtxtTurb1.Text = CtxtTurb2.Text = CtxtWaterTemp1.Text = CtxtWaterTemp2.Text = "";
        }
        
        private void LoadLab()
        {
            if ((CtxtAirSp1.Text != "" && CtxtAirSp2.Text != "" && CtxtAirTemp1.Text != "" && CtxtAirTemp2.Text != "" && CtxtCond1.Text != "" && CtxtCond2.Text != ""
               && CtxtHeight1.Text != "" && CtxtHeight2.Text != "" && CtxtOD1.Text != "" && CtxtOD2.Text != "" && CtxtPH1.Text != "" && CtxtPH2.Text != ""
               && CtxtSalinity1.Text != "" && CtxtSalinity2.Text != "" && CtxtSat1.Text != "" && CtxtSat2.Text != "" && CtxtStreamSp1.Text != ""
               && CtxtStreamSp2.Text != "" && CtxtTurb1.Text != "" && CtxtTurb2.Text != "" && CtxtWaterTemp1.Text != "" && CtxtWaterTemp2.Text != "") || !editMode)
            {
                //Query Field Values
                if (editMode && byParams)
                {
                    fieldValues = getFieldValues();
                    fieldRaw = getRawFieldVls();
                }
                else if (!byParams && CtxtSat1.Enabled)
                {
                    LgrpCloro.Visible = LgrpColFec.Visible = LgrpColTotal.Visible = LgrpColor.Visible = LgrpDBOOD.Visible = LgrpDbo.Visible = lgrpOd2.Visible =
                        LgrpHardness.Visible = LgrpNh3.Visible = LgrpNo2.Visible = LgrpNo3.Visible = LgrpNt.Visible = LgrpOpo4.Visible = LgrpPt.Visible = false;
                    LgrpCloro.Enabled = LgrpColFec.Enabled = LgrpColTotal.Enabled = LgrpColor.Enabled = LgrpDBOOD.Enabled = LgrpDbo.Enabled = lgrpOd2.Enabled =
                        LgrpHardness.Enabled = LgrpNh3.Enabled = LgrpNo2.Enabled = LgrpNo3.Enabled = LgrpNt.Enabled = LgrpOpo4.Enabled = LgrpPt.Enabled = false;

                    LbtnEnd.Text = "Siguiente";
                    LbtnEnd.Location = new System.Drawing.Point(LbtnEnd.Location.X, (grpAlcalinity.Size.Height + grpAlcalinity.Location.Y) + 25);
                }
                
                LtxtAlc1.Focus();
            }
            else
            {
                MessageBox.Show("Llene todos los parametros de campo primero", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabParam.SelectedIndex = 0;
            }

            LtxtAlc1_TextChanged(null, null);
            LtxtClA1_TextChanged(null, null);
            LtxtDBO2A1_TextChanged(null, null);
            LtxtDBOA1_TextChanged(null, null);
        }

        private void CleanLab()
        {
            LtxtAlc1.Focus();
            LtxtAlc1.Text = txtAlcA2.Text = LtxtClA1.Text = LtxtClA2.Text = LtxtClB1.Text = LtxtClA2.Text = LtxtClC1.Text = LtxtClA2.Text = LtxtClD1.Text
                = LtxtColFNo.Text = LtxtColFSerie.Text = LtxtColor1.Text = LtxtColor2.Text = LtxtColTNo.Text = LtxtColTSerie.Text = LtxtDBOA1.Text = LtxtDBOA2.Text
                = LtxtDBOB1.Text = LtxtDBO2A1.Text = LtxtDBOC1.Text = LtxtDBOD1.Text = LtxtHard1.Text = LtxtHard2.Text = LtxtNH31.Text
                = LtxtNH32.Text = LtxtNO21.Text = LtxtNO22.Text = LtxtNO31.Text = LtxtNO32.Text = LtxtNT1.Text = LtxtNT2.Text = LtxtOPO41.Text = LtxtOPO42.Text
                = LtxtPT1.Text = LtxtPT2.Text = "";
            if (lradClFinalVal.Checked)
                lradClFinalVal.PerformClick();
            if (LradDBOFinalVal.Checked)
                LradDBOFinalVal.PerformClick();
            if (LradHardFinalVal.Checked)
                LradHardFinalVal.PerformClick();
            radCl = radOD1 = radHard = 0;

            lradClFinalVal.TabStop = LradDBOFinalVal.TabStop = LradHardFinalVal.TabStop = false;
            lradClFinalVal.TabStop = LradDBOFinalVal.TabStop = LradHardFinalVal.TabStop = true;

            txtAlcB.Text = "0.02";
            txtAlcC.Text = "50000";
            txtAlcD.Text = "10";
            LtxtClB1.Text = "0.1";
            LtxtClC1.Text = "0.0127";
            LtxtClD1.Text = "35450";
            LtxtClF1.Text = "10";
            LtxtDBOB1.Text = "0.0281";
            LtxtDBOC1.Text = "8";
            LtxtDBOD1.Text = "1000";
            LtxtDBO2B.Text = "0.0281";
            LtxtDBO2C.Text = "8";
            LtxtDBO2D.Text = "1000";
            LtxtHard2.Text = "100";
        }
        
        private void RelocateAlc(int y)
        {
            if (y < 0)
            {
                txtAlcB.Visible = txtAlcC.Visible = txtAlcD.Visible = txtAlcA2.Visible = false;
                LtxtAlc1.Size = new System.Drawing.Size(467, 28);
                label17.Text = "Final";
            }
            else
            {
                txtAlcB.Visible = txtAlcC.Visible = txtAlcD.Visible = txtAlcA2.Visible = true;
                LtxtAlc1.Size = new System.Drawing.Size(220, 28);
                label17.Text = "a";
            }

            this.grpAlcalinity.Size = new System.Drawing.Size(grpAlcalinity.Size.Width, (grpAlcalinity.Size.Height + y));
            LgrpCloro.Location = new System.Drawing.Point(LgrpCloro.Location.X, (LgrpCloro.Location.Y + y));
            LgrpColFec.Location = new System.Drawing.Point(LgrpColFec.Location.X, (LgrpColFec.Location.Y + y));
            LgrpColTotal.Location = new System.Drawing.Point(LgrpColTotal.Location.X, (LgrpColTotal.Location.Y + y));
            LgrpColor.Location = new System.Drawing.Point(LgrpColor.Location.X, (LgrpColor.Location.Y + y));
            LgrpDBOOD.Location = new System.Drawing.Point(LgrpDBOOD.Location.X, (LgrpDBOOD.Location.Y + y));
            LgrpDbo.Location = new System.Drawing.Point(LgrpDbo.Location.X, (LgrpDbo.Location.Y + y));
            lgrpOd2.Location = new System.Drawing.Point(lgrpOd2.Location.X, (lgrpOd2.Location.Y + y));
            LgrpHardness.Location = new System.Drawing.Point(LgrpHardness.Location.X, (LgrpHardness.Location.Y + y));
            LgrpNh3.Location = new System.Drawing.Point(LgrpNh3.Location.X, (LgrpNh3.Location.Y + y));
            LgrpNo2.Location = new System.Drawing.Point(LgrpNo2.Location.X, (LgrpNo2.Location.Y + y));
            LgrpNo3.Location = new System.Drawing.Point(LgrpNo3.Location.X, (LgrpNo3.Location.Y + y));
            LgrpNt.Location = new System.Drawing.Point(LgrpNt.Location.X, (LgrpNt.Location.Y + y));
            LgrpOpo4.Location = new System.Drawing.Point(LgrpOpo4.Location.X, (LgrpOpo4.Location.Y + y));
            LgrpPt.Location = new System.Drawing.Point(LgrpPt.Location.X, (LgrpPt.Location.Y + y));
            LbtnEnd.Location = new System.Drawing.Point(LbtnEnd.Location.X, (LbtnEnd.Location.Y + y));
        }

        private void RelocateCl(int y)
        {
            if (y < 0)
            {
                LtxtClA2.Visible = LtxtClB1.Visible = LtxtClC1.Visible = LtxtClD1.Visible = LtxtClF1.Visible = false;
                LtxtClA1.Size = new System.Drawing.Size(467, 28);
                LlblA.Text = "Final";
            }
            else
            {
                LtxtClA2.Visible = LtxtClB1.Visible = LtxtClC1.Visible = LtxtClD1.Visible = LtxtClF1.Visible = true;
                LlblB.Visible = LlblC.Visible = LlblD.Visible = true;
                LtxtClA1.Size = new System.Drawing.Size(220, 28);
                LlblA.Text = "a";
            }

            this.LgrpCloro.Size = new System.Drawing.Size(LgrpCloro.Size.Width, (LgrpCloro.Size.Height + y));
            LgrpColFec.Location = new System.Drawing.Point(LgrpColFec.Location.X, (LgrpColFec.Location.Y + y));
            LgrpColTotal.Location = new System.Drawing.Point(LgrpColTotal.Location.X, (LgrpColTotal.Location.Y + y));
            LgrpColor.Location = new System.Drawing.Point(LgrpColor.Location.X, (LgrpColor.Location.Y + y));
            LgrpDBOOD.Location = new System.Drawing.Point(LgrpDBOOD.Location.X, (LgrpDBOOD.Location.Y + y));
            LgrpDbo.Location = new System.Drawing.Point(LgrpDbo.Location.X, (LgrpDbo.Location.Y + y));
            lgrpOd2.Location = new System.Drawing.Point(lgrpOd2.Location.X, (lgrpOd2.Location.Y + y));
            LgrpHardness.Location = new System.Drawing.Point(LgrpHardness.Location.X, (LgrpHardness.Location.Y + y));
            LgrpNh3.Location = new System.Drawing.Point(LgrpNh3.Location.X, (LgrpNh3.Location.Y + y));
            LgrpNo2.Location = new System.Drawing.Point(LgrpNo2.Location.X, (LgrpNo2.Location.Y + y));
            LgrpNo3.Location = new System.Drawing.Point(LgrpNo3.Location.X, (LgrpNo3.Location.Y + y));
            LgrpNt.Location = new System.Drawing.Point(LgrpNt.Location.X, (LgrpNt.Location.Y + y));
            LgrpOpo4.Location = new System.Drawing.Point(LgrpOpo4.Location.X, (LgrpOpo4.Location.Y + y));
            LgrpPt.Location = new System.Drawing.Point(LgrpPt.Location.X, (LgrpPt.Location.Y + y));
            LbtnEnd.Location = new System.Drawing.Point(LbtnEnd.Location.X, (LbtnEnd.Location.Y + y));
        }

        private void RelocateDBO(int y)
        {
            if (y < 0)
            {
                LtxtDBOA2.Visible = LtxtDBOB1.Visible = LtxtDBOC1.Visible = LtxtDBOD1.Visible = LtxtDBOE1.Visible = LtxtDBOE2.Visible = false;
                LtxtDBOA1.Size = new System.Drawing.Size(467, 28);
                LlblDBOa.Text = "Final";
            }
            else
            {
                LtxtDBOA2.Visible = LtxtDBOB1.Visible = LtxtDBOC1.Visible = LtxtDBOD1.Visible = LtxtDBOE1.Visible = LtxtDBOE2.Visible = true;
                LtxtDBOA1.Size = new System.Drawing.Size(220, 28);
                LlblDBOa.Text = "a";
            }

            this.LgrpDbo.Size = new System.Drawing.Size(LgrpDbo.Size.Width, (LgrpDbo.Size.Height + y));
            lgrpOd2.Location = new System.Drawing.Point(lgrpOd2.Location.X, (lgrpOd2.Location.Y + y));
            LgrpHardness.Location = new System.Drawing.Point(LgrpHardness.Location.X, (LgrpHardness.Location.Y + y));
            LgrpNh3.Location = new System.Drawing.Point(LgrpNh3.Location.X, (LgrpNh3.Location.Y + y));
            LgrpNo2.Location = new System.Drawing.Point(LgrpNo2.Location.X, (LgrpNo2.Location.Y + y));
            LgrpNo3.Location = new System.Drawing.Point(LgrpNo3.Location.X, (LgrpNo3.Location.Y + y));
            LgrpNt.Location = new System.Drawing.Point(LgrpNt.Location.X, (LgrpNt.Location.Y + y));
            LgrpOpo4.Location = new System.Drawing.Point(LgrpOpo4.Location.X, (LgrpOpo4.Location.Y + y));
            LgrpPt.Location = new System.Drawing.Point(LgrpPt.Location.X, (LgrpPt.Location.Y + y));
            LbtnEnd.Location = new System.Drawing.Point(LbtnEnd.Location.X, (LbtnEnd.Location.Y + y));
        }

        private void RelocateOD2(int y)
        {
            if (y < 0)
            {
                LtxtDBO2A2.Visible = LtxtDBO2B.Visible = LtxtDBO2C.Visible = LtxtDBO2D.Visible = LtxtDBO2E1.Visible = LtxtDBO2E2.Visible = false;
                LtxtDBO2A1.Size = new System.Drawing.Size(467, 28);
                label36.Text = "Final";
            }
            else
            {
                LtxtDBO2A2.Visible = LtxtDBO2B.Visible = LtxtDBO2C.Visible = LtxtDBO2D.Visible = LtxtDBO2E1.Visible = LtxtDBO2E2.Visible = true;
                LtxtDBO2A1.Size = new System.Drawing.Size(220, 28);
                label36.Text = "a";
            }

            this.lgrpOd2.Size = new System.Drawing.Size(lgrpOd2.Size.Width, (lgrpOd2.Size.Height + y));
            LgrpHardness.Location = new System.Drawing.Point(LgrpHardness.Location.X, (LgrpHardness.Location.Y + y));
            LgrpNh3.Location = new System.Drawing.Point(LgrpNh3.Location.X, (LgrpNh3.Location.Y + y));
            LgrpNo2.Location = new System.Drawing.Point(LgrpNo2.Location.X, (LgrpNo2.Location.Y + y));
            LgrpNo3.Location = new System.Drawing.Point(LgrpNo3.Location.X, (LgrpNo3.Location.Y + y));
            LgrpNt.Location = new System.Drawing.Point(LgrpNt.Location.X, (LgrpNt.Location.Y + y));
            LgrpOpo4.Location = new System.Drawing.Point(LgrpOpo4.Location.X, (LgrpOpo4.Location.Y + y));
            LgrpPt.Location = new System.Drawing.Point(LgrpPt.Location.X, (LgrpPt.Location.Y + y));
            LbtnEnd.Location = new System.Drawing.Point(LbtnEnd.Location.X, (LbtnEnd.Location.Y + y));
        }

        private void RelocateControlsBySite(GroupBox grp1, GroupBox grp2)
        {
            grp1.Visible = grp1.Enabled = false;

            grp2.Visible = grp2.Enabled = true;
            grp2.Location = new System.Drawing.Point(grp2.Location.X, grpAlcalinity.Location.Y);
            LbtnEnd.Location = new System.Drawing.Point(LbtnEnd.Location.X, grp2.Size.Height + 25);

            LcboSite.SelectedIndex = 0;
        }

        ///Events
        
        //Field

        private void CbtnNext_Click(object sender, EventArgs e)
        {
            if (CtxtAirSp1.Text != "" && CtxtAirSp2.Text != "" && CtxtAirTemp1.Text != "" && CtxtAirTemp2.Text != "" && CtxtCond1.Text != "" && CtxtCond2.Text != ""
                  && CtxtHeight1.Text != "" && CtxtHeight2.Text != "" && CtxtOD1.Text != "" && CtxtOD2.Text != "" && CtxtPH1.Text != "" && CtxtPH2.Text != ""
                  && CtxtSalinity1.Text != "" && CtxtSalinity2.Text != "" && CtxtSat1.Text != "" && CtxtSat2.Text != "" && CtxtStreamSp1.Text != ""
                  && CtxtStreamSp2.Text != "" && CtxtTurb1.Text != "" && CtxtTurb2.Text != "" && CtxtWaterTemp1.Text != "" && CtxtWaterTemp2.Text != "")
            {
                if (byParams)
                    tabParam.SelectedIndex = 1;
                else
                {
                    fldValues[CcboSite.SelectedIndex] = getFieldValues();
                    fldRaw[CcboSite.SelectedIndex] = getRawFieldVls();

                    CtxtSat1.Focus();
                    if (CcboSite.SelectedIndex != CcboSite.Items.Count - 1)
                        CcboSite.SelectedIndex++;
                    else
                    {
                        tabParam.SelectedIndex = 1;
                        LcboSite.SelectedIndex = 0;
                    }

                    CleanField();
                }
            }
        }

        //Lab
        
        private void LbtnEnd_Click(object sender, EventArgs e)
        {
            string param = "IdTemporada, Saturacion, Conductividad, OD, pH, Salinidad, TempAgua, TempAire, Turbiedad, VelocidadCorriente, Altura"
                + ", VelocidadViento, Alcalinidad, Cloro, ColFec, ColTotal, Color, DBO, Dureza, NH3, NO2, NO3, NT, OPO4, PT"; //25
            string paramRaw = "IdTemporada, Saturacion_1, Saturacion_2, Conductividad_1, Conductividad_2, OD_1, OD_2, pH_1, pH_2, Salinidad_1, Salinidad_2"
                + ", TempAgua_1, TempAgua_2, TempAire_1, TempAire_2, Turbiedad_1, Turbiedad_2, VelocidadCorriente_1, VelocidadCorriente_2, Altura_1"
                + ", Altura_2, VelocidadViento_1, VelocidadViento_2, Alcalinidad_1, Alcalinidad_2, Cloro_a1, Cloro_a2, ColFec, ColTotal, Color_1, Color_2, DBOOD1_a1"
                + ", DBOOD1_a2, DBOOD1_e1, DBOOD1_e2, DBOOD5_a1, DBOOD5_a2, DBOOD5_e1, DBOOD5_e2, NH3_1, NH3_2, NO2_1, NO2_2, NO3_1, NO3_2, NT_1, NT_2"
                + ", OPO4_1, OPO4_2, PT_1, PT_2";//51

            if ((LtxtAlc1.Text != "" && LtxtClA1.Text != "" && LtxtColFNo.Text != "" && LtxtColFSerie.Text != "" && LtxtColor1.Text != ""
                && LtxtColor2.Text != "" && LtxtColTNo.Text != "" && LtxtColTSerie.Text != "" && LtxtDBOA1.Text != "" && LtxtHard1.Text != "" && LtxtNH31.Text != ""
                && LtxtNH32.Text != "" && LtxtNO21.Text != "" && LtxtNO22.Text != "" && LtxtNO31.Text != "" && LtxtNO32.Text != "" && LtxtNT1.Text != ""
                && LtxtNT2.Text != "" && LtxtOPO41.Text != "" && LtxtOPO42.Text != "" && LtxtPT1.Text != "" && LtxtPT2.Text != "") && byParams)
            {
                string textAlc = null, textCl = null, textDbo = null, textHard = null;
                //Alcalinity
                if (radAlc.Checked)
                    textAlc = LtxtAlc1.Text;
                else if (txtAlcA2.Text != "" && txtAlcB.Text != "" && txtAlcC.Text != "" && txtAlcD.Text != "" && LtxtAlc1.Text != "")
                    textAlc = (((((float.Parse(LtxtAlc1.Text)) + float.Parse(txtAlcA2.Text)) / 2f) * float.Parse(txtAlcB.Text) * float.Parse(txtAlcC.Text)) / float.Parse(txtAlcD.Text)).ToString();
                //Cloro- ((a-b)*c*d)/f
                if (lradClFinalVal.Checked)
                    textCl = LtxtClA1.Text;
                else if (LtxtClA2.Text != "" && LtxtClA1.Text != "" && LtxtClB1.Text != "" && LtxtClC1.Text != "" && LtxtClD1.Text != "" && LtxtClF1.Text != "")
                    textCl = (((((float.Parse(LtxtClA1.Text) + float.Parse(LtxtClA2.Text)) / 2f) - float.Parse(LtxtClB1.Text)) * float.Parse(LtxtClC1.Text) * float.Parse(LtxtClD1.Text)) / float.Parse(LtxtClF1.Text)).ToString();
                //DBO - (a*b*c*d)/e
                bool allDBOIn, allDBO2In;
                if (LtxtDBOA2.Text != "" && LtxtDBOB1.Text != "" && LtxtDBOA2.Text != "" && LtxtDBOC1.Text != "" && LtxtDBOD1.Text != "" && LtxtDBOE1.Text != "" && LtxtDBOE2.Text != "")
                    allDBOIn = true;
                else
                    allDBOIn = false;
                if (LtxtDBO2A1.Text != "" && LtxtDBO2A2.Text != "" && LtxtDBO2B.Text != "" && LtxtDBO2C.Text != "" && LtxtDBO2D.Text != "" && LtxtDBO2E1.Text != "" && LtxtDBO2E2.Text != "")
                    allDBO2In = true;
                else
                    allDBO2In = false;
                if (LradDBOFinalVal.Checked && LradDBOFinalVal2.Checked)
                    textDbo = (float.Parse(LtxtDBO2A1.Text) - float.Parse(LtxtDBOA1.Text)).ToString();
                else if (LradDBOFinalVal.Checked && !LradDBOFinalVal2.Checked && allDBO2In)
                    textDbo = ((((float.Parse(LtxtDBO2A1.Text) + float.Parse(LtxtDBO2A2.Text)) / 2f) * float.Parse(LtxtDBO2B.Text) * float.Parse(LtxtDBO2C.Text) * float.Parse(LtxtDBO2D.Text) / ((float.Parse(LtxtDBO2E1.Text) + float.Parse(LtxtDBO2E2.Text)) / 2f))
                        - (float.Parse(LtxtDBOA1.Text))).ToString();
                else if (!LradDBOFinalVal.Checked && LradDBOFinalVal2.Checked && allDBOIn)
                    textDbo = ((float.Parse(LtxtDBO2A1.Text))
                        - ((((float.Parse(LtxtDBOA1.Text) + float.Parse(LtxtDBOA2.Text)) / 2f) * float.Parse(LtxtDBOB1.Text) * float.Parse(LtxtDBOC1.Text) * float.Parse(LtxtDBOD1.Text)) / ((float.Parse(LtxtDBOE1.Text) + float.Parse(LtxtDBOE2.Text)) / 2f))).ToString();
                else if (!LradDBOFinalVal2.Checked && !LradDBOFinalVal.Checked && allDBOIn && allDBO2In)
                    textDbo = (((((float.Parse(LtxtDBO2A1.Text) + float.Parse(LtxtDBO2A2.Text)) / 2f) * float.Parse(LtxtDBO2B.Text) * float.Parse(LtxtDBO2C.Text) * float.Parse(LtxtDBO2D.Text)) / ((float.Parse(LtxtDBO2E1.Text) + float.Parse(LtxtDBO2E2.Text)) / 2f))
                        - ((((float.Parse(LtxtDBOA1.Text) + float.Parse(LtxtDBOA2.Text)) / 2f) * float.Parse(LtxtDBOB1.Text) * float.Parse(LtxtDBOC1.Text) * float.Parse(LtxtDBOD1.Text)) / ((float.Parse(LtxtDBOE1.Text) + float.Parse(LtxtDBOE2.Text)) / 2f))).ToString();
                //Hardness
                if (LradHardFinalVal.Checked)
                    textHard = LtxtHard1.Text;
                else if (LtxtHard1.Text != "" && LtxtHard2.Text != "")
                    textHard = (float.Parse(LtxtHard1.Text) * float.Parse(LtxtHard2.Text)).ToString();

                if (textCl != null && textDbo != null && textHard != null && textAlc != null)
                {
                    string txtAl2, txtCl2, txtDBOA2, txtDBOE1, txtDBOE2, txtDBO2A2, txtDBO2E1, txtDBO2E2;

                    if (radAlc.Checked) txtAl2 = "0";
                    else txtAl2 = txtAlcA2.Text;
                    if (lradClFinalVal.Checked) txtCl2 = "0";
                    else txtCl2 = LtxtClA2.Text;
                    if (LradDBOFinalVal.Checked)
                        txtDBOA2 = txtDBOE1 = txtDBOE2 = "0";
                    else
                    {
                        txtDBOA2 = LtxtDBOA2.Text;
                        txtDBOE1 = LtxtDBOE1.Text;
                        txtDBOE2 = LtxtDBOE2.Text;
                    }
                    if (LradDBOFinalVal2.Checked)
                        txtDBO2A2 = txtDBO2E1 = txtDBO2E2 = "0";
                    else
                    {
                        txtDBO2A2 = LtxtDBO2A2.Text;
                        txtDBO2E1 = LtxtDBO2E1.Text;
                        txtDBO2E2 = LtxtDBO2E2.Text;
                    }

                    labValues = textAlc + ", " + textCl
                        + ", " + LtxtColFNo.Text
                        + ", " + LtxtColTNo.Text
                        + ", " + ((float.Parse(LtxtColor1.Text) + float.Parse(LtxtColor2.Text)) / 2f).ToString()
                        + ", " + textDbo + ", " + textHard
                        + ", " + ((float.Parse(LtxtNH31.Text) + float.Parse(LtxtNH32.Text)) / 2f).ToString()
                        + ", " + ((float.Parse(LtxtNO21.Text) + float.Parse(LtxtNO22.Text)) / 2f).ToString()
                        + ", " + ((float.Parse(LtxtNO31.Text) + float.Parse(LtxtNO32.Text)) / 2f).ToString()
                        + ", " + ((float.Parse(LtxtNT1.Text) + float.Parse(LtxtNT2.Text)) / 2f).ToString()
                        + ", " + ((float.Parse(LtxtOPO41.Text) + float.Parse(LtxtOPO42.Text)) / 2f).ToString()
                        + ", " + ((float.Parse(LtxtPT1.Text) + float.Parse(LtxtPT2.Text)) / 2f).ToString(); //13
                    labRaw = LtxtAlc1.Text + ", " + txtAl2 + ", " + LtxtClA1.Text + ", " + txtCl2 + ", " + LtxtColFSerie.Text + ", " + LtxtColTSerie.Text
                        + ", " + LtxtColor1.Text + ", " + LtxtColor2.Text + ", " + LtxtDBOA1.Text + ", " + txtDBOA2 + ", " + txtDBOE1 + ", " + txtDBOE2
                        + ", " + LtxtDBO2A1.Text + ", " + txtDBO2A2 + ", " + txtDBO2E1 + ", " + txtDBO2E2
                        + ", " + LtxtNH31.Text + ", " + LtxtNH32.Text + ", " + LtxtNO21.Text + ", " + LtxtNO22.Text + ", " + LtxtNO31.Text + ", " + LtxtNO32.Text
                        + ", " + LtxtNT1.Text + ", " + LtxtNT2.Text + ", " + LtxtOPO41.Text + ", " + LtxtOPO42.Text + ", " + LtxtPT1.Text + ", " + LtxtPT2.Text;//28

                    DB.Insert("INSERT INTO Parametros (" + param + ") VALUES (" + idTemps[LcboSite.SelectedIndex] + ", " + fieldValues + ", " + labValues + ")");
                    DB.Insert("INSERT INTO ParametrosCrudo (" + paramRaw + ") VALUES (" + idTemps[LcboSite.SelectedIndex] + ", " + fieldRaw + ", " + labRaw + ")");
                    MessageBox.Show("Parametros ingresados correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Reloading                    
                    LoadField();
                }
            }
            else //by sites
            {
                if (grpAlcalinity.Visible)
                {
                    if (LtxtAlc1.Text != "")
                    {
                        string textAlc = null;//Calculating
                        if (radAlc.Checked)
                            textAlc = LtxtAlc1.Text;
                        else if (txtAlcA2.Text != "" && txtAlcB.Text != "" && txtAlcC.Text != "" && txtAlcD.Text != "" && LtxtAlc1.Text != "")
                            textAlc = (((((float.Parse(LtxtAlc1.Text)) + float.Parse(txtAlcA2.Text)) / 2f) * float.Parse(txtAlcB.Text) * float.Parse(txtAlcC.Text)) / float.Parse(txtAlcD.Text)).ToString();

                        if (textAlc != null)
                        {
                            if (LcboSite.SelectedIndex == LcboSite.Items.Count - 1) //Next Control
                            {
                                RelocateControlsBySite(grpAlcalinity, LgrpCloro);
                                LtxtClA1.Focus();
                            }
                            else //Next Combobox item
                            {
                                LcboSite.SelectedIndex++;
                                LtxtAlc1.Focus();
                            }
                            //Storing
                            lbValues[LcboSite.SelectedIndex] = textAlc + ", ";
                            if (radAlc.Checked) lbRaw[LcboSite.SelectedIndex] = LtxtAlc1.Text + ", 0, ";
                            else lbRaw[LcboSite.SelectedIndex] = LtxtAlc1.Text + ", " + txtAlcA2.Text + ", ";

                            LtxtAlc1.Text = txtAlcA2.Text = "";
                        }
                    }
                }
                else if (LgrpCloro.Visible)
                {
                    if (LtxtClA1.Text != "")
                    {
                        string textCl = null;
                        if (lradClFinalVal.Checked)
                            textCl = LtxtClA1.Text;
                        else if (LtxtClA2.Text != "" && LtxtClA1.Text != "" && LtxtClB1.Text != "" && LtxtClC1.Text != "" && LtxtClD1.Text != "" && LtxtClF1.Text != "")
                            textCl = (((((float.Parse(LtxtClA1.Text) + float.Parse(LtxtClA2.Text)) / 2f) - float.Parse(LtxtClB1.Text)) * float.Parse(LtxtClC1.Text) * float.Parse(LtxtClD1.Text)) / float.Parse(LtxtClF1.Text)).ToString();

                        if (textCl != null)
                        {
                            if (LcboSite.SelectedIndex == LcboSite.Items.Count - 1)
                            {
                                RelocateControlsBySite(LgrpCloro, LgrpColFec);
                                LtxtColFSerie.Focus();
                            }
                            else
                            {
                                LcboSite.SelectedIndex++;
                                LtxtClA1.Focus();
                            }

                            lbValues[LcboSite.SelectedIndex] += textCl + ", ";
                            if (lradClFinalVal.Checked) lbRaw[LcboSite.SelectedIndex] += LtxtClA1.Text + ", 0, ";
                            else lbRaw[LcboSite.SelectedIndex] += LtxtClA1.Text + ", " + LtxtClA2.Text + ", ";

                            LtxtClA1.Text = LtxtClA2.Text = "";
                        }
                    }
                }
                else if (LgrpColFec.Visible)
                {
                    if (LtxtColFNo.Text != "" && LtxtColFSerie.Text != "")
                    {
                        lbValues[LcboSite.SelectedIndex] += LtxtColFNo.Text + ", ";
                        lbRaw[LcboSite.SelectedIndex] += LtxtColFSerie.Text + ", ";

                        if (LcboSite.SelectedIndex == LcboSite.Items.Count - 1)
                        {
                            RelocateControlsBySite(LgrpColFec, LgrpColTotal);
                            LtxtColTSerie.Focus();
                        }
                        else
                        {
                            LcboSite.SelectedIndex++;
                            LtxtColFSerie.Focus();
                        }

                        LtxtColFNo.Text = LtxtColFSerie.Text = "";
                    }
                }
                else if (LgrpColTotal.Visible)
                {
                    if (LtxtColTNo.Text != "" && LtxtColTSerie.Text != "")
                    {
                        lbValues[LcboSite.SelectedIndex] += LtxtColTNo.Text + ", ";
                        lbRaw[LcboSite.SelectedIndex] += LtxtColTSerie.Text + ", ";

                        if (LcboSite.SelectedIndex == LcboSite.Items.Count - 1)
                        {
                            RelocateControlsBySite(LgrpColTotal, LgrpColor);
                            LtxtColor1.Focus();
                        }
                        else
                        {
                            LcboSite.SelectedIndex++;
                            LtxtColTSerie.Focus();
                        }

                        LtxtColTNo.Text = LtxtColTSerie.Text = "";
                    }
                }
                else if (LgrpColor.Visible)
                {
                    if (LtxtColor1.Text != "" && LtxtColor2.Text != "")
                    {
                        lbValues[LcboSite.SelectedIndex] += ((float.Parse(LtxtColor1.Text) + float.Parse(LtxtColor2.Text)) / 2f).ToString() + ", ";
                        lbRaw[LcboSite.SelectedIndex] += LtxtColor1.Text + ", " + LtxtColor2.Text + ", ";

                        if (LcboSite.SelectedIndex == LcboSite.Items.Count - 1)
                        {
                            LgrpDBOOD.Location = new System.Drawing.Point(grpAlcalinity.Location.X, grpAlcalinity.Location.Y);

                            RelocateControlsBySite(LgrpColor, LgrpDbo);
                            LtxtDBOA1.Focus();

                            LgrpDbo.Location = new System.Drawing.Point(LgrpDbo.Location.X, LgrpDbo.Location.Y + 71);
                            LbtnEnd.Location = new System.Drawing.Point(LbtnEnd.Location.X, LbtnEnd.Location.Y + 71);
                            LgrpDBOOD.Visible = LgrpDBOOD.Enabled = true;
                        }
                        else
                        {
                            LcboSite.SelectedIndex++;
                            LtxtColor1.Focus();
                        }

                        LtxtColor1.Text = LtxtColor2.Text = "";
                    }
                }
                else if (LgrpDbo.Visible) //OD5 - OD1
                {
                    if (LtxtDBOA1.Text != "")
                    {
                        OD1 = null;
                        if (LradDBOFinalVal.Checked)
                            OD1 = LtxtDBOA1.Text;
                        else if (LtxtDBOA2.Text != "" && LtxtDBOB1.Text != "" && LtxtDBOA2.Text != "" && LtxtDBOC1.Text != "" && LtxtDBOD1.Text != "" && LtxtDBOE1.Text != "" && LtxtDBOE2.Text != "")
                            OD1 = ((((float.Parse(LtxtDBOA1.Text) + float.Parse(LtxtDBOA2.Text)) / 2f) * float.Parse(LtxtDBOB1.Text) * float.Parse(LtxtDBOC1.Text) * float.Parse(LtxtDBOD1.Text)) / ((float.Parse(LtxtDBOE1.Text) + float.Parse(LtxtDBOE2.Text)) / 2f)).ToString();

                        if (OD1 != null)
                        {
                            if (LcboSite.SelectedIndex == LcboSite.Items.Count - 1)
                            {
                                RelocateControlsBySite(LgrpDbo, lgrpOd2);
                                LtxtDBO2A1.Focus();

                                lgrpOd2.Location = new System.Drawing.Point(lgrpOd2.Location.X, lgrpOd2.Location.Y + 71);
                                LbtnEnd.Location = new System.Drawing.Point(LbtnEnd.Location.X, LbtnEnd.Location.Y + 71);
                            }
                            else
                            {
                                LcboSite.SelectedIndex++;
                                LtxtDBOA1.Focus();
                            }

                            if (LradDBOFinalVal.Checked) lbRaw[LcboSite.SelectedIndex] += LtxtDBOA1.Text + ", 0, 0, 0, ";
                            else lbRaw[LcboSite.SelectedIndex] += LtxtDBOA1.Text + ", " + LtxtDBOA2.Text + ", " + LtxtDBOE1.Text + ", " + LtxtDBOE2.Text + ", ";

                            LtxtDBOA1.Text = LtxtDBOA2.Text = LtxtDBOE1.Text = LtxtDBOE2.Text = "";
                        }
                    }
                }
                else if (lgrpOd2.Visible)
                {
                    if (LtxtDBO2A1.Text != "")
                    {
                        OD5 = null;
                        if (LradDBOFinalVal2.Checked)
                            OD5 = LtxtDBO2A1.Text;
                        else if (LtxtDBO2A1.Text != "" && LtxtDBO2A2.Text != "" && LtxtDBO2B.Text != "" && LtxtDBO2C.Text != "" && LtxtDBO2D.Text != "" && LtxtDBO2E1.Text != "" && LtxtDBO2E2.Text != "")
                            OD5 = (((((float.Parse(LtxtDBO2A1.Text) + float.Parse(LtxtDBO2A2.Text)) / 2f) * float.Parse(LtxtDBO2B.Text) * float.Parse(LtxtDBO2C.Text) * float.Parse(LtxtDBO2D.Text)) / ((float.Parse(LtxtDBO2E1.Text) + float.Parse(LtxtDBO2E2.Text)) / 2f))).ToString();

                        if (OD5 != null)
                        {
                            if (LcboSite.SelectedIndex == LcboSite.Items.Count - 1)
                            {
                                LgrpDBOOD.Visible = LgrpDBOOD.Enabled = false;

                                RelocateControlsBySite(lgrpOd2, LgrpHardness);
                                LtxtHard1.Focus();
                            }
                            else
                            {
                                LcboSite.SelectedIndex++;
                                LtxtDBO2A1.Focus();
                            }

                            lbValues[LcboSite.SelectedIndex] += (float.Parse(OD5) - float.Parse(OD1)).ToString() + ", ";
                            if (LradDBOFinalVal2.Checked) lbRaw[LcboSite.SelectedIndex] += LtxtDBO2A1.Text + ", 0, 0, 0, ";
                            else lbRaw[LcboSite.SelectedIndex] += LtxtDBO2A1.Text + ", " + LtxtDBO2A2.Text + ", " + LtxtDBO2E1.Text + ", " + LtxtDBO2E2.Text + ", ";

                            LtxtDBO2A1.Text = LtxtDBO2A2.Text = LtxtDBO2E1.Text = LtxtDBO2E2.Text = "";
                        }
                    }
                }
                else if (LgrpHardness.Visible)
                {
                    if (LtxtHard1.Text != "")
                    {
                        string textHard = null;
                        if (LradHardFinalVal.Checked)
                            textHard = LtxtHard1.Text;
                        else if (LtxtHard1.Text != "" && LtxtHard2.Text != "")
                            textHard = (float.Parse(LtxtHard1.Text) * float.Parse(LtxtHard2.Text)).ToString();

                        if (textHard != null)
                        {
                            if (LcboSite.SelectedIndex == LcboSite.Items.Count - 1)
                            {
                                RelocateControlsBySite(LgrpHardness, LgrpNh3);
                                LtxtNH31.Focus();
                            }
                            else
                            {
                                LcboSite.SelectedIndex++;
                                LtxtHard1.Focus();
                            }

                            lbValues[LcboSite.SelectedIndex] += textHard + ", ";
                            //if (LradHardFinalVal.Checked) lbRaw[LcboSite.SelectedIndex] += LtxtHard1.Text + ", 0, ";
                            //else lbRaw[LcboSite.SelectedIndex] += LtxtHard1.Text + ", " + LtxtHard2.Text + ", ";

                            LtxtHard1.Text = "";
                        }
                    }
                }
                else if (LgrpNh3.Visible)
                {
                    if (LtxtNH31.Text != "" && LtxtNH32.Text != "")
                    {
                        lbValues[LcboSite.SelectedIndex] += ((float.Parse(LtxtNH31.Text) + float.Parse(LtxtNH32.Text)) / 2f).ToString() + ", ";
                        lbRaw[LcboSite.SelectedIndex] += LtxtNH31.Text + ", " + LtxtNH32.Text + ", ";

                        if (LcboSite.SelectedIndex == LcboSite.Items.Count - 1)
                        {
                            RelocateControlsBySite(LgrpNh3, LgrpNo2);
                            LtxtNO21.Focus();
                        }
                        else
                        {
                            LcboSite.SelectedIndex++;
                            LtxtNH31.Focus();
                        }

                        LtxtNH31.Text = LtxtNH32.Text = "";
                    }
                }
                else if (LgrpNo2.Visible)
                {
                    if (LtxtNO21.Text != "" && LtxtNO22.Text != "")
                    {
                        lbValues[LcboSite.SelectedIndex] += ((float.Parse(LtxtNO21.Text) + float.Parse(LtxtNO22.Text)) / 2f).ToString() + ", ";
                        lbRaw[LcboSite.SelectedIndex] += LtxtNO21.Text + ", " + LtxtNO22.Text + ", ";

                        if (LcboSite.SelectedIndex == LcboSite.Items.Count - 1)
                        {
                            RelocateControlsBySite(LgrpNo2, LgrpNo3);
                            LtxtNO31.Focus();
                        }
                        else
                        {
                            LcboSite.SelectedIndex++;
                            LtxtNO21.Focus();
                        }

                        LtxtNO21.Text = LtxtNO22.Text = "";
                    }
                }
                else if (LgrpNo3.Visible)
                {
                    if (LtxtNO31.Text != "" && LtxtNO32.Text != "")
                    {
                        lbValues[LcboSite.SelectedIndex] += ((float.Parse(LtxtNO31.Text) + float.Parse(LtxtNO32.Text)) / 2f).ToString() + ", ";
                        lbRaw[LcboSite.SelectedIndex] += LtxtNO31.Text + ", " + LtxtNO32.Text + ", ";

                        if (LcboSite.SelectedIndex == LcboSite.Items.Count - 1)
                        {
                            RelocateControlsBySite(LgrpNo3, LgrpNt);
                            LtxtNT1.Focus();
                        }
                        else
                        {
                            LcboSite.SelectedIndex++;
                            LtxtNO31.Focus();
                        }

                        LtxtNO31.Text = LtxtNO32.Text = "";
                    }
                }
                else if (LgrpNt.Visible)
                {
                    if (LtxtNT1.Text != "" && LtxtNT2.Text != "")
                    {
                        lbValues[LcboSite.SelectedIndex] += ((float.Parse(LtxtNT1.Text) + float.Parse(LtxtNT2.Text)) / 2f).ToString() + ", ";
                        lbRaw[LcboSite.SelectedIndex] += LtxtNT1.Text + ", " + LtxtNT2.Text + ", ";

                        if (LcboSite.SelectedIndex == LcboSite.Items.Count - 1)
                        {
                            RelocateControlsBySite(LgrpNt, LgrpOpo4);
                            LtxtOPO41.Focus();
                        }
                        else
                        {
                            LcboSite.SelectedIndex++;
                            LtxtNT1.Focus();
                        }

                        LtxtNT1.Text = LtxtNT2.Text = "";
                    }
                }
                else if (LgrpOpo4.Visible)
                {
                    if (LtxtOPO41.Text != "" && LtxtOPO42.Text != "")
                    {
                        lbValues[LcboSite.SelectedIndex] += ((float.Parse(LtxtOPO41.Text) + float.Parse(LtxtOPO42.Text)) / 2f).ToString() + ", ";
                        lbRaw[LcboSite.SelectedIndex] += LtxtOPO41.Text + ", " + LtxtOPO42.Text + ", ";

                        if (LcboSite.SelectedIndex == LcboSite.Items.Count - 1)
                        {
                            RelocateControlsBySite(LgrpOpo4, LgrpPt);
                            LtxtPT1.Focus();
                        }
                        else
                        {
                            LcboSite.SelectedIndex++;
                            LtxtOPO41.Focus();
                        }

                        LtxtOPO41.Text = LtxtOPO42.Text = "";
                    }
                }
                else if (LgrpPt.Visible)
                {
                    if (LtxtPT1.Text != "" && LtxtPT2.Text != "")
                    {
                        lbValues[LcboSite.SelectedIndex] += ((float.Parse(LtxtPT1.Text) + float.Parse(LtxtPT2.Text)) / 2f).ToString();
                        lbRaw[LcboSite.SelectedIndex] += LtxtPT1.Text + ", " + LtxtPT2.Text;
                        //End
                        if (LcboSite.SelectedIndex == LcboSite.Items.Count - 1)
                        {
                            for (int i = 0; i < fldValues.Length; i++)
                            {
                                DB.Insert("INSERT INTO Parametros (" + param + ") VALUES (" + idTemps[i] + ", " + fldValues[i] + ", " + lbValues[i] + ")");
                                DB.Insert("INSERT INTO ParametrosCrudo (" + paramRaw + ") VALUES (" + idTemps[i] + ", " + fldRaw[i] + ", " + lbRaw[i] + ")");
                            }
                            MessageBox.Show("Parametros ingresados correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //Relocating controls
//grpAlcalinity.Visible = LgrpCloro.Visible = LgrpColFec.Visible = LgrpColTotal.Visible = LgrpColor.Visible = LgrpDBOOD.Visible = LgrpDbo.Visible = lgrpOd2.Visible =
//LgrpHardness.Visible = LgrpNh3.Visible = LgrpNo2.Visible = LgrpNo3.Visible = LgrpNt.Visible = LgrpOpo4.Visible = LgrpPt.Visible = true;
                            LgrpCloro.Location = new System.Drawing.Point(grpAlcalinity.Location.X, (grpAlcalinity.Size.Height + grpAlcalinity.Location.Y) + 6);
                            LgrpColFec.Location = new System.Drawing.Point(grpAlcalinity.Location.X, (LgrpCloro.Size.Height + LgrpCloro.Location.Y) + 6);
                            LgrpColTotal.Location = new System.Drawing.Point(grpAlcalinity.Location.X, (LgrpColFec.Size.Height + LgrpColFec.Location.Y) + 6);
                            LgrpColor.Location = new System.Drawing.Point(grpAlcalinity.Location.X, (LgrpColTotal.Size.Height + LgrpColTotal.Location.Y) + 6);
                            LgrpDBOOD.Location = new System.Drawing.Point(grpAlcalinity.Location.X, (LgrpColor.Size.Height + LgrpColor.Location.Y) + 6);
                            LgrpDbo.Location = new System.Drawing.Point(grpAlcalinity.Location.X, (LgrpDBOOD.Size.Height + LgrpDBOOD.Location.Y) + 6);
                            lgrpOd2.Location = new System.Drawing.Point(grpAlcalinity.Location.X, (LgrpDbo.Size.Height + LgrpDbo.Location.Y) + 6);
                            LgrpHardness.Location = new System.Drawing.Point(grpAlcalinity.Location.X, (lgrpOd2.Size.Height + lgrpOd2.Location.Y) + 6);
                            LgrpNh3.Location = new System.Drawing.Point(grpAlcalinity.Location.X, (LgrpHardness.Size.Height + LgrpHardness.Location.Y) + 6);
                            LgrpNo2.Location = new System.Drawing.Point(grpAlcalinity.Location.X, (LgrpNh3.Size.Height + LgrpNh3.Location.Y) + 6);
                            LgrpNo3.Location = new System.Drawing.Point(grpAlcalinity.Location.X, (LgrpNo2.Size.Height + LgrpNo2.Location.Y) + 6);
                            LgrpNt.Location = new System.Drawing.Point(grpAlcalinity.Location.X, (LgrpNo3.Size.Height + LgrpNo3.Location.Y) + 6);
                            LgrpOpo4.Location = new System.Drawing.Point(grpAlcalinity.Location.X, (LgrpNt.Size.Height + LgrpNt.Location.Y) + 6);
                            LgrpPt.Location = new System.Drawing.Point(grpAlcalinity.Location.X, (LgrpOpo4.Size.Height + LgrpOpo4.Location.Y) + 6);
                            LbtnEnd.Location = new System.Drawing.Point(LbtnEnd.Location.X, (LgrpPt.Size.Height + LgrpPt.Location.Y) + 25);

                            LoadField();
                        }
                        else
                        {
                            LcboSite.SelectedIndex++;
                            LtxtPT1.Focus();
                        }

                        LtxtNO21.Text = LtxtNO22.Text = "";
                    }
                }
            }
        }

        private void Textbox_Leave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (txt.Text.Equals(""))
            {
                if (txt == txtAlcD || txt == LtxtClF1)
                    txt.Text = "10";
                else if (txt == LtxtDBO2B || txt == LtxtDBOB1)
                    txt.Text = "0.0281";
                else if (txt == LtxtDBOC1 || txt == LtxtDBO2C)
                    txt.Text = "8";
                else if (txt == LtxtDBOD1 || txt == LtxtDBO2D)
                    txt.Text = "1000";
                else if (txt == txtAlcC)
                    txt.Text = "50000";
                else if (txt == txtAlcB)
                    txt.Text = "0.02";
                else if (txt == LtxtClB1)
                    txt.Text = "0.1";
                else if (txt == LtxtClC1)
                    txt.Text = "0.0127";
                else if (txt == LtxtClD1)
                    txt.Text = "35450";
                else if (txt == LtxtHard2)
                    txt.Text = "100";
            }
        }

        private void LtxtAlc1_TextChanged(object sender, EventArgs e)
        {
            string a, b, c, d;

            if (LtxtAlc1.Text == "" || txtAlcA2.Text == "") //a
                a = "a";
            else
                a = ((float.Parse(LtxtAlc1.Text) + float.Parse(txtAlcA2.Text)) / 2f).ToString();
            if (txtAlcB.Text == "") //b
                b = "b";
            else
                b = txtAlcB.Text;
            if (txtAlcC.Text == "") //c
                c = "c";
            else
                c = txtAlcC.Text;
            if (txtAlcD.Text == "") // d
                d = "d";
            else
                d = txtAlcD.Text;

            //(a*b*c)/d
            lblFormulaAlc.Text = "(" + a + " × " + b + " × " + c + ") ÷ " + d;
        }

        private void LtxtClA1_TextChanged(object sender, EventArgs e)
        {
            string a, b, c, d, f;

            if (LtxtClA1.Text == "" || LtxtClA2.Text == "") //a
                a = "a";
            else
                a = ((float.Parse(LtxtClA1.Text) + float.Parse(LtxtClA2.Text)) / 2f).ToString();
            if (LtxtClB1.Text == "") //b
                b = "b";
            else
                b = LtxtClB1.Text;
            if (LtxtClC1.Text == "") //c
                c = "c";
            else
                c = LtxtClC1.Text;
            if (LtxtClD1.Text == "") // d
                d = "d";
            else
                d = LtxtClD1.Text;
            if (txtAlcD.Text == "") // f
                f = "f";
            else
                f = LtxtClF1.Text;

            //((a-b)*c*d)/f
            lblFormulaCl.Text = "((" + a + " - " + b + ") × " + c + " × " + d + ") ÷ " + f;
        }

        private void LtxtDBOA1_TextChanged(object sender, EventArgs e)
        {
            string a, b, c, d, f;

            if (LtxtDBOA1.Text == "" || LtxtDBOA2.Text == "") //a
                a = "a";
            else
                a = ((float.Parse(LtxtDBOA1.Text) + float.Parse(LtxtDBOA2.Text)) / 2f).ToString();
            if (LtxtDBOB1.Text == "") //b
                b = "b";
            else
                b = LtxtDBOB1.Text;
            if (LtxtDBOC1.Text == "") //c
                c = "c";
            else
                c = LtxtDBOC1.Text;
            if (LtxtDBOD1.Text == "") // d
                d = "d";
            else
                d = LtxtDBOD1.Text;
            if (LtxtDBOE1.Text == "" || LtxtDBOE2.Text == "") // f
                f = "e";
            else
                f = ((float.Parse(LtxtDBOE1.Text) + float.Parse(LtxtDBOE2.Text)) / 2f).ToString();

            //(a*b*c*d)/e
            lblFormulaOD5.Text = "(" + a + " × " + b + " × " + c + " × " + d + ") ÷ " + f;
        }

        private void LtxtDBO2A1_TextChanged(object sender, EventArgs e)
        {
            string a, b, c, d, f;

            if (LtxtDBO2A1.Text == "" || LtxtDBO2A2.Text == "") //a
                a = "a";
            else
                a = ((float.Parse(LtxtDBO2A1.Text) + float.Parse(LtxtDBO2A2.Text)) / 2f).ToString();
            if (LtxtDBO2B.Text == "") //b
                b = "b";
            else
                b = LtxtDBO2B.Text;
            if (LtxtDBO2C.Text == "") //c
                c = "c";
            else
                c = LtxtDBO2C.Text;
            if (LtxtDBO2D.Text == "") // d
                d = "d";
            else
                d = LtxtDBO2D.Text;
            if (LtxtDBO2E1.Text == "" || LtxtDBO2E2.Text == "") // f
                f = "e";
            else
                f = ((float.Parse(LtxtDBO2E1.Text) + float.Parse(LtxtDBO2E2.Text)) / 2f).ToString();

            //(a*b*c*d)/e
            lblFormulaOD1.Text = "(" + a + " × " + b + " × " + c + " × " + d + ") ÷ " + f;
        }

        private void lradClFinalVal_Click_1(object sender, EventArgs e)
        {
            bool cntn = true;
            if (hasAdmin && !passwordNotRequired)
                using (frmPassword frm = new frmPassword())
                    if (frm.ShowDialog() == DialogResult.OK)
                        if (frm.password == DB.Select("SELECT password FROM Usuario WHERE Usuario = 'admin'").Rows[0][0].ToString())
                            passwordNotRequired = cntn = true;
                        else
                            cntn = false;
                    else
                        cntn = false;

            if (cntn)
            {
                radCl++;
                if (radCl % 2 == 0)
                {
                    lradClFinalVal.Checked = false;
                    //638, 413 -> x, 113
                    RelocateCl(y: 300);
                }
                else
                    RelocateCl(y: -300);
            }
            else
                lradClFinalVal.Checked = false;
        }

        private void radAlc_Click(object sender, EventArgs e)
        {
            bool cntn = true;
            if (hasAdmin && !passwordNotRequired)
                using (frmPassword frm = new frmPassword())
                    if (frm.ShowDialog() == DialogResult.OK)
                        if (frm.password == DB.Select("SELECT password FROM Usuario WHERE Usuario = 'admin'").Rows[0][0].ToString())
                            passwordNotRequired = cntn = true;
                        else
                            cntn = false;
                    else
                        cntn = false;

            if (cntn)
            {
                radAl++;
                if (radAl % 2 == 0)
                {
                    radAlc.Checked = false;
                    RelocateAlc(y: 260);
                }
                else
                    RelocateAlc(y: -260);
            }
            else
                radAlc.Checked = false;
        }

        private void LradDBOFinalVal_Click_1(object sender, EventArgs e)
        {
            bool cntn = true;
            if (hasAdmin && !passwordNotRequired)
                using (frmPassword frm = new frmPassword())
                    if (frm.ShowDialog() == DialogResult.OK)
                        if (frm.password == DB.Select("SELECT password FROM Usuario WHERE Usuario = 'admin'").Rows[0][0].ToString())
                            passwordNotRequired = cntn = true;
                        else
                            cntn = false;
                    else
                        cntn = false;

            if (cntn)
            {
                radOD1++;
                if (radOD1 % 2 == 0)
                {
                    LradDBOFinalVal.Checked = false;
                    RelocateDBO(y: 310);
                }
                else
                    RelocateDBO(y: -310);
            }
            else
                LradDBOFinalVal.Checked = false;
        }

        private void LradDBOFinalVal2_Click(object sender, EventArgs e)
        {
            bool cntn = true;
            if (hasAdmin && !passwordNotRequired)
                using (frmPassword frm = new frmPassword())
                    if (frm.ShowDialog() == DialogResult.OK)
                        if (frm.password == DB.Select("SELECT password FROM Usuario WHERE Usuario = 'admin'").Rows[0][0].ToString())
                            passwordNotRequired = cntn = true;
                        else
                            cntn = false;
                    else
                        cntn = false;

            if (cntn)
            {
                radOD2++;
                if (radOD2 % 2 == 0)
                {
                    LradDBOFinalVal2.Checked = false;
                    RelocateOD2(y: 310);
                }
                else
                    RelocateOD2(y: -310);
            }
            else
                LradDBOFinalVal2.Checked = false;
        }

        private void LradHardFinalVal_Click_1(object sender, EventArgs e)
        {
            bool cntn = true;
            if (hasAdmin && !passwordNotRequired)
                using (frmPassword frm = new frmPassword())
                    if (frm.ShowDialog() == DialogResult.OK)
                        if (frm.password == DB.Select("SELECT password FROM Usuario WHERE Usuario = 'admin'").Rows[0][0].ToString())
                            passwordNotRequired = cntn = true;
                        else
                            cntn = false;
                    else
                        cntn = false;

            if (cntn)
            {
                radHard++;
                if (radHard % 2 == 0)
                {
                    LradHardFinalVal.Checked = false;
                    LlblNoHard.Visible = LtxtHard2.Visible = true;
                    LtxtHard1.Size = new System.Drawing.Size(220, 28);
                    LlblSerie.Text = "Gasto EDTA";
                }
                else
                {
                    LlblNoHard.Visible = LtxtHard2.Visible = false;
                    LtxtHard1.Size = new System.Drawing.Size(500, 28);
                    LlblSerie.Text = "Final";
                }
            }
            else
                LradHardFinalVal.Checked = false;
        }

        //Common

        private void Textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if ((!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) || ((e.KeyChar == '.') && (txt.Text.IndexOf('.') > -1))
                || ((e.KeyChar == '.') && ((sender as TextBox).SelectionStart == 0)))
                e.Handled = true;
        }

        private void tabParam_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabParam.SelectedIndex)
            {
                //case 0:
                //    if (!byParams) tabParam.SelectedIndex = 1;
                //    break;
                case 1: LoadLab(); break;
            }
        }

        private void Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbo = sender as ComboBox;
            CcboSite.SelectedIndex = LcboSite.SelectedIndex = cbo.SelectedIndex;
            
            if (cbo.SelectedIndex != -1 && DB.Select("SELECT OD FROM Parametros WHERE IdTemporada = " + idTemps[CcboSite.SelectedIndex]).Rows.Count == 1)
            {
                SetNoEditMode();

                DataTable data = DB.Select("SELECT * FROM Parametros WHERE IdTemporada = " + idTemps[cbo.SelectedIndex]); //:(
                                                                                                                          //Field
                CtxtSat1.Text = data.Rows[0]["Saturacion"].ToString();
                CtxtCond1.Text = data.Rows[0]["Conductividad"].ToString();
                CtxtOD1.Text = data.Rows[0]["OD"].ToString();
                CtxtPH1.Text = data.Rows[0]["pH"].ToString();
                CtxtSalinity1.Text = data.Rows[0]["Salinidad"].ToString();
                CtxtWaterTemp1.Text = data.Rows[0]["TempAgua"].ToString();
                CtxtAirTemp1.Text = data.Rows[0]["TempAire"].ToString();
                CtxtTurb1.Text = data.Rows[0]["Turbiedad"].ToString();
                CtxtStreamSp1.Text = data.Rows[0]["VelocidadCorriente"].ToString();
                CtxtHeight1.Text = data.Rows[0]["Altura"].ToString();
                CtxtAirSp1.Text = data.Rows[0]["VelocidadViento"].ToString();
                //Lab
                LtxtAlc1.Text = data.Rows[0]["Alcalinidad"].ToString();
                LtxtClA1.Text = data.Rows[0]["Cloro"].ToString();
                LtxtColFSerie.Text = data.Rows[0]["ColFec"].ToString();
                LtxtColTSerie.Text = data.Rows[0]["ColTotal"].ToString();
                LtxtColor1.Text = data.Rows[0]["Color"].ToString();
                LtxtDBO2A1.Text = LtxtDBOA1.Text = data.Rows[0]["DBO"].ToString();
                LtxtHard1.Text = data.Rows[0]["Dureza"].ToString();
                LtxtNH31.Text = data.Rows[0]["NH3"].ToString();
                LtxtNO21.Text = data.Rows[0]["NO2"].ToString();
                LtxtNO31.Text = data.Rows[0]["NO3"].ToString();
                LtxtNT1.Text = data.Rows[0]["NT"].ToString();
                LtxtOPO41.Text = data.Rows[0]["OPO4"].ToString();
                LtxtPT1.Text = data.Rows[0]["PT"].ToString();

                return;
            }
            else if(byParams)
                SetEditMode();

            if (DB.Select("SELECT * FROM Usuario WHERE Usuario = 'admin'").Rows.Count == 0)
                hasAdmin = false;
            else
                hasAdmin = true;
        }

        //
    }
}
