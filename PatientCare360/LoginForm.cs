using System;
using System.Windows.Forms;

namespace PatientCare360
{
    public partial class LoginForm : Form
    {
        public string Username ;
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
                MessageBox.Show("Login successful");
                DoctorUI Doctor = new DoctorUI();

                Doctor.Visible = true;
                Username = TextBoxUsername.Text;

            }

            else
            {
                MessageBox.Show("Could not find user in the database , try to register first!");
            }
            
        }

        private void labelPassword_Click(object sender, EventArgs e)
        {

        }

        private void labelUsername_Click(object sender, EventArgs e)
        {

        }
    }
}
