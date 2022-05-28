using System;
using System.Windows.Forms;


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


        private bool ChecKSignUp(string username, string password, string confpassword, string fullname, string id)
        {
            if (CheckUserName(username))
            {
                MessageBox.Show("User Name Needs to be between 6 - 8 charcters and contains max 2 number");
                return false;
            }
            if (password != confpassword)
            {
                MessageBox.Show("Passwords don't match");
                return false;

            }
            if (!CheckPassword(password))
            {
                MessageBox.Show(
                    "Password Length must be 8-10 contain at least 1 number  and 1 special charcter and 1 letter");
                return false;

            }
            if (!CheckID(id))
            {
                MessageBox.Show("User's id must have a length of 9 characters!");
                return false;

            }
            if (Excel.Excel.CheckID_User(id))
            {
                MessageBox.Show("User's ID already exists in the database!");
                return false;

            }

            if (!CheckFullName(fullname))
            {
                MessageBox.Show("Please enter your full name");
                return false;

            }
            return true;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Username = textBoxUsername.Text;
            Password = textBoxPassword.Text;
            Fullname = textBoxFuname.Text;
            id = textBoxID.Text;
            ConfPassword = textBoxConfPassword.Text;

            if (ChecKSignUp(Username, Password, ConfPassword, Fullname, id))
            {

                try
                {
                    Username = textBoxUsername.Text;
                    Password = textBoxPassword.Text;
                    Fullname = textBoxFuname.Text;
                    id = textBoxID.Text;
                    ConfPassword = textBoxConfPassword.Text;

                    if (Excel.Excel.AddUser(Username, Password, id))
                    {
                        MessageBox.Show("Registration completed");
                        LoginForm log = new LoginForm();
                        this.Visible = false;
                        log.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("an a " + ex + "pops");
                }
            }
            else
                MessageBox.Show("Please try again");
        }

        private bool CheckFullName(string fullname)
        {
            if (fullname.Contains(" "))
                return true;
            return false;
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
