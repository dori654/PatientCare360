using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml.ExternalReferences;


namespace PatientCare360
{
    public partial class SignUpForm : Form
    {
        public string Username;
        public string Password;
        public string Fullname;
        public string id;
        private string ConfPassword;


     

        public SignUpForm()
        {
            InitializeComponent();
            Username = textBoxUsername.Text;
            Password = textBoxPassword.Text;
            Fullname = textBoxFuname.Text;
            id = textBoxID.Text;
            ConfPassword = textBoxConfPassword.Text;
        }


        private void SignUpForm_Load(object sender, EventArgs e) { }


        private void btnRegister_Click(object sender, EventArgs e)
        {

            Username = textBoxUsername.Text;
            Password = textBoxPassword.Text;
            Fullname = textBoxFuname.Text;
            id = textBoxID.Text;
            ConfPassword = textBoxConfPassword.Text;
            bool flag = false;

            if (CheckUserName(Username))
            {
                MessageBox.Show("User Name Needs to be between 6 - 8 charcters and contains max 2 number");
                flag = false;
            }

            else if (Password != ConfPassword)
            {
                MessageBox.Show("Passwords don't match");
                flag=false;
            }

            else if (!CheckPassword(Password))
            {
                MessageBox.Show(
                    "Password Length must be 8-10 contain at least 1 number  and 1 special charcter and 1 letter");
                flag = false;
            }

            else if (!CheckID(id))
            {
                MessageBox.Show("User's id must have a length of 9 characters!");
                flag = false;
            }
            else if (Excel.Excel.CheckID_User(id))
            {
                MessageBox.Show("User's ID already exists in the database!");
            }
            else  
            flag = true;
            if (flag)
            {
                Username = textBoxUsername.Text;
                Password = textBoxPassword.Text;
                Fullname = textBoxFuname.Text;
                id = textBoxID.Text;
                ConfPassword = textBoxConfPassword.Text;
                Excel.Excel.AddUser(textBoxUsername.Text, textBoxPassword.Text, textBoxID.Text);
                MessageBox.Show("Registration completed");
                LoginForm log = new LoginForm();
                this.Visible = false;
                log.Visible = true;
            }
        }

        private bool CheckUserName(string username)
        {

            if (username.Length < 6 || username.Length > 8)
            {
                return false;
            }
            //Contains a maximum of 2 digits ,Contains letters or numbers
            int count = 0;

            for (int i = 0; i < username.Length; i++)
            {
                if (char.IsDigit(username, i))
                    count++;
                else if (!char.IsLetter(username,i))
                {
                    return false;
                }
                if (count > 2 )
                    return false;
            }

            return true;
            
        }

        private bool CheckPassword(string password)
        {
            Password = textBoxPassword.Text;
            if (password.Length < 6 || password.Length > 10)
                return false;

            var count1 = 0;
            var count2 = 0;
            var count3 = 0;

            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsDigit(password,i)) count1++;
                else if (char.IsLetter(password, i)) count2++;
                else count3++;

                if (count1 >= 1 && count2 >= 1 && count3 >= 1)
                    return true;
            }

            return false;
        }

        public bool CheckID(string user_ID)
        {
            for (int i = 0; i < user_ID.Length; i++)
            {
                if (!char.IsDigit(user_ID, i))
                    return false;
                if (user_ID.Length != 9)
                    return false;
            }
            
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            this.Visible = false;
            login.Visible = true;

        }
    }






}
