namespace RegistrationForm
{
    partial class AdminDashboard
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
            this.components = new System.ComponentModel.Container();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSidebar = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.sidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.TeacherBar = new System.Windows.Forms.Panel();
            this.btnTeacherList = new System.Windows.Forms.Button();
            this.btnTeacherBar = new System.Windows.Forms.Button();
            this.btnAddTeacher = new System.Windows.Forms.Button();
            this.StudentBar = new System.Windows.Forms.Panel();
            this.btnStudentList = new System.Windows.Forms.Button();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.btnStudentBar = new System.Windows.Forms.Button();
            this.btnSubjects = new System.Windows.Forms.Button();
            this.btnLogs = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSidebar)).BeginInit();
            this.sidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.TeacherBar.SuspendLayout();
            this.StudentBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(75, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(233, 27);
            this.label12.TabIndex = 7;
            this.label12.Text = "Admin Dashboard";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Controls.Add(this.btnSidebar);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1469, 53);
            this.panel1.TabIndex = 12;
            // 
            // btnSidebar
            // 
            this.btnSidebar.Image = global::RegistrationForm.Properties.Resources.burger_bar;
            this.btnSidebar.Location = new System.Drawing.Point(15, 6);
            this.btnSidebar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSidebar.Name = "btnSidebar";
            this.btnSidebar.Size = new System.Drawing.Size(52, 42);
            this.btnSidebar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSidebar.TabIndex = 8;
            this.btnSidebar.TabStop = false;
            this.btnSidebar.Click += new System.EventHandler(this.btnSidebar_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblName.Font = new System.Drawing.Font("Lucida Sans", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(1391, 0);
            this.lblName.Name = "lblName";
            this.lblName.Padding = new System.Windows.Forms.Padding(0, 16, 13, 0);
            this.lblName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblName.Size = new System.Drawing.Size(78, 37);
            this.lblName.TabIndex = 15;
            this.lblName.Text = "label1";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.sidebar.Controls.Add(this.pictureBox1);
            this.sidebar.Controls.Add(this.btnStatistics);
            this.sidebar.Controls.Add(this.TeacherBar);
            this.sidebar.Controls.Add(this.StudentBar);
            this.sidebar.Controls.Add(this.btnSubjects);
            this.sidebar.Controls.Add(this.btnLogs);
            this.sidebar.Controls.Add(this.btnLogout);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(0, 53);
            this.sidebar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(285, 797);
            this.sidebar.TabIndex = 13;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::RegistrationForm.Properties.Resources.pic1;
            this.pictureBox1.Location = new System.Drawing.Point(76, 37);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(76, 37, 4, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 107);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnStatistics
            // 
            this.btnStatistics.BackColor = System.Drawing.Color.White;
            this.btnStatistics.FlatAppearance.BorderSize = 0;
            this.btnStatistics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatistics.Font = new System.Drawing.Font("Lucida Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatistics.ForeColor = System.Drawing.Color.Black;
            this.btnStatistics.Location = new System.Drawing.Point(18, 187);
            this.btnStatistics.Margin = new System.Windows.Forms.Padding(18, 4, 4, 4);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(250, 50);
            this.btnStatistics.TabIndex = 18;
            this.btnStatistics.Text = "Statistics";
            this.btnStatistics.UseVisualStyleBackColor = false;
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // TeacherBar
            // 
            this.TeacherBar.Controls.Add(this.btnTeacherList);
            this.TeacherBar.Controls.Add(this.btnTeacherBar);
            this.TeacherBar.Controls.Add(this.btnAddTeacher);
            this.TeacherBar.Location = new System.Drawing.Point(18, 243);
            this.TeacherBar.Margin = new System.Windows.Forms.Padding(18, 2, 3, 2);
            this.TeacherBar.Name = "TeacherBar";
            this.TeacherBar.Size = new System.Drawing.Size(250, 50);
            this.TeacherBar.TabIndex = 17;
            // 
            // btnTeacherList
            // 
            this.btnTeacherList.Location = new System.Drawing.Point(0, 103);
            this.btnTeacherList.Margin = new System.Windows.Forms.Padding(18, 4, 4, 4);
            this.btnTeacherList.Name = "btnTeacherList";
            this.btnTeacherList.Size = new System.Drawing.Size(250, 50);
            this.btnTeacherList.TabIndex = 17;
            this.btnTeacherList.Text = "Teacher List";
            this.btnTeacherList.UseVisualStyleBackColor = true;
            this.btnTeacherList.Click += new System.EventHandler(this.btnTeacherList_Click);
            // 
            // btnTeacherBar
            // 
            this.btnTeacherBar.BackColor = System.Drawing.Color.White;
            this.btnTeacherBar.FlatAppearance.BorderSize = 0;
            this.btnTeacherBar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTeacherBar.Font = new System.Drawing.Font("Lucida Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeacherBar.ForeColor = System.Drawing.Color.Black;
            this.btnTeacherBar.Location = new System.Drawing.Point(0, 2);
            this.btnTeacherBar.Margin = new System.Windows.Forms.Padding(18, 4, 4, 4);
            this.btnTeacherBar.Name = "btnTeacherBar";
            this.btnTeacherBar.Size = new System.Drawing.Size(250, 50);
            this.btnTeacherBar.TabIndex = 15;
            this.btnTeacherBar.Text = "Teachers";
            this.btnTeacherBar.UseVisualStyleBackColor = false;
            this.btnTeacherBar.Click += new System.EventHandler(this.btnTeacherBar_Click);
            // 
            // btnAddTeacher
            // 
            this.btnAddTeacher.Location = new System.Drawing.Point(0, 53);
            this.btnAddTeacher.Margin = new System.Windows.Forms.Padding(18, 4, 4, 4);
            this.btnAddTeacher.Name = "btnAddTeacher";
            this.btnAddTeacher.Size = new System.Drawing.Size(250, 50);
            this.btnAddTeacher.TabIndex = 16;
            this.btnAddTeacher.Text = "Add Teacher";
            this.btnAddTeacher.UseVisualStyleBackColor = true;
            this.btnAddTeacher.Click += new System.EventHandler(this.btnAddTeacher_Click);
            // 
            // StudentBar
            // 
            this.StudentBar.Controls.Add(this.btnStudentList);
            this.StudentBar.Controls.Add(this.btnAddStudent);
            this.StudentBar.Controls.Add(this.btnStudentBar);
            this.StudentBar.Location = new System.Drawing.Point(18, 297);
            this.StudentBar.Margin = new System.Windows.Forms.Padding(18, 2, 3, 2);
            this.StudentBar.Name = "StudentBar";
            this.StudentBar.Size = new System.Drawing.Size(250, 50);
            this.StudentBar.TabIndex = 15;
            // 
            // btnStudentList
            // 
            this.btnStudentList.Location = new System.Drawing.Point(0, 103);
            this.btnStudentList.Margin = new System.Windows.Forms.Padding(18, 4, 4, 4);
            this.btnStudentList.Name = "btnStudentList";
            this.btnStudentList.Size = new System.Drawing.Size(250, 50);
            this.btnStudentList.TabIndex = 17;
            this.btnStudentList.Text = "Student List";
            this.btnStudentList.UseVisualStyleBackColor = true;
            this.btnStudentList.Click += new System.EventHandler(this.btnStudentList_Click);
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.Location = new System.Drawing.Point(0, 53);
            this.btnAddStudent.Margin = new System.Windows.Forms.Padding(18, 4, 4, 4);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(250, 50);
            this.btnAddStudent.TabIndex = 16;
            this.btnAddStudent.Text = "Add Student";
            this.btnAddStudent.UseVisualStyleBackColor = true;
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // btnStudentBar
            // 
            this.btnStudentBar.BackColor = System.Drawing.Color.White;
            this.btnStudentBar.FlatAppearance.BorderSize = 0;
            this.btnStudentBar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudentBar.Font = new System.Drawing.Font("Lucida Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudentBar.ForeColor = System.Drawing.Color.Black;
            this.btnStudentBar.Location = new System.Drawing.Point(0, 2);
            this.btnStudentBar.Margin = new System.Windows.Forms.Padding(18, 4, 4, 4);
            this.btnStudentBar.Name = "btnStudentBar";
            this.btnStudentBar.Size = new System.Drawing.Size(250, 50);
            this.btnStudentBar.TabIndex = 15;
            this.btnStudentBar.Text = "Students";
            this.btnStudentBar.UseVisualStyleBackColor = false;
            this.btnStudentBar.Click += new System.EventHandler(this.btnStudentBar_Click);
            // 
            // btnSubjects
            // 
            this.btnSubjects.BackColor = System.Drawing.Color.White;
            this.btnSubjects.FlatAppearance.BorderSize = 0;
            this.btnSubjects.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubjects.Font = new System.Drawing.Font("Lucida Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubjects.ForeColor = System.Drawing.Color.Black;
            this.btnSubjects.Location = new System.Drawing.Point(18, 353);
            this.btnSubjects.Margin = new System.Windows.Forms.Padding(18, 4, 4, 4);
            this.btnSubjects.Name = "btnSubjects";
            this.btnSubjects.Size = new System.Drawing.Size(250, 50);
            this.btnSubjects.TabIndex = 17;
            this.btnSubjects.Text = "View Subjects";
            this.btnSubjects.UseVisualStyleBackColor = false;
            this.btnSubjects.Click += new System.EventHandler(this.btnSubjects_Click);
            // 
            // btnLogs
            // 
            this.btnLogs.BackColor = System.Drawing.Color.White;
            this.btnLogs.FlatAppearance.BorderSize = 0;
            this.btnLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogs.Font = new System.Drawing.Font("Lucida Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogs.ForeColor = System.Drawing.Color.Black;
            this.btnLogs.Location = new System.Drawing.Point(18, 411);
            this.btnLogs.Margin = new System.Windows.Forms.Padding(18, 4, 4, 4);
            this.btnLogs.Name = "btnLogs";
            this.btnLogs.Size = new System.Drawing.Size(250, 50);
            this.btnLogs.TabIndex = 20;
            this.btnLogs.Text = "Logs";
            this.btnLogs.UseVisualStyleBackColor = false;
            this.btnLogs.Click += new System.EventHandler(this.btnLogs_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.White;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Lucida Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.Black;
            this.btnLogout.Location = new System.Drawing.Point(18, 469);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(18, 4, 4, 4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(250, 50);
            this.btnLogout.TabIndex = 21;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 10;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 10;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1469, 850);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminDashboard";
            this.Shown += new System.EventHandler(this.AdminDashboard_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSidebar)).EndInit();
            this.sidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.TeacherBar.ResumeLayout(false);
            this.StudentBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox btnSidebar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel sidebar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnStudentBar;
        private System.Windows.Forms.Button btnStatistics;
        private System.Windows.Forms.Button btnAddTeacher;
        private System.Windows.Forms.Button btnSubjects;
        private System.Windows.Forms.Button btnLogs;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel StudentBar;
        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.Button btnStudentList;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel TeacherBar;
        private System.Windows.Forms.Button btnTeacherList;
        private System.Windows.Forms.Button btnTeacherBar;
        private System.Windows.Forms.Timer timer3;
        public System.Windows.Forms.Label lblName;
    }
}