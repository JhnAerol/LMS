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
            this.lblName = new System.Windows.Forms.Label();
            this.sidebar = new System.Windows.Forms.FlowLayoutPanel();
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSidebar = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.sidebar.SuspendLayout();
            this.TeacherBar.SuspendLayout();
            this.StudentBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSidebar)).BeginInit();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(56, 11);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(191, 22);
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
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1102, 43);
            this.panel1.TabIndex = 12;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblName.Font = new System.Drawing.Font("Lucida Sans", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(1039, 0);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Padding = new System.Windows.Forms.Padding(0, 13, 10, 0);
            this.lblName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblName.Size = new System.Drawing.Size(63, 30);
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
            this.sidebar.Location = new System.Drawing.Point(0, 43);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(214, 648);
            this.sidebar.TabIndex = 13;
            // 
            // btnStatistics
            // 
            this.btnStatistics.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnStatistics.Location = new System.Drawing.Point(3, 152);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(211, 41);
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
            this.TeacherBar.Location = new System.Drawing.Point(2, 198);
            this.TeacherBar.Margin = new System.Windows.Forms.Padding(2);
            this.TeacherBar.Name = "TeacherBar";
            this.TeacherBar.Size = new System.Drawing.Size(211, 41);
            this.TeacherBar.TabIndex = 17;
            // 
            // btnTeacherList
            // 
            this.btnTeacherList.Location = new System.Drawing.Point(0, 84);
            this.btnTeacherList.Name = "btnTeacherList";
            this.btnTeacherList.Size = new System.Drawing.Size(211, 41);
            this.btnTeacherList.TabIndex = 17;
            this.btnTeacherList.Text = "Teacher List";
            this.btnTeacherList.UseVisualStyleBackColor = true;
            this.btnTeacherList.Click += new System.EventHandler(this.btnTeacherList_Click);
            // 
            // btnTeacherBar
            // 
            this.btnTeacherBar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnTeacherBar.Location = new System.Drawing.Point(0, 2);
            this.btnTeacherBar.Name = "btnTeacherBar";
            this.btnTeacherBar.Size = new System.Drawing.Size(211, 41);
            this.btnTeacherBar.TabIndex = 15;
            this.btnTeacherBar.Text = "Teachers";
            this.btnTeacherBar.UseVisualStyleBackColor = false;
            this.btnTeacherBar.Click += new System.EventHandler(this.btnTeacherBar_Click);
            // 
            // btnAddTeacher
            // 
            this.btnAddTeacher.Location = new System.Drawing.Point(0, 43);
            this.btnAddTeacher.Name = "btnAddTeacher";
            this.btnAddTeacher.Size = new System.Drawing.Size(211, 41);
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
            this.StudentBar.Location = new System.Drawing.Point(2, 243);
            this.StudentBar.Margin = new System.Windows.Forms.Padding(2);
            this.StudentBar.Name = "StudentBar";
            this.StudentBar.Size = new System.Drawing.Size(211, 41);
            this.StudentBar.TabIndex = 15;
            // 
            // btnStudentList
            // 
            this.btnStudentList.Location = new System.Drawing.Point(0, 84);
            this.btnStudentList.Name = "btnStudentList";
            this.btnStudentList.Size = new System.Drawing.Size(211, 41);
            this.btnStudentList.TabIndex = 17;
            this.btnStudentList.Text = "Student List";
            this.btnStudentList.UseVisualStyleBackColor = true;
            this.btnStudentList.Click += new System.EventHandler(this.btnStudentList_Click);
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.Location = new System.Drawing.Point(0, 43);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(211, 41);
            this.btnAddStudent.TabIndex = 16;
            this.btnAddStudent.Text = "Add Student";
            this.btnAddStudent.UseVisualStyleBackColor = true;
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // btnStudentBar
            // 
            this.btnStudentBar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnStudentBar.Location = new System.Drawing.Point(0, 2);
            this.btnStudentBar.Name = "btnStudentBar";
            this.btnStudentBar.Size = new System.Drawing.Size(211, 41);
            this.btnStudentBar.TabIndex = 15;
            this.btnStudentBar.Text = "Students";
            this.btnStudentBar.UseVisualStyleBackColor = false;
            this.btnStudentBar.Click += new System.EventHandler(this.btnStudentBar_Click);
            // 
            // btnSubjects
            // 
            this.btnSubjects.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSubjects.Location = new System.Drawing.Point(3, 289);
            this.btnSubjects.Name = "btnSubjects";
            this.btnSubjects.Size = new System.Drawing.Size(211, 41);
            this.btnSubjects.TabIndex = 17;
            this.btnSubjects.Text = "View Subjects";
            this.btnSubjects.UseVisualStyleBackColor = false;
            this.btnSubjects.Click += new System.EventHandler(this.btnSubjects_Click);
            // 
            // btnLogs
            // 
            this.btnLogs.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLogs.Location = new System.Drawing.Point(3, 336);
            this.btnLogs.Name = "btnLogs";
            this.btnLogs.Size = new System.Drawing.Size(211, 41);
            this.btnLogs.TabIndex = 20;
            this.btnLogs.Text = "Logs";
            this.btnLogs.UseVisualStyleBackColor = false;
            this.btnLogs.Click += new System.EventHandler(this.btnLogs_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLogout.Location = new System.Drawing.Point(3, 383);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(211, 41);
            this.btnLogout.TabIndex = 21;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
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
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::RegistrationForm.Properties.Resources.pic1;
            this.pictureBox1.Location = new System.Drawing.Point(57, 30);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(57, 30, 3, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 87);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnSidebar
            // 
            this.btnSidebar.Image = global::RegistrationForm.Properties.Resources.burger_bar;
            this.btnSidebar.Location = new System.Drawing.Point(11, 5);
            this.btnSidebar.Name = "btnSidebar";
            this.btnSidebar.Size = new System.Drawing.Size(39, 34);
            this.btnSidebar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSidebar.TabIndex = 8;
            this.btnSidebar.TabStop = false;
            this.btnSidebar.Click += new System.EventHandler(this.btnSidebar_Click);
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1102, 691);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminDashboard";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.sidebar.ResumeLayout(false);
            this.TeacherBar.ResumeLayout(false);
            this.StudentBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSidebar)).EndInit();
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