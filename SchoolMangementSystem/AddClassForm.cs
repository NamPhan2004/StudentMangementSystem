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
using System.IO;
using System.Runtime.Remoting.Contexts;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SchoolMangementSystem
{
    public partial class AddClassForm : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=NAMPHAN\MAY1;Initial Catalog=StudentManagementSystem;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        public AddClassForm()
        {
            InitializeComponent();
            classDisplayData();
        }

        

        public void classDisplayData()
        {
            try
            {
                connect.Open();

                string sql = "SELECT * FROM class";

                using (SqlCommand cmd = new SqlCommand(sql, connect))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    da.Fill(table);
                    class_gridData.DataSource = table;
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
                string getId = "select max(class_id) from class";

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
        static bool CheckIfIdExists(string classid, string connectionString)
        {
            string query = "SELECT COUNT(*) FROM class WHERE class_id = @classid";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
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
            string IdToCheck = class_id.Text;
            string connectionString = "Data Source=NAMPHAN\\MAY1;Initial Catalog=StudentManagementSystem;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            bool isIdTaken = CheckIfIdExists(IdToCheck, connectionString);
            if (isIdTaken)
            {
                MessageBox.Show("Đã có id này rồi.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connect.Close();
                return;
            }
            if (
                 class_name.Text == ""
                || class_id.Text == ""
                || teacher_name.Text == "")
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
                        string insertData = "INSERT INTO class (class_id, class_name" +
                            ", teacher) VALUES(@classId, @className, @teacher)";

                        using (SqlCommand cmd = new SqlCommand(insertData, connect))
                        {
                            cmd.Parameters.AddWithValue("@classId", int.Parse(class_id.Text));
                            cmd.Parameters.AddWithValue("@className", class_name.Text.Trim());
                            cmd.Parameters.AddWithValue("@teacher", teacher_name.Text.Trim());
                            
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Add successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            connect.Close();
                            classDisplayData();
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
            class_name.Text = "";
            teacher_name.Text = "";
            txtSearch.Text = "";
            class_id.Text = "";
        }

        private void class_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
            classDisplayData();
        }

        private void class_updateBtn_Click(object sender, EventArgs e)
        {
            if (
                 class_name.Text == ""
                || teacher_name.Text == "")
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
                            String updateData = "UPDATE class SET class_name = @className, " +
                                "teacher = @teacher WHERE class_id = @classID";


                            using (SqlCommand cmd = new SqlCommand(updateData, connect))
                            {
                                cmd.Parameters.AddWithValue("classId", class_id.Text.Trim());
                                cmd.Parameters.AddWithValue("@className", class_name.Text.Trim());
                                cmd.Parameters.AddWithValue("@teacher", teacher_name.Text.Trim());
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Updated successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                connect.Close();
                                classDisplayData();
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

        private void class_gridData_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                DataGridViewRow row = class_gridData.Rows[e.RowIndex];
                class_id.Text = row.Cells[0].Value.ToString();
                class_name.Text = row.Cells[1].Value.ToString();
                teacher_name.Text = row.Cells[2].Value.ToString();
            }

        }

        private void class_deleteBtn_Click(object sender, EventArgs e)
        {
            if (class_id.Text == "")
            {
                MessageBox.Show("Please select item first", "Error Message"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State != ConnectionState.Open)
                {
                    DialogResult check = MessageBox.Show("Are you sure you want to Delete Teacher ID: "
                        + class_id.Text + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (check == DialogResult.Yes)
                    {

                        try
                        {
                            connect.Open();
                            string deleteData = "Delete class WHERE class_id = @classID";

                            using (SqlCommand cmd = new SqlCommand(deleteData, connect))
                            {
                                cmd.Parameters.AddWithValue("@classID", class_id.Text.Trim());

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
                            classDisplayData();
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
                    SELECT class_id, class_name, teacher
                    FROM class
                    WHERE class_name LIKE @searchValue
                        OR class_id LIKE @searchValue
                        OR teacher LIKE @searchValue";
                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    class_gridData.DataSource = dt;
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
