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
namespace PatientCare360
{
    public partial class DoctorUI : Form
    {
        Patient pal ;
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
         
            if ( ID.Length != 9)
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

        }

        private void btnNewPat_Click(object sender, EventArgs e)
        {
            panelLeft.Height = btnNewPat.Height;
            panelLeft.Top = btnNewPat.Top;
            panel_AddPatient.Visible=true;
        }

        private void btnPatHistory_Click(object sender, EventArgs e)
        {
            panelLeft.Height = btnPatHistory.Height;
            panelLeft.Top = btnPatHistory.Top;
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



        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        public void label15_Click(object sender, EventArgs e)
        {

        }

        public void panel_AddPatient2_Paint(object sender, PaintEventArgs e)
        {

        }

      
        private void Textbox_WBC_TextChanged(object sender, EventArgs e)
        {

        }
        private bool Check_Age(int age)
        {
            if (age < 0 ||  age > 120)
            {
                MessageBox.Show("Age field must be between 0 to 120!");
                return false;
            }
            return true;
        }

        private void textBox_ID_panel2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox_Age_panel2_TextChanged(object sender, EventArgs e)
        {
         
        }






        private void button_Continue_Panel2_Click(object sender, EventArgs e)
        {
            Check_ID(textBox_ID_panel2.Text);
            Check_Age(Convert.ToInt32(textBox_Age_panel2.Text));
            //TODO: לאן הכפתור הזה מוביל ? מה עושים עם המידע שנשלח למילון ? 
            //TODO: לטפל ברדיו של הכן ולא 
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



            pal = new Patient(dict);

            Console.WriteLine(pal.SavePatientfile());



        }

        private void radioButton_Smokes_N_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox_Eth_panel2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
