using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolMangementSystem
{
    public partial class RegisterForm : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=NAMPHAN\MAY1;Initial Catalog=StudentManagementSystem;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        public RegisterForm()
        {
            InitializeComponent();
        }
        public void clearFields()
        {
            username.Text = "";
            password.Text = "";
            confirmPassword.Text = "";
        }
        static string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
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
        static bool CheckIfUsernameExists(string username, string connectionString)
        {
            string query = "SELECT COUNT(*) FROM users WHERE username = @Username";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);

                try
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar(); // Trả về số lượng bản ghi

                    return count > 0;  // Nếu có ít nhất 1 bản ghi, username đã tồn tại
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    return false;
                }
            }
        }
        private void registerBtn_Click(object sender, EventArgs e)
        {
            string usernameToCheck = username.Text;
            string connectionString = "Data Source=NAMPHAN\\MAY1;Initial Catalog=StudentManagementSystem;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            bool isUsernameTaken = CheckIfUsernameExists(usernameToCheck, connectionString);
            if (
                 username.Text == ""
                 ||password.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (password.Text != confirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (isUsernameTaken)
            {
                MessageBox.Show("Username is already taken.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
            else
            {
                if (connect.State != ConnectionState.Open)
                {
                    try
                    {
                        connect.Open();
                        string insertData = "INSERT INTO users (username" +
                            ", password, salt) VALUES(@username, @password, @salt)";

                        using (SqlCommand cmd = new SqlCommand(insertData, connect))
                        {
                            string password_before = password.Text.Trim();
                            string salt = GenerateSalt();
                            string hashedPassword = HashPasswordWithSalt(password_before, salt);
                            cmd.Parameters.AddWithValue("@username", username.Text.Trim());
                            cmd.Parameters.AddWithValue("@password", hashedPassword);
                            cmd.Parameters.AddWithValue("@salt", salt);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Add successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            connect.Close();
                            clearFields();
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error connecting Database: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            LoginForm lF = new LoginForm();
            this.Hide();
            lF.Show();
        }

        private void showPass_CheckedChanged(object sender, EventArgs e)
        {
            password.PasswordChar = showPass.Checked ? '\0' : '*';
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            confirmPassword.PasswordChar = showConPass.Checked ? '\0' : '*';
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
