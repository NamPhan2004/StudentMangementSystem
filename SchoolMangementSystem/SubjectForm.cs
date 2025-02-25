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
    public partial class SubjectForm : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=NAMPHAN\MAY1;Initial Catalog=StudentManagementSystem;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        public SubjectForm()
        {
            InitializeComponent();
            subjectDisplayData();
        }

        public void subjectDisplayData()
        {
            try
            {
                connect.Open();
                string sql = "SELECT * FROM subjects";

                using (SqlCommand cmd = new SqlCommand(sql, connect))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    da.Fill(table);
                    subject_gridData.DataSource = table;
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

        public int GetId()
        {
            int x = 0;
            try
            {
                connect.Open();
                string getId = "select max(subject_id) from subjects";

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
        static bool CheckIfIdExists(string subjectid, string connectionString)
        {
            string query = "SELECT COUNT(*) FROM subjects WHERE subject_id = @subjectid";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@subjectid", subjectid);

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
        private void class_addBtn_Click(object sender, EventArgs e)
        {
            string IdToCheck = subject_id.Text;
            string connectionString = "Data Source=NAMPHAN\\MAY1;Initial Catalog=StudentManagementSystem;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            bool isIdTaken = CheckIfIdExists(IdToCheck, connectionString);
            if (isIdTaken)
            {
                MessageBox.Show("Đã có id này rồi.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connect.Close();
                return;
            }
            if (
                 subject_name.Text == ""
                || theory.Text == ""
                || practice.Text == "")
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
                        string insertData = "INSERT INTO subjects (subject_id, subject_name" +
                            ", theory, practice) VALUES(@subjectId, @subjectName, @theory, @practice)";

                        using (SqlCommand cmd = new SqlCommand(insertData, connect))
                        {
                            cmd.Parameters.AddWithValue("@subjectId", int.Parse(subject_id.Text));
                            cmd.Parameters.AddWithValue("@subjectName", subject_name.Text.Trim());
                            cmd.Parameters.AddWithValue("@theory", int.Parse(theory.Text));
                            cmd.Parameters.AddWithValue("@practice", int.Parse(practice.Text));
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Add successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            connect.Close();
                            subjectDisplayData();
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
        public void clearFields()
        {
            subject_name.Text = "";
            theory.Text = "";
            practice.Text = "";
            txtSearch.Text = "";
            subject_id.Text = "";
        }

        private void class_updateBtn_Click(object sender, EventArgs e)
        {
            if (
                 subject_name.Text == ""
                || theory.Text == ""
                || practice.Text == "")
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
                            String updateData = "UPDATE subjects SET subject_name = @subjectName, " +
                                "theory = @theory, practice = @practice WHERE subject_id = @subjectID";

                            using (SqlCommand cmd = new SqlCommand(updateData, connect))
                            {
                                cmd.Parameters.AddWithValue("@subjectId", int.Parse(subject_id.Text));
                                cmd.Parameters.AddWithValue("@subjectName", subject_name.Text.Trim());
                                cmd.Parameters.AddWithValue("@theory", int.Parse(theory.Text));
                                cmd.Parameters.AddWithValue("@practice", int.Parse(practice.Text));
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Updated successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                connect.Close();
                                subjectDisplayData();
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

        private void subject_gridData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = subject_gridData.Rows[e.RowIndex];
                subject_id.Text = row.Cells[0].Value.ToString();
                subject_name.Text = row.Cells[1].Value.ToString();
                theory.Text = row.Cells[2].Value.ToString();
                practice.Text = row.Cells[3].Value.ToString();
            }
        }
        private void class_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
            subjectDisplayData();
        }

        private void class_deleteBtn_Click(object sender, EventArgs e)
        {
            if (
                 subject_id.Text == "")
            {
                MessageBox.Show("Please select item first", "Error Message"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State != ConnectionState.Open)
                {
                    DialogResult check = MessageBox.Show("Are you sure you want to Delete Subject ID: "
                        + subject_id.Text + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (check == DialogResult.Yes)
                    {

                        try
                        {
                            connect.Open();
                            string deleteData = "Delete subjects WHERE subject_id = @subjectID";

                            using (SqlCommand cmd = new SqlCommand(deleteData, connect))
                            {
                                cmd.Parameters.AddWithValue("@subjectID", subject_id.Text.Trim());

                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Deleted successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error  connecting Database: " + ex, "Error Message"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            connect.Close();
                            subjectDisplayData();
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
                    SELECT subject_id, subject_name, theory, practice
                    FROM subjects
                    WHERE subject_id LIKE @searchValue
                        OR subject_name LIKE @searchValue";
                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    subject_gridData.DataSource = dt;
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
