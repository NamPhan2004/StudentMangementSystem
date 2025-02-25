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
using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;


namespace SchoolMangementSystem
{
    public partial class Home : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=NAMPHAN\MAY1;Initial Catalog=StudentManagementSystem;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        public Home()
        {
            InitializeComponent();
            displayTotalES();
            displayTotalTC();
            displayTotalTS();
            displayClassid();
        }

        private void DrawLineChart()
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=NAMPHAN\MAY1;Initial Catalog=StudentManagementSystem;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
            {
                string query = @"
                    SELECT s.student_name, AVG(g.grade) AS average_grade
                    FROM students s
                    JOIN grade g ON s.student_id = g.student_id
                    WHERE s.class_id = @classId
                    GROUP BY s.student_name
                ";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@classId", class_id.Text.Trim());

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                // Dữ liệu biểu đồ
                ChartValues<double> averages = new ChartValues<double>();
                string[] studentNames = new string[dt.Rows.Count];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    studentNames[i] = dt.Rows[i]["student_name"].ToString();
                    averages.Add(Convert.ToDouble(dt.Rows[i]["average_grade"]));
                }

                // Thiết lập biểu đồ
                cartesianChart1.Series = new SeriesCollection
                {
                    new ColumnSeries
                    {
                        Title = "Điểm Trung Bình",
                        Values = averages
                    }
                };

                cartesianChart1.AxisX.Clear();
                cartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis
                {
                    Title = "Học Sinh",
                    Labels = studentNames
                });

                cartesianChart1.AxisY.Clear();
                cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
                {
                    Title = "Điểm Trung Bình",
                    LabelFormatter = value => value.ToString("N2")
                });
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
        public void displayTotalES()
        {
            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();
                    string selectData = "SELECT count(*) FROM students ";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        int tempES = 0;
                        if (reader.Read())
                        {
                            tempES = Convert.ToInt32(reader[0]);

                            total_ES.Text = tempES.ToString();
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error to connect Database: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    connect.Close();
                }
            }
        }

        public void displayTotalTC()
        {
            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();
                    string selectData = "SELECT count(*) FROM class ";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        int tempTC = 0;
                        if (reader.Read())
                        {
                            tempTC = Convert.ToInt32(reader[0]);

                            total_TC.Text = tempTC.ToString();
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error to connect Database: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    connect.Close();
                }
            }
        }

        public void displayTotalTS()
        {
            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();
                    string selectData = "SELECT count(*) FROM subjects";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        int tempTS = 0;
                        if (reader.Read())
                        {
                            tempTS = Convert.ToInt32(reader[0]);

                            total_TS.Text = tempTS.ToString();
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error to connect Database: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    connect.Close();
                }
            }
        }
        private void total_ES_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void display_btn_Click(object sender, EventArgs e)
        {
            DrawLineChart();
        }
    }
}
