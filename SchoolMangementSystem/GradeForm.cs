using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolMangementSystem
{
    public partial class GradeForm : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=NAMPHAN\MAY1;Initial Catalog=StudentManagementSystem;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        public GradeForm()
        {
            InitializeComponent();
            gradeDisplayData();
            displayStudentid();
            displaySubjectid();
        }
        public void gradeDisplayData()
        {
            try
            {
                connect.Open();
                string sql = "SELECT * FROM grade";

                using (SqlCommand cmd = new SqlCommand(sql, connect))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    da.Fill(table);
                    grade_gridData.DataSource = table;
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
        public void displayStudentid()
        {
            try
            {
                connect.Open();
                string getId = "select student_id from students";

                SqlDataAdapter adapter = new SqlDataAdapter(getId, connect);
                DataTable studentTable = new DataTable();
                adapter.Fill(studentTable);

                student_id.DataSource = studentTable;
                student_id.DisplayMember = "student_id";
                student_id.ValueMember = "student_id";
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
        public void displaySubjectid()
        {
            try
            {
                connect.Open();
                string getId = "select subject_id from subjects";

                SqlDataAdapter adapter = new SqlDataAdapter(getId, connect);
                DataTable subjectTable = new DataTable();
                adapter.Fill(subjectTable);

                subject_id.DataSource = subjectTable;
                subject_id.DisplayMember = "subject_id";
                subject_id.ValueMember = "subject_id";
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
            txtSearch.Text = "";
            grade.Text = "";
        }
        static bool CheckGradeExists(string subjectid, string studentid, string connectionString)
        {
            string query = "SELECT COUNT(*) FROM grade WHERE student_id = @studentid AND subject_id = @subjectid";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@subjectid", subjectid);
                command.Parameters.AddWithValue("@studentid", studentid);
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
        private void grade_addBtn_Click(object sender, EventArgs e)
        {
            string subIdToCheck = subject_id.Text;
            string studentIdToCheck = student_id.Text;
            string connectionString = "Data Source=NAMPHAN\\MAY1;Initial Catalog=StudentManagementSystem;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            bool isGradeTaken = CheckGradeExists(subIdToCheck, studentIdToCheck, connectionString);
            if (
                 grade.Text == "")
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
                        string insertData = "INSERT INTO grade (student_id" +
                            ", subject_id, grade) VALUES(@studentId, @subjectId, @grade)";

                        using (SqlCommand cmd = new SqlCommand(insertData, connect))
                        {
                            cmd.Parameters.AddWithValue("@studentId", student_id.Text.Trim());
                            cmd.Parameters.AddWithValue("@subjectId", subject_id.Text.Trim());
                            cmd.Parameters.AddWithValue("@grade", grade.Text.Trim());
                            if (isGradeTaken)
                            {
                                MessageBox.Show("Học sinh này đã có điểm môn này rồi.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                connect.Close();
                                return;
                            }
                            string input = grade.Text.Trim();
                            if (!float.TryParse(input, out float result))
                            {
                                MessageBox.Show("Điểm không phải là số thực!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                connect.Close();
                                return;
                            }
                            float diem = float.Parse(grade.Text);
                            if (diem < 0 || diem > 10)
                            {
                                MessageBox.Show("Diểm phải từ 0 đến 10.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                connect.Close();
                                return;
                            }
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Add successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            connect.Close();
                            gradeDisplayData();
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

        private void class_updateBtn_Click(object sender, EventArgs e)
        {
            if (
                 grade.Text == "")
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
                            String updateData = "UPDATE grade SET grade = @grade WHERE student_id = @studentId AND subject_id = @subjectId";


                            using (SqlCommand cmd = new SqlCommand(updateData, connect))
                            {
                                cmd.Parameters.AddWithValue("@studentId", student_id.Text.Trim());
                                cmd.Parameters.AddWithValue("@subjectId", subject_id.Text.Trim());
                                cmd.Parameters.AddWithValue("@grade", grade.Text.Trim());
                                string input = grade.Text.Trim();
                                if (!float.TryParse(input, out float result))
                                {
                                    MessageBox.Show("Điểm không phải là số thực!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    connect.Close();
                                    return;
                                }
                                float diem = float.Parse(grade.Text);
                                if (diem < 0 || diem > 10)
                                {
                                    MessageBox.Show("Diểm phải từ 0 đến 10.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    connect.Close();
                                    return;
                                }
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Updated successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                connect.Close();
                                gradeDisplayData();
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

        private void grade_gridData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = grade_gridData.Rows[e.RowIndex];
                student_id.Text = row.Cells[0].Value.ToString();
                subject_id.Text = row.Cells[1].Value.ToString();
                grade.Text = row.Cells[2].Value.ToString();

            }
        }
        private void class_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
            gradeDisplayData();
        }

        private void class_deleteBtn_Click(object sender, EventArgs e)
        {
            if (grade.Text == "")
            {
                MessageBox.Show("Please select item first", "Error Message"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State != ConnectionState.Open)
                {
                    DialogResult check = MessageBox.Show("Are you sure you want to Delete ?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (check == DialogResult.Yes)
                    {
                        try
                        {
                            connect.Open();
                            string deleteData = "DELETE grade WHERE student_id = @studentId AND subject_id = @subjectId";

                            using (SqlCommand cmd = new SqlCommand(deleteData, connect))
                            {
                                cmd.Parameters.AddWithValue("@studentId", student_id.Text.Trim());
                                cmd.Parameters.AddWithValue("@subjectId", subject_id.Text.Trim());
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
                            gradeDisplayData();
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

        private void search_btn_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text.Trim();

            try
            {
                // Mở kết nối
                connect.Open();

                //Tạo câu truy vấn SQL
                string query = @"
                    SELECT student_id, subject_id, grade
                    FROM grade
                    WHERE student_id LIKE @searchValue
                        OR grade LIKE @searchValue
                        OR subject_id LIKE @searchValue";
                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    grade_gridData.DataSource = dt;
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
    }
}
