using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Linq;

namespace SchoolMangementSystem
{
    public partial class AddStudentForm : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=NAMPHAN\MAY1;Initial Catalog=StudentManagementSystem;Integrated Security=True;TrustServerCertificate=True");
        public AddStudentForm()
        {
            InitializeComponent();
            displayStudentData();
            clearFields();
            displayClassid();
        }

        public void displayStudentData()
        {
            try
            {
                connect.Open();

                string sql = "SELECT * FROM students";

                using (SqlCommand cmd = new SqlCommand(sql, connect))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    da.Fill(table);
                    student_studentData.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting Database: " + ex);
            }
            finally
            {
                connect.Close();
            }
        }
        static bool CheckIfIdExists(string classid, string connectionString)
        {
            string query = "SELECT COUNT(*) FROM students WHERE student_id = @studentid";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@studentid", classid);

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
        private void button2_Click(object sender, EventArgs e)
        {
            string IdToCheck = student_id.Text;
            string connectionString = "Data Source=NAMPHAN\\MAY1;Initial Catalog=StudentManagementSystem;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            bool isIdTaken = CheckIfIdExists(IdToCheck, connectionString);
            if (isIdTaken)
            {
                MessageBox.Show("Đã có id này rồi.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connect.Close();
                return;
            }
            if (
                 student_name.Text == ""
                || student_gender.Text == ""
                || student_address.Text == ""
                || birthday.Text == ""
                || class_id.Text == ""
                || phone.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State != ConnectionState.Open)
                {
                    try
                    {
                        connect.Open();
                                string insertData = "INSERT INTO students (student_id, student_name" +
                                    ", student_gender, student_address, student_birthday, class_id" +
                                    ", phone_number) " +
                                    "VALUES(@studentId, @studentName, @studentGender, @studentAddress" +
                                    ", @studentBirthday, @classId, @phoneNumber)";

                                using (SqlCommand cmd = new SqlCommand(insertData, connect))
                                {
                                    cmd.Parameters.AddWithValue("@studentId", int.Parse(student_id.Text));
                                    cmd.Parameters.AddWithValue("@studentName", student_name.Text.Trim());
                                    cmd.Parameters.AddWithValue("@studentGender", student_gender.Text.Trim());
                                    cmd.Parameters.AddWithValue("@studentAddress", student_address.Text.Trim());
                                    cmd.Parameters.AddWithValue("@studentBirthday", DateTime.Parse(birthday.Text));
                                    cmd.Parameters.AddWithValue("@classId", class_id.Text.Trim());
                                    cmd.Parameters.AddWithValue("@phoneNumber", phone.Text.Trim());
                                    string phoneNumber = phone.Text.Trim();
                                    if (phoneNumber.Length != 10 || !phoneNumber.All(char.IsDigit))
                                    {
                                        MessageBox.Show("The phone number must be exactly 10 digits and contain only numbers.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        connect.Close();
                                        return;
                                    }
                                    DateTime studentBirthday = DateTime.Parse(birthday.Text); 
                                    if (studentBirthday > DateTime.Today)
                                    {
                                        MessageBox.Show("The birth date cannot be greater than today.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        connect.Close();
                                        return;
                                    }
                                        cmd.ExecuteNonQuery();
                                    MessageBox.Show("Add successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    connect.Close();
                                    displayStudentData();
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

        public int GetId()
        {
            int x = 0;
            try
            {
                connect.Open();
                string getId = "select max(student_id) from students";

                using (SqlCommand cmd = new SqlCommand(getId, connect))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        int curId = Convert.ToInt32(result);
                        x = curId + 1;
                    }
                    else
                    {
                       x = 1;
                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting Database: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                connect.Close();
            }
            return x;
        }

        public void displayClassid()
        {
            try
            {
                connect.Open();
                string getId = "select class_id from class";

                SqlDataAdapter adapter = new SqlDataAdapter(getId, connect);
                DataTable classTable = new DataTable();
                adapter.Fill(classTable);

                class_id.DataSource = classTable;
                class_id.DisplayMember = "class_id";
                class_id.ValueMember = "class_id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting Database: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                connect.Close();
            }
        }

        public void clearFields()
        {
            int x = GetId();
            student_id.Text = x.ToString();
            student_name.Text = "";
            student_gender.SelectedIndex = -1;
            student_address.Text = "";
            txtSearch.Text = "";
            phone.Text = "";
        }



        private void student_updateBtn_Click(object sender, EventArgs e)
        {
            if (
                 student_name.Text == ""
                || student_gender.Text == ""
                || student_address.Text == ""
                || birthday.Text == ""
                || class_id.Text == ""
                || phone.Text == "")
            {
                MessageBox.Show("Please select item first", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State != ConnectionState.Open)
                {
                    try
                    {
                        connect.Open();

                        DialogResult check = MessageBox.Show("Are you sure you want to Update ?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (check == DialogResult.Yes)
                        {
                            String updateData = "UPDATE students SET student_name = @studentName, " +
                                "student_gender = @studentGender, student_address = @studentAddress, " +
                                "student_birthday = @studentBirthday, phone_number = @phoneNumber, " +
                                "class_id = @classId WHERE student_id = @studentID";


                            using (SqlCommand cmd = new SqlCommand(updateData, connect))
                            {
                                cmd.Parameters.AddWithValue("@studentName", student_name.Text.Trim());
                                cmd.Parameters.AddWithValue("@studentGender", student_gender.Text.Trim());
                                cmd.Parameters.AddWithValue("@studentAddress", student_address.Text.Trim());
                                cmd.Parameters.AddWithValue("@studentBirthday", DateTime.Parse(birthday.Text));
                                cmd.Parameters.AddWithValue("@classId", class_id.Text.Trim());
                                cmd.Parameters.AddWithValue("@phoneNumber", phone.Text.Trim());
                                cmd.Parameters.AddWithValue("@studentID", student_id.Text.Trim());
                                string phoneNumber = phone.Text.Trim();
                                if (phoneNumber.Length != 10 || !phoneNumber.All(char.IsDigit))
                                {
                                    MessageBox.Show("The phone number must be exactly 10 digits and contain only numbers.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    connect.Close();
                                    return;
                                }
                                DateTime studentBirthday = DateTime.Parse(birthday.Text);
                                if (studentBirthday > DateTime.Today)
                                {
                                    MessageBox.Show("The birth date cannot be greater than today.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    connect.Close();
                                    return;
                                }
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Updated successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                connect.Close();
                                displayStudentData();
                                clearFields();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Cancelled.", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void student_studentData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = student_studentData.Rows[e.RowIndex];
                student_id.Text = row.Cells[0].Value.ToString();
                student_name.Text = row.Cells[1].Value.ToString();
                student_gender.Text = row.Cells[2].Value.ToString();
                student_address.Text = row.Cells[3].Value.ToString();
                birthday.Value = Convert.ToDateTime(row.Cells[4].Value);
                phone.Text = row.Cells[5].Value.ToString();
                class_id.Text = row.Cells[6].Value.ToString();

            }
        }

        private void student_deleteBtn_Click(object sender, EventArgs e)
        {
            if (student_id.Text == "")
            {
                MessageBox.Show("Please select item first", "Error Message"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State != ConnectionState.Open)
                {
                    DialogResult check = MessageBox.Show("Are you sure you want to Delete Student ID: "
                        + student_id.Text + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (check == DialogResult.Yes)
                    {
                        try
                        {
                            connect.Open();
                            string deleteData = "DELETE students WHERE student_id = @studentID";

                            using (SqlCommand cmd = new SqlCommand(deleteData, connect))
                            {
                                cmd.Parameters.AddWithValue("@studentID", student_id.Text.Trim());

                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Deleted successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error connecting Database: " + ex, "Error Message"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            connect.Close();
                            displayStudentData();
                            clearFields();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cancelled.", "Information Message"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void student_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
            displayStudentData();
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text.Trim();

                try
                {
                    // Mở kết nối
                    connect.Open();

                //Tạo câu truy vấn SQL
                string query = @"
                    SELECT student_id, student_name, student_gender, student_address, 
                           student_birthday, phone_number, class_id
                    FROM students
                    WHERE student_name LIKE @searchValue
                        OR student_address LIKE @searchValue
                        OR phone_number LIKE @searchValue
                        OR class_id LIKE @searchValue";
                using (SqlCommand command = new SqlCommand(query, connect))
                    {
                        command.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%");

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        student_studentData.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
                }
                finally
                {
                    connect.Close();
                }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
