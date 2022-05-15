using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace PatientCare360
{
    public partial class DoctorUI : Form
    {
        public DoctorUI()
        {
            InitializeComponent();
            panel_AddPatient.Visible = false;
            panel_AddPatient2.Visible = false;



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

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void panel_AddPatient2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button_Submit_Click(object sender, EventArgs e)
        {
            panel_AddPatient.Visible=false;
            panel_AddPatient2.Visible=true;
        }
    }
}
