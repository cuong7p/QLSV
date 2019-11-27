namespace Login_
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sTUDENTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewStudentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editRemoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mannageStudentFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOURSEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCourseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageCourseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sCOREToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rmoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.avgScoreByCourseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sTUDENTToolStripMenuItem,
            this.cOURSEToolStripMenuItem,
            this.sCOREToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1175, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // sTUDENTToolStripMenuItem
            // 
            this.sTUDENTToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.sTUDENTToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewStudentToolStripMenuItem,
            this.studentListToolStripMenuItem,
            this.staticsToolStripMenuItem,
            this.editRemoveToolStripMenuItem,
            this.mannageStudentFormToolStripMenuItem,
            this.printToolStripMenuItem});
            this.sTUDENTToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sTUDENTToolStripMenuItem.Name = "sTUDENTToolStripMenuItem";
            this.sTUDENTToolStripMenuItem.Size = new System.Drawing.Size(91, 24);
            this.sTUDENTToolStripMenuItem.Text = "STUDENT";
            // 
            // addNewStudentToolStripMenuItem
            // 
            this.addNewStudentToolStripMenuItem.BackColor = System.Drawing.Color.BlueViolet;
            this.addNewStudentToolStripMenuItem.Name = "addNewStudentToolStripMenuItem";
            this.addNewStudentToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.addNewStudentToolStripMenuItem.Text = "Add New Student";
            this.addNewStudentToolStripMenuItem.Click += new System.EventHandler(this.addNewStudentToolStripMenuItem_Click);
            // 
            // studentListToolStripMenuItem
            // 
            this.studentListToolStripMenuItem.BackColor = System.Drawing.Color.BlueViolet;
            this.studentListToolStripMenuItem.Name = "studentListToolStripMenuItem";
            this.studentListToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.studentListToolStripMenuItem.Text = "Student List";
            this.studentListToolStripMenuItem.Click += new System.EventHandler(this.studentListToolStripMenuItem_Click);
            // 
            // staticsToolStripMenuItem
            // 
            this.staticsToolStripMenuItem.BackColor = System.Drawing.Color.BlueViolet;
            this.staticsToolStripMenuItem.Name = "staticsToolStripMenuItem";
            this.staticsToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.staticsToolStripMenuItem.Text = "Statics";
            this.staticsToolStripMenuItem.Click += new System.EventHandler(this.staticsToolStripMenuItem_Click);
            // 
            // editRemoveToolStripMenuItem
            // 
            this.editRemoveToolStripMenuItem.BackColor = System.Drawing.Color.BlueViolet;
            this.editRemoveToolStripMenuItem.Name = "editRemoveToolStripMenuItem";
            this.editRemoveToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.editRemoveToolStripMenuItem.Text = "Edit/Remove";
            this.editRemoveToolStripMenuItem.Click += new System.EventHandler(this.editRemoveToolStripMenuItem_Click);
            // 
            // mannageStudentFormToolStripMenuItem
            // 
            this.mannageStudentFormToolStripMenuItem.BackColor = System.Drawing.Color.BlueViolet;
            this.mannageStudentFormToolStripMenuItem.Name = "mannageStudentFormToolStripMenuItem";
            this.mannageStudentFormToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.mannageStudentFormToolStripMenuItem.Text = "Mannage Student Form";
            this.mannageStudentFormToolStripMenuItem.Click += new System.EventHandler(this.mannageStudentFormToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.BackColor = System.Drawing.Color.BlueViolet;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // cOURSEToolStripMenuItem
            // 
            this.cOURSEToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.cOURSEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCourseToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.editToolStripMenuItem,
            this.manageCourseToolStripMenuItem,
            this.printToolStripMenuItem1});
            this.cOURSEToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cOURSEToolStripMenuItem.Name = "cOURSEToolStripMenuItem";
            this.cOURSEToolStripMenuItem.Size = new System.Drawing.Size(80, 24);
            this.cOURSEToolStripMenuItem.Text = "COURSE";
            this.cOURSEToolStripMenuItem.Click += new System.EventHandler(this.cOURSEToolStripMenuItem_Click);
            // 
            // addCourseToolStripMenuItem
            // 
            this.addCourseToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.addCourseToolStripMenuItem.Name = "addCourseToolStripMenuItem";
            this.addCourseToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.addCourseToolStripMenuItem.Text = "Add Course";
            this.addCourseToolStripMenuItem.Click += new System.EventHandler(this.addCourseToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // manageCourseToolStripMenuItem
            // 
            this.manageCourseToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.manageCourseToolStripMenuItem.Name = "manageCourseToolStripMenuItem";
            this.manageCourseToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.manageCourseToolStripMenuItem.Text = "Manage Course";
            this.manageCourseToolStripMenuItem.Click += new System.EventHandler(this.manageCourseToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem1
            // 
            this.printToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.printToolStripMenuItem1.Name = "printToolStripMenuItem1";
            this.printToolStripMenuItem1.Size = new System.Drawing.Size(200, 26);
            this.printToolStripMenuItem1.Text = "Print";
            this.printToolStripMenuItem1.Click += new System.EventHandler(this.printToolStripMenuItem1_Click);
            // 
            // sCOREToolStripMenuItem
            // 
            this.sCOREToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.sCOREToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.rmoveToolStripMenuItem,
            this.mangeToolStripMenuItem,
            this.avgScoreByCourseToolStripMenuItem});
            this.sCOREToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sCOREToolStripMenuItem.Name = "sCOREToolStripMenuItem";
            this.sCOREToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.sCOREToolStripMenuItem.Text = "SCORE";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.BackColor = System.Drawing.Color.Gray;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // rmoveToolStripMenuItem
            // 
            this.rmoveToolStripMenuItem.BackColor = System.Drawing.Color.Gray;
            this.rmoveToolStripMenuItem.Name = "rmoveToolStripMenuItem";
            this.rmoveToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.rmoveToolStripMenuItem.Text = "Remove";
            this.rmoveToolStripMenuItem.Click += new System.EventHandler(this.rmoveToolStripMenuItem_Click);
            // 
            // mangeToolStripMenuItem
            // 
            this.mangeToolStripMenuItem.BackColor = System.Drawing.Color.Gray;
            this.mangeToolStripMenuItem.Name = "mangeToolStripMenuItem";
            this.mangeToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.mangeToolStripMenuItem.Text = "Mange";
            this.mangeToolStripMenuItem.Click += new System.EventHandler(this.mangeToolStripMenuItem_Click);
            // 
            // avgScoreByCourseToolStripMenuItem
            // 
            this.avgScoreByCourseToolStripMenuItem.BackColor = System.Drawing.Color.Gray;
            this.avgScoreByCourseToolStripMenuItem.Name = "avgScoreByCourseToolStripMenuItem";
            this.avgScoreByCourseToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.avgScoreByCourseToolStripMenuItem.Text = "Avg Score By Course ";
            this.avgScoreByCourseToolStripMenuItem.Click += new System.EventHandler(this.avgScoreByCourseToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1175, 563);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sTUDENTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewStudentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem staticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editRemoveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mannageStudentFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOURSEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sCOREToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCourseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageCourseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rmoveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem avgScoreByCourseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
    }
}