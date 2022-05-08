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
            


        }


        private void SignUpForm_Load(object sender, EventArgs e) { }


        private void btnRegister_Click(object sender, EventArgs e)
        {

            
            bool flag = false;

            if (CheckUserName(Username))
            {
                MessageBox.Show("User Name Needs to be between 6 - 8 charcters and contains max 2 number");
                flag = false;
            }


            if (Password != ConfPassword)
            {
                MessageBox.Show("Passwords Don't match");
                flag=false;
            }

            if (CheckPassword(Password))
            {
                MessageBox.Show(
                    "Password Length must be 8-10 contain at least 1 number  and 1 special charcter and 1 letter");
                flag = false;
            }

            if (!CheckID(id))
            {
                MessageBox.Show("Invalid User id: length 9 character only numbers or Id already registered.");
                flag = false;
            }

            flag = true;
            if (flag)
            {

                Username = textBoxUsername.Text;
                Password = textBoxPassword.Text;
                Fullname = textBoxFuname.Text;
                id = textBoxID.Text;
                ConfPassword = textBoxConfPassword.Text;


                Excel.Excel.AddUser(Username, Password, id);
            }
        }

        private bool CheckUserName(string Username)
        {
            if (Username.Length < 6 || Username.Length > 8)
            {
                return false;
            }
            //Contains a maximum of 2 digits ,Contains letters or numbers
            int count = 0;

            foreach (var c in Username)
            {
                if(char.IsDigit(Username,c))
                    count++;
                else if (!char.IsLetter(Username,c))
                {
                    return false;
                }
                if (count > 2) return false;
            }

            return true;

        }

        private bool CheckPassword(string password)
        {
            if (password.Length < 6 || password.Length > 10)
                return false;

            var count1 = 0;
            var count2 = 0;
            var count3 = 0;

            foreach (var c in password)
            {
                if (char.IsDigit(password,c)) count1++;

                else if (char.IsLetter(password, c)) count2++;

                else count3++;
                
                if (count1 >=1 && count2 >= 1 && count3 >= 1)
                    return true;
            }

            return false;
        }

        public static bool CheckID(string user_ID)
        {
            foreach (var c in user_ID)
            {
                if (!char.IsDigit(user_ID, c))
                    return false;
                if (user_ID.Length != 9)
                    return false;
            }

            return true;

            //TODO: check if allready registered
        }

    }






}
