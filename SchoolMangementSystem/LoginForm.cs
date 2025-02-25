using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Security.Cryptography;

namespace SchoolMangementSystem
{
    public partial class LoginForm : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=NAMPHAN\MAY1;Initial Catalog=StudentManagementSystem;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        static string HashPasswordWithSalt(string password, string salt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password + salt);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
        public string GetSalt()
        {
            object result = "";
            try
            {
                //connect.Open();
                string query = "SELECT salt FROM users WHERE username = @username";
                SqlCommand command = new SqlCommand(query, connect);
                command.Parameters.AddWithValue("@username", username.Text);
                result = command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return result.ToString();
        }
        private void loginBtn_Click(object sender, EventArgs e)
        {
            if(username.Text == "" || password.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    connect.Open();

                    String selectData = "SELECT password FROM users WHERE username = @username";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        string salt = GetSalt();

                        string password_before = password.Text.Trim();
                        string password_after = HashPasswordWithSalt(password_before, salt);
                        cmd.Parameters.AddWithValue("@username", username.Text.Trim());
                        var hashedPasswordInDb = cmd.ExecuteScalar()?.ToString();

                        if (hashedPasswordInDb == password_after)
                        {
                            MessageBox.Show("Login Successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            MainForm mForm = new MainForm();
                            mForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect Username/Password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }

                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error connecting Database: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    connect.Close();
                }
                

            }
        }
        private void showPass_CheckedChanged(object sender, EventArgs e)
        {
            password.PasswordChar = showPass.Checked ? '\0' : '*';
        }
        private void label7_Click(object sender, EventArgs e)
        {
            RegisterForm reForm = new RegisterForm();
            reForm.Show();
            this.Hide();
        }
        private void label7_MouseEnter(object sender, EventArgs e)
        {
            label7.ForeColor = Color.FromArgb(61, 192, 140);
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            label7.ForeColor = Color.Black;
        }
    }
}
