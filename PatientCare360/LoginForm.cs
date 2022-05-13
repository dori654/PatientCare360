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
    public partial class LoginForm : Form
    {
        public string Username;
        public string Password;
        public LoginForm()
        {
            InitializeComponent();
            
        }

     
        private void BtnSignup_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            SignUpForm s = new SignUpForm();
            s.Visible = true;
         

        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {

            if (Excel.Excel.SearchUser(TextBoxUsername.Text, textBoxPassword.Text))
            {
                this.Visible = false;
                DoctorUI Doctor = new DoctorUI();

                Doctor.Visible = true;
            }

            else
            {
                MessageBox.Show("Could not find user in the database , try to register first!");
            }
            
        }

        private void labelPassword_Click(object sender, EventArgs e)
        {

        }
    }
}
