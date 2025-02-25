
namespace SchoolMangementSystem
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.Grade_btn = new System.Windows.Forms.Button();
            this.Subject_btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.AddClass_btn = new System.Windows.Forms.Button();
            this.AddStudent_btn = new System.Windows.Forms.Button();
            this.Detailsub_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.addClassForm1 = new SchoolMangementSystem.AddClassForm();
            this.subjectForm1 = new SchoolMangementSystem.SubjectForm();
            this.detailSubForm1 = new SchoolMangementSystem.DetailSubForm();
            this.addStudentForm2 = new SchoolMangementSystem.AddStudentForm();
            this.gradeForm1 = new SchoolMangementSystem.GradeForm();
            this.home1 = new SchoolMangementSystem.Home();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1100, 25);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1080, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "X";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Student Management System | Main Form";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(167)))), ((int)(((byte)(146)))));
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.Grade_btn);
            this.panel2.Controls.Add(this.Subject_btn);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.AddClass_btn);
            this.panel2.Controls.Add(this.AddStudent_btn);
            this.panel2.Controls.Add(this.Detailsub_btn);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(225, 575);
            this.panel2.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(192)))), ((int)(((byte)(140)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(192)))), ((int)(((byte)(140)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::SchoolMangementSystem.Properties.Resources.icons8_dashboard_35px_1;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(10, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 40);
            this.button1.TabIndex = 9;
            this.button1.Text = "Home";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Grade_btn
            // 
            this.Grade_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Grade_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(192)))), ((int)(((byte)(140)))));
            this.Grade_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(192)))), ((int)(((byte)(140)))));
            this.Grade_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Grade_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grade_btn.ForeColor = System.Drawing.Color.White;
            this.Grade_btn.Image = global::SchoolMangementSystem.Properties.Resources.icons8_student_35px;
            this.Grade_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Grade_btn.Location = new System.Drawing.Point(10, 396);
            this.Grade_btn.Name = "Grade_btn";
            this.Grade_btn.Size = new System.Drawing.Size(200, 40);
            this.Grade_btn.TabIndex = 8;
            this.Grade_btn.Text = "Grade";
            this.Grade_btn.UseVisualStyleBackColor = true;
            this.Grade_btn.Click += new System.EventHandler(this.Grade_btn_Click);
            // 
            // Subject_btn
            // 
            this.Subject_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Subject_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(192)))), ((int)(((byte)(140)))));
            this.Subject_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(192)))), ((int)(((byte)(140)))));
            this.Subject_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Subject_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Subject_btn.ForeColor = System.Drawing.Color.White;
            this.Subject_btn.Image = global::SchoolMangementSystem.Properties.Resources.icons8_student_35px;
            this.Subject_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Subject_btn.Location = new System.Drawing.Point(10, 350);
            this.Subject_btn.Name = "Subject_btn";
            this.Subject_btn.Size = new System.Drawing.Size(200, 40);
            this.Subject_btn.TabIndex = 7;
            this.Subject_btn.Text = "Subject";
            this.Subject_btn.UseVisualStyleBackColor = true;
            this.Subject_btn.Click += new System.EventHandler(this.Subject_btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(54, 539);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Logout";
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Image = global::SchoolMangementSystem.Properties.Resources.icons8_logout_rounded_up_filled_35px;
            this.button3.Location = new System.Drawing.Point(6, 523);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 40);
            this.button3.TabIndex = 5;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // AddClass_btn
            // 
            this.AddClass_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddClass_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(192)))), ((int)(((byte)(140)))));
            this.AddClass_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(192)))), ((int)(((byte)(140)))));
            this.AddClass_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddClass_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddClass_btn.ForeColor = System.Drawing.Color.White;
            this.AddClass_btn.Image = global::SchoolMangementSystem.Properties.Resources.icons8_training_35px;
            this.AddClass_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddClass_btn.Location = new System.Drawing.Point(10, 258);
            this.AddClass_btn.Name = "AddClass_btn";
            this.AddClass_btn.Size = new System.Drawing.Size(200, 40);
            this.AddClass_btn.TabIndex = 4;
            this.AddClass_btn.Text = "Class";
            this.AddClass_btn.UseVisualStyleBackColor = true;
            this.AddClass_btn.Click += new System.EventHandler(this.button4_Click);
            // 
            // AddStudent_btn
            // 
            this.AddStudent_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddStudent_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(192)))), ((int)(((byte)(140)))));
            this.AddStudent_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(192)))), ((int)(((byte)(140)))));
            this.AddStudent_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddStudent_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddStudent_btn.ForeColor = System.Drawing.Color.White;
            this.AddStudent_btn.Image = global::SchoolMangementSystem.Properties.Resources.icons8_student_35px;
            this.AddStudent_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddStudent_btn.Location = new System.Drawing.Point(10, 211);
            this.AddStudent_btn.Name = "AddStudent_btn";
            this.AddStudent_btn.Size = new System.Drawing.Size(200, 40);
            this.AddStudent_btn.TabIndex = 3;
            this.AddStudent_btn.Text = "Students";
            this.AddStudent_btn.UseVisualStyleBackColor = true;
            this.AddStudent_btn.Click += new System.EventHandler(this.AddStudent_btn_Click);
            // 
            // Detailsub_btn
            // 
            this.Detailsub_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Detailsub_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(192)))), ((int)(((byte)(140)))));
            this.Detailsub_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(192)))), ((int)(((byte)(140)))));
            this.Detailsub_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Detailsub_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Detailsub_btn.ForeColor = System.Drawing.Color.White;
            this.Detailsub_btn.Image = global::SchoolMangementSystem.Properties.Resources.icons8_training_35px;
            this.Detailsub_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Detailsub_btn.Location = new System.Drawing.Point(10, 304);
            this.Detailsub_btn.Name = "Detailsub_btn";
            this.Detailsub_btn.Size = new System.Drawing.Size(200, 40);
            this.Detailsub_btn.TabIndex = 2;
            this.Detailsub_btn.Text = "Detail Subject";
            this.Detailsub_btn.UseVisualStyleBackColor = true;
            this.Detailsub_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(50, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome, Admin";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SchoolMangementSystem.Properties.Resources.icons8_School_80px_1;
            this.pictureBox1.Location = new System.Drawing.Point(82, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.home1);
            this.panel3.Controls.Add(this.gradeForm1);
            this.panel3.Controls.Add(this.addStudentForm2);
            this.panel3.Controls.Add(this.detailSubForm1);
            this.panel3.Controls.Add(this.subjectForm1);
            this.panel3.Controls.Add(this.addClassForm1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(225, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(875, 575);
            this.panel3.TabIndex = 2;
            // 
            // addClassForm1
            // 
            this.addClassForm1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(167)))), ((int)(((byte)(146)))));
            this.addClassForm1.Location = new System.Drawing.Point(0, 0);
            this.addClassForm1.Name = "addClassForm1";
            this.addClassForm1.Size = new System.Drawing.Size(875, 575);
            this.addClassForm1.TabIndex = 0;
            // 
            // subjectForm1
            // 
            this.subjectForm1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(167)))), ((int)(((byte)(146)))));
            this.subjectForm1.Location = new System.Drawing.Point(0, 0);
            this.subjectForm1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.subjectForm1.Name = "subjectForm1";
            this.subjectForm1.Size = new System.Drawing.Size(875, 575);
            this.subjectForm1.TabIndex = 1;
            // 
            // detailSubForm1
            // 
            this.detailSubForm1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(167)))), ((int)(((byte)(146)))));
            this.detailSubForm1.Location = new System.Drawing.Point(0, 0);
            this.detailSubForm1.Name = "detailSubForm1";
            this.detailSubForm1.Size = new System.Drawing.Size(875, 575);
            this.detailSubForm1.TabIndex = 2;
            // 
            // addStudentForm2
            // 
            this.addStudentForm2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(167)))), ((int)(((byte)(146)))));
            this.addStudentForm2.Location = new System.Drawing.Point(0, 0);
            this.addStudentForm2.Name = "addStudentForm2";
            this.addStudentForm2.Size = new System.Drawing.Size(875, 575);
            this.addStudentForm2.TabIndex = 3;
            // 
            // gradeForm1
            // 
            this.gradeForm1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(167)))), ((int)(((byte)(146)))));
            this.gradeForm1.Location = new System.Drawing.Point(0, 0);
            this.gradeForm1.Margin = new System.Windows.Forms.Padding(2);
            this.gradeForm1.Name = "gradeForm1";
            this.gradeForm1.Size = new System.Drawing.Size(875, 575);
            this.gradeForm1.TabIndex = 4;
            // 
            // home1
            // 
            this.home1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(167)))), ((int)(((byte)(146)))));
            this.home1.Location = new System.Drawing.Point(0, 0);
            this.home1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.home1.Name = "home1";
            this.home1.Size = new System.Drawing.Size(875, 575);
            this.home1.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 600);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button AddClass_btn;
        private System.Windows.Forms.Button AddStudent_btn;
        private System.Windows.Forms.Button Detailsub_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private AddClassForm addTeachersForm1;
        private System.Windows.Forms.Button Subject_btn;
        private System.Windows.Forms.Button Grade_btn;
        private System.Windows.Forms.Button button1;
        private AddStudentForm addStudentForm1;
        private System.Windows.Forms.Panel panel3;
        private Home home1;
        private GradeForm gradeForm1;
        private AddStudentForm addStudentForm2;
        private DetailSubForm detailSubForm1;
        private SubjectForm subjectForm1;
        private AddClassForm addClassForm1;
    }
}