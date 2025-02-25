
namespace SchoolMangementSystem
{
    partial class DetailSubForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.subject_id = new System.Windows.Forms.ComboBox();
            this.class_id = new System.Windows.Forms.ComboBox();
            this.class_deleteBtn = new System.Windows.Forms.Button();
            this.class_clearBtn = new System.Windows.Forms.Button();
            this.class_addBtn = new System.Windows.Forms.Button();
            this.term = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.detailSubject_gridData = new System.Windows.Forms.DataGridView();
            this.search_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailSubject_gridData)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.subject_id);
            this.panel2.Controls.Add(this.class_id);
            this.panel2.Controls.Add(this.class_deleteBtn);
            this.panel2.Controls.Add(this.class_clearBtn);
            this.panel2.Controls.Add(this.class_addBtn);
            this.panel2.Controls.Add(this.term);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(16, 403);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1134, 281);
            this.panel2.TabIndex = 7;
            // 
            // subject_id
            // 
            this.subject_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subject_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subject_id.FormattingEnabled = true;
            this.subject_id.Location = new System.Drawing.Point(871, 103);
            this.subject_id.Margin = new System.Windows.Forms.Padding(4);
            this.subject_id.Name = "subject_id";
            this.subject_id.Size = new System.Drawing.Size(161, 24);
            this.subject_id.TabIndex = 26;
            // 
            // class_id
            // 
            this.class_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.class_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.class_id.FormattingEnabled = true;
            this.class_id.Location = new System.Drawing.Point(151, 103);
            this.class_id.Margin = new System.Windows.Forms.Padding(4);
            this.class_id.Name = "class_id";
            this.class_id.Size = new System.Drawing.Size(161, 24);
            this.class_id.TabIndex = 25;
            // 
            // class_deleteBtn
            // 
            this.class_deleteBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(180)))), ((int)(((byte)(139)))));
            this.class_deleteBtn.FlatAppearance.BorderSize = 0;
            this.class_deleteBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(192)))), ((int)(((byte)(140)))));
            this.class_deleteBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(192)))), ((int)(((byte)(140)))));
            this.class_deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.class_deleteBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.class_deleteBtn.ForeColor = System.Drawing.Color.White;
            this.class_deleteBtn.Location = new System.Drawing.Point(676, 214);
            this.class_deleteBtn.Margin = new System.Windows.Forms.Padding(4);
            this.class_deleteBtn.Name = "class_deleteBtn";
            this.class_deleteBtn.Size = new System.Drawing.Size(136, 43);
            this.class_deleteBtn.TabIndex = 17;
            this.class_deleteBtn.Text = "Delete";
            this.class_deleteBtn.UseVisualStyleBackColor = false;
            this.class_deleteBtn.Click += new System.EventHandler(this.class_deleteBtn_Click);
            // 
            // class_clearBtn
            // 
            this.class_clearBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(180)))), ((int)(((byte)(139)))));
            this.class_clearBtn.FlatAppearance.BorderSize = 0;
            this.class_clearBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(192)))), ((int)(((byte)(140)))));
            this.class_clearBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(192)))), ((int)(((byte)(140)))));
            this.class_clearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.class_clearBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.class_clearBtn.ForeColor = System.Drawing.Color.White;
            this.class_clearBtn.Location = new System.Drawing.Point(508, 214);
            this.class_clearBtn.Margin = new System.Windows.Forms.Padding(4);
            this.class_clearBtn.Name = "class_clearBtn";
            this.class_clearBtn.Size = new System.Drawing.Size(136, 43);
            this.class_clearBtn.TabIndex = 16;
            this.class_clearBtn.Text = "Clear";
            this.class_clearBtn.UseVisualStyleBackColor = false;
            this.class_clearBtn.Click += new System.EventHandler(this.class_clearBtn_Click);
            // 
            // class_addBtn
            // 
            this.class_addBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(180)))), ((int)(((byte)(139)))));
            this.class_addBtn.FlatAppearance.BorderSize = 0;
            this.class_addBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(192)))), ((int)(((byte)(140)))));
            this.class_addBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(192)))), ((int)(((byte)(140)))));
            this.class_addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.class_addBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.class_addBtn.ForeColor = System.Drawing.Color.White;
            this.class_addBtn.Location = new System.Drawing.Point(340, 214);
            this.class_addBtn.Margin = new System.Windows.Forms.Padding(4);
            this.class_addBtn.Name = "class_addBtn";
            this.class_addBtn.Size = new System.Drawing.Size(136, 43);
            this.class_addBtn.TabIndex = 14;
            this.class_addBtn.Text = "Add";
            this.class_addBtn.UseVisualStyleBackColor = false;
            this.class_addBtn.Click += new System.EventHandler(this.class_addBtn_Click);
            // 
            // term
            // 
            this.term.Location = new System.Drawing.Point(484, 97);
            this.term.Margin = new System.Windows.Forms.Padding(4);
            this.term.Multiline = true;
            this.term.Name = "term";
            this.term.Size = new System.Drawing.Size(191, 30);
            this.term.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(794, 106);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Subject Id:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(434, 106);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Term:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 106);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Class ID:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.detailSubject_gridData);
            this.panel1.Controls.Add(this.search_btn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(16, 25);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1134, 356);
            this.panel1.TabIndex = 6;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(859, 20);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(191, 30);
            this.txtSearch.TabIndex = 28;
            // 
            // detailSubject_gridData
            // 
            this.detailSubject_gridData.AllowUserToAddRows = false;
            this.detailSubject_gridData.AllowUserToDeleteRows = false;
            this.detailSubject_gridData.AllowUserToResizeRows = false;
            this.detailSubject_gridData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.detailSubject_gridData.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.detailSubject_gridData.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(167)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(167)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.detailSubject_gridData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.detailSubject_gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(167)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.detailSubject_gridData.DefaultCellStyle = dataGridViewCellStyle2;
            this.detailSubject_gridData.EnableHeadersVisualStyles = false;
            this.detailSubject_gridData.Location = new System.Drawing.Point(27, 58);
            this.detailSubject_gridData.Margin = new System.Windows.Forms.Padding(4);
            this.detailSubject_gridData.Name = "detailSubject_gridData";
            this.detailSubject_gridData.ReadOnly = true;
            this.detailSubject_gridData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.detailSubject_gridData.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.detailSubject_gridData.RowHeadersVisible = false;
            this.detailSubject_gridData.RowHeadersWidth = 51;
            this.detailSubject_gridData.Size = new System.Drawing.Size(1080, 276);
            this.detailSubject_gridData.TabIndex = 1;
            this.detailSubject_gridData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.detailSubject_gridData_CellClick);
            // 
            // search_btn
            // 
            this.search_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(180)))), ((int)(((byte)(139)))));
            this.search_btn.FlatAppearance.BorderSize = 0;
            this.search_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(192)))), ((int)(((byte)(140)))));
            this.search_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(192)))), ((int)(((byte)(140)))));
            this.search_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.search_btn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_btn.ForeColor = System.Drawing.Color.White;
            this.search_btn.Location = new System.Drawing.Point(734, 18);
            this.search_btn.Margin = new System.Windows.Forms.Padding(4);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(117, 32);
            this.search_btn.TabIndex = 29;
            this.search_btn.Text = "Search";
            this.search_btn.UseVisualStyleBackColor = false;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Detail Subject\'s Data";
            // 
            // DetailSubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(167)))), ((int)(((byte)(146)))));
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DetailSubForm";
            this.Size = new System.Drawing.Size(1167, 708);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailSubject_gridData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button class_deleteBtn;
        private System.Windows.Forms.Button class_clearBtn;
        private System.Windows.Forms.Button class_addBtn;
        private System.Windows.Forms.TextBox term;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView detailSubject_gridData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox subject_id;
        private System.Windows.Forms.ComboBox class_id;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button search_btn;
    }
}
