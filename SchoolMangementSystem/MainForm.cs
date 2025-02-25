using System;
using System.Windows.Forms;

namespace SchoolMangementSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {   
            detailSubForm1.Visible = false;
            addStudentForm2.Visible = false;
            addClassForm1.Visible = true;
            addClassForm1.Update();
            subjectForm1.Visible = false;
            gradeForm1.Visible = false;
            home1.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                LoginForm lForm = new LoginForm();
                lForm.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            detailSubForm1.Visible = true;
            addClassForm1.Visible = false;
            addStudentForm2.Visible = false;
            subjectForm1.Visible = false;
            gradeForm1.Visible = false;
            home1.Visible = false;
        }

        private void AddStudent_btn_Click(object sender, EventArgs e)
        {
            addStudentForm2.Visible = true;
            addClassForm1.Visible = false;
            detailSubForm1.Visible = false;
            addStudentForm2.Update();
            addStudentForm2.displayClassid();
            subjectForm1.Visible = false;
            gradeForm1.Visible = false;
            home1.Visible = false;
        }

        private void Subject_btn_Click(object sender, EventArgs e)
        {
            addStudentForm2.Visible = false;
            addClassForm1.Visible = false;
            detailSubForm1.Visible = false;
            addStudentForm2.Update();
            subjectForm1.Visible = true;
            gradeForm1.Visible = false;
            home1.Visible = false;
        }

        private void Grade_btn_Click(object sender, EventArgs e)
        {
            addStudentForm2.Visible = false;
            addClassForm1.Visible = false;
            detailSubForm1.Visible = false;
            subjectForm1.Visible = false;
            gradeForm1.Visible = true;
            home1.Visible = false;
            gradeForm1.Update();
            gradeForm1.displayStudentid();
            gradeForm1.displaySubjectid();
        }

        private void gradeForm1_Load(object sender, EventArgs e)
        {

        }

        private void subjectForm1_Load(object sender, EventArgs e)
        {

        }

        private void detailSubForm1_Load(object sender, EventArgs e)
        {

        }

        private void addStudentForm1_Load(object sender, EventArgs e)
        {

        }

        private void addClassForm1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            addStudentForm2.Visible = false;
            addClassForm1.Visible = false;
            detailSubForm1.Visible = false;
            subjectForm1.Visible = false;
            gradeForm1.Visible = false;
            home1.Visible = true;
        }
    }
}
