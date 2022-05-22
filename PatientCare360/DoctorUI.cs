using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml.ExternalReferences;
using PatientCare360.Resources;

namespace PatientCare360
{
    public partial class DoctorUI : Form
    {
        Patient pal;
        Dictionary<string, string> dict = new Dictionary<string, string>();
        public DoctorUI()
        {
            InitializeComponent();
            
            importExcel.Reset();
            panel_AddPatient.Visible = false;
            panel_AddPatient2.Visible = false;
            Patient_History_Panel.Visible=false;
            this.Size = new Size(this.Size.Width, Screen.PrimaryScreen.Bounds.Height);
        }

        private bool Check_ID(string ID)
        {

            if (ID.Length != 9)
            {
                MessageBox.Show("ID field must have exactly 9 numbers!");
                return false;
            }

            return true;
        }

        private void DoctorUI_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelLeft.Height = btnHome.Height;
            panelLeft.Top = btnHome.Top;
            panel_AddPatient.Visible = false;
            panel_AddPatient2.Visible = false;
            Patient_History_Panel.Visible = false;
        }

        private void btnNewPat_Click(object sender, EventArgs e)
        {
            panelLeft.Height = btnNewPat.Height;
            panelLeft.Top = btnNewPat.Top;
            panel_AddPatient.Visible = true;
            Patient_History_Panel.Visible = false;
            panel_AddPatient2.Visible = false;
        }

        private void btnPatHistory_Click(object sender, EventArgs e)
        {
            panelLeft.Height = btnPatHistory.Height;
            panelLeft.Top = btnPatHistory.Top;
            Patient_History_Panel.Visible = true;
            panel_AddPatient.Visible = false;
            panel_AddPatient2.Visible = false;
       
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            panelLeft.Height = btnLogOut.Height;
            panelLeft.Top = btnLogOut.Top;
            this.Visible = false;
            LoginForm log = new LoginForm();
            log.Visible = true;
        }


        private void button1_Click_2(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void DoctorUI_MouseMove(object sender, MouseEventArgs e)
        {
            Point lastPoint = new Point();
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void DoctorUI_MouseDown(object sender, MouseEventArgs e)
        {
            Point lastPoint = new Point();
            lastPoint = new Point(e.X, e.Y);
        }

        private bool Check_Age(int age)
        {
            if (age < 0 || age > 120)
            {
                MessageBox.Show("Age field must be between 0 to 120!");
                return false;
            }
            return true;
        }

        private void button_Continue_Panel2_Click(object sender, EventArgs e)
        {
            if (comboBox_gender.Text == "M")
            {
                radioButton_Pregnant_Y.Visible=false;
            }
            if (Check_ID(textBox_ID_panel2.Text) && Check_Age(Convert.ToInt32(textBox_Age_panel2.Text)))
            {
                dict["age"] = textBox_Age_panel2.Text;
                dict["gender"] = comboBox_gender.Text;
                dict["origin"] = comboBox_Eth_panel2.Text;
                dict["Fever"] = radioButton_Fever_Y.Checked ? "Yes" : "No";
                dict["Smokers"] = radioButton_Smokes_Y.Checked ? "Yes" : "No";
                dict["diarrhea"] = radioButton_Diarrhea_Y.Checked ? "Yes" : "No";
                dict["vomiting"] = radioButton_Vomiting_Y.Checked ? "Yes" : "No";
                if (comboBox_gender.Text == "F")
                    dict["pregnancy"] = radioButton_Pregnant_Y.Checked ? "Yes" : "No";
                dict["pregnancy"] = "No";

                pal = new Patient(dict);
                MessageBox.Show("Patient successfully added");
                this.Visible=false;
                Treatment treatment = new Treatment();
                treatment.Visible = true;
                
                treatment.info_Treatment(pal.SavePatientfile());
            }

            string fever = radioButton_Fever_Y.Checked ? "Yes" : "No";
            string smokes = radioButton_Smokes_Y.Checked ? "Yes" : "No";
            string diarrhea = radioButton_Diarrhea_Y.Checked ? "Yes" : "No";
            string vomiting = radioButton_Vomiting_Y.Checked ? "Yes" : "No";
            string pregnancy = radioButton_Pregnant_Y.Checked ? "Yes" : "No";


            Excel.Excel.AddPatient("Moshe","Davidian",textBox_ID_panel2.Text,textBox_Age_panel2.Text,smokes,fever,diarrhea,vomiting,pregnancy,
                TextBox_WBC.Text,Slider_Neut.Value.ToString(),Slider_Lymph.Value.ToString(),TextBox_RBC.Text,
                Slider_HCT.Value.ToString(),Textbox_Urea.Text,TextBox_HB.Text,
                TextBox_Creatinine.Text,textbox_iron.Text,textBox_HDL.Text,textBox_AP.Text,pal.diagnosis1);
           
        }
        private void Button_Submit_Click_1(object sender, EventArgs e)
        {
            if (!isNumeric(TextBox_WBC.Text, TextBox_RBC.Text, Textbox_Urea.Text, TextBox_Creatinine.Text,
                    textbox_iron.Text, textBox_HDL.Text, textBox_AP.Text))
            {
                MessageBox.Show("Enter only numeric values");
            }
            else
            {
                panel_AddPatient.Visible = false;
              
                panel_AddPatient2.Visible = true;
                dict["WBC"] = TextBox_WBC.Text;
                dict["Neut"] = Slider_Neut.Value.ToString();
                dict["Lymph"] = Slider_Lymph.Value.ToString();
                dict["RBC"] = TextBox_RBC.Text;
                dict["HCT"] = Slider_HCT.Value.ToString();
                dict["Urea"] = Textbox_Urea.Text;
                dict["Hb"] = TextBox_HB.Text;
                dict["Creatinine"] = TextBox_Creatinine.Text;
                dict["Iron"] = textbox_iron.Text;
                dict["HDL"] = textBox_HDL.Text;
                dict["AP"] = textBox_AP.Text;
            }
        }
        private bool isNumeric(string text, string s, string text1, string s1, string text2, string s2, string text3)
        {
            
            try
            {
                double d = double.Parse(text);
                double a = double.Parse(s);
                double b = double.Parse(text1);
                double c = double.Parse(s1);
                double d1 = double.Parse(text2);
                double e = double.Parse(s2);
                double f = double.Parse(text3);
            }
            catch (FormatException)
            {
                return false;
            }
            return true;

        }
        private void Slider_Neut_Scroll(object sender, EventArgs e)
        {
            Track_bar_precentage1_label.Text = Slider_Neut.Value.ToString() + "%";
        }
        private void Slider_Lymph_Scroll(object sender, EventArgs e)
        {
            Track_bar_precentage2_label.Text = Slider_Lymph.Value.ToString() + "%";
        }
        private void Slider_HCT_Scroll(object sender, EventArgs e)
        {
            Track_bar_precentage3_label.Text = Slider_HCT.Value.ToString() + "%";
        }



        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try {
                Excel.Excel.ReadFile(importExcel.FileName);
                }
            catch (System.FormatException)
            {
                MessageBox.Show("File must be xlsx type only!");
            }
            TextBox_WBC.Text = Excel.Excel.wbc;
            Slider_Neut.Value = Convert.ToInt32(Excel.Excel.neut);
            Slider_Lymph.Value= Convert.ToInt32(Excel.Excel.lymph);
            TextBox_RBC.Text= Excel.Excel.rbc;
            Slider_HCT.Value = Convert.ToInt32(Excel.Excel.hct);
            Textbox_Urea.Text= Excel.Excel.urea;
            TextBox_HB.Text = Excel.Excel.hb;
            TextBox_Creatinine.Text = Excel.Excel.crtn;
            textbox_iron.Text = Excel.Excel.iron;
            textBox_HDL.Text = Excel.Excel.hdl;
            textBox_AP.Text = Excel.Excel.ap;

            btnNewPat_Click(sender, e);
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            panelLeft.Height = btnLogOut.Height;
            panelLeft.Top = btnLogOut.Top;
            importExcel.ShowDialog();
        }

        private void button_history_find_Click(object sender, EventArgs e)
        {
            //TODO: בודק אם הת.ז קיים בקובץ ומקשר בין הטקסטים שבקובץ
        }
    }
}