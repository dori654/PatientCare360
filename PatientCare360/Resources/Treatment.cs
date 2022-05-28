using System;
using System.Windows.Forms;

namespace PatientCare360.Resources
{
    public partial class Treatment : Form
    {
        public Treatment()
        {
            InitializeComponent();
        }

        public void info_Treatment(string text)
        {
            Treatment_info.Text=text;
        }
        private void Treatment_info_Click(object sender, EventArgs e)
        {

        }

        private void Final_Button_oK_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            DoctorUI Doctor = new DoctorUI();

            Doctor.Visible = true;
        }
    }
}
