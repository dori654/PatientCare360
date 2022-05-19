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
            
            panel_AddPatient.Visible = false;
            panel_AddPatient2.Visible = false;
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



            //TODO: להוסיף פאנל להיסטורי
            //TODO: הכפתור מוביל לפורם חדש עם פלט של הטיפול
            //TODO: מתן - לתקן את הבדיקות גואי ,להוסיף עוד 2 לבדיקות 

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
            //TODO  : לעשות ככה שאם המשתמש זכר לא תופיעה השורה של הריון



            if (Check_ID(textBox_ID_panel2.Text) && Check_Age(Convert.ToInt32(textBox_Age_panel2.Text)))
            {
                pal = new Patient(dict);
                MessageBox.Show("Patient successfully added");

                //TOOD: new form !
                this.Visible=false;
                Treatment treatment = new Treatment();
                treatment.Visible = true;
                
                treatment.info_Treatment(pal.SavePatientfile());
                


            }






        }



        private void Button_Submit_Click_1(object sender, EventArgs e)
        {
            panel_AddPatient.Visible = false;
            panel_AddPatient2.Visible = true;

            dict["WBC"] = TextBox_WBC.Text;
            dict["Neut"] = "12";
            dict["Lymph"] = "12";
            dict["RBC"] = TextBox_RBC.Text;
            dict["HCT"] = "12";
            dict["Urea"] = Textbox_Urea.Text;
            dict["Hb"] = TextBox_HB.Text;
            dict["Creatinine"] = TextBox_Creatinine.Text;
            dict["Iron"] = textbox_iron.Text;
            dict["HDL"] = textBox_HDL.Text;
            dict["AP"] = textBox_AP.Text;



        }

        private void Slider_Neut_Scroll(object sender, EventArgs e)
        {
            Track_bar_precentage1_label.Text = Slider_Neut.Value.ToString() + "%";
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void Slider_Lymph_Scroll(object sender, EventArgs e)
        {
            Track_bar_precentage2_label.Text = Slider_Lymph.Value.ToString() + "%";
        }

        private void Slider_HCT_Scroll(object sender, EventArgs e)
        {
            Track_bar_precentage3_label.Text = Slider_HCT.Value.ToString() + "%";
        }
    }
}