using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;

namespace SchoolMangementSystem
{
    public partial class DetailSubForm : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=NAMPHAN\MAY1;Initial Catalog=StudentManagementSystem;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        public DetailSubForm()
        {
            InitializeComponent();
            detailSubjectDisplayData();
            displayClassid();
            displaySubjectid();
        }

        public void detailSubjectDisplayData()
        {
            try
            {
                connect.Open();
                string sql = "SELECT * FROM detail_sub";

                using (SqlCommand cmd = new SqlCommand(sql, connect))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    da.Fill(table);
                    detailSubject_gridData.DataSource = table;
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
            term.Text = "";
            txtSearch.Text = "";
        }
        static bool CheckSjIdExists(string subjectid, string classid, string connectionString)
        {
            string query = "SELECT COUNT(*) FROM detail_sub WHERE class_id = @classid AND subject_id = @subjectid";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@subjectid", subjectid);
                command.Parameters.AddWithValue("@classid", classid);

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
            string subIdToCheck = subject_id.Text;
            string classIdToCheck = class_id.Text;
            string connectionString = "Data Source=NAMPHAN\\MAY1;Initial Catalog=StudentManagementSystem;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            bool isIdTaken = CheckSjIdExists(subIdToCheck, classIdToCheck, connectionString);
            if (
                 class_id.Text == ""
                || term.Text == ""
                || subject_id.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string input = term.Text.Trim();
                if (!int.TryParse(input, out int result))
                {
                    MessageBox.Show("Kì học không phải là số nguyên!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connect.Close();
                    return;
                }
                if (connect.State != ConnectionState.Open)
                {
                    try
                    {
                        connect.Open();
                        string insertData = "INSERT INTO detail_sub (class_id" +
                            ", term, subject_id) VALUES(@classId, @term, @subjectId)";

                        using (SqlCommand cmd = new SqlCommand(insertData, connect))
                        {
                            cmd.Parameters.AddWithValue("@classId", class_id.Text.Trim());
                            cmd.Parameters.AddWithValue("@term", int.Parse(term.Text));
                            cmd.Parameters.AddWithValue("@subjectId", subject_id.Text.Trim());
                            int ky = int.Parse(term.Text);
                            if (ky <= 0)
                            {
                                MessageBox.Show("Kỳ học phải lớn hơn 0.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                connect.Close();
                                return;
                            }
                            if (isIdTaken)
                            {
                                MessageBox.Show("Lớp này đã học môn này rồi.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                connect.Close();
                                return;
                            }
                            
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Add successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            connect.Close();
                            detailSubjectDisplayData();
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

        private void detailSubject_gridData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = detailSubject_gridData.Rows[e.RowIndex];
                class_id.Text = row.Cells[0].Value.ToString();
                term.Text = row.Cells[1].Value.ToString();
                subject_id.Text = row.Cells[2].Value.ToString();

            }
        }

        private void class_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
            detailSubjectDisplayData();
        }

        private void class_deleteBtn_Click(object sender, EventArgs e)
        {
            if (term.Text == "")
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
                            string deleteData = "DELETE detail_sub WHERE class_id = @classID AND term = @term AND subject_id = @subjectId";

                            using (SqlCommand cmd = new SqlCommand(deleteData, connect))
                            {
                                cmd.Parameters.AddWithValue("@classId", class_id.Text.Trim());
                                cmd.Parameters.AddWithValue("@term", int.Parse(term.Text));
                                cmd.Parameters.AddWithValue("@subjectId", subject_id.Text.Trim());
                                //cmd.Parameters.AddWithValue("@curClassId", curClass_id.Text.Trim());
                                //cmd.Parameters.AddWithValue("@curTerm", int.Parse(curTerm.Text));
                                //cmd.Parameters.AddWithValue("@curSubjectId", curSubject_id.Text.Trim());
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
                            detailSubjectDisplayData();
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
                    SELECT class_id, term, subject_id
                    FROM detail_sub
                    WHERE class_id LIKE @searchValue
                        OR term LIKE @searchValue
                        OR subject_id LIKE @searchValue";
                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    detailSubject_gridData.DataSource = dt;
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
