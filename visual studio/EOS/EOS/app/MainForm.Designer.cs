namespace EOS.app {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newSubjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.accountMenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.signedInAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchAccountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showCalendarMenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.taskListMenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSubjectToolStripMenuItem,
            this.newTaskToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(141, 48);
            // 
            // newSubjectToolStripMenuItem
            // 
            this.newSubjectToolStripMenuItem.Name = "newSubjectToolStripMenuItem";
            this.newSubjectToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.newSubjectToolStripMenuItem.Text = "New Subject";
            // 
            // newTaskToolStripMenuItem
            // 
            this.newTaskToolStripMenuItem.Name = "newTaskToolStripMenuItem";
            this.newTaskToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.newTaskToolStripMenuItem.Text = "New Task";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuStrip1.BackgroundImage")));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountMenuButton,
            this.showCalendarMenuButton,
            this.taskListMenuButton});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(735, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // accountMenuButton
            // 
            this.accountMenuButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.accountMenuButton.BackgroundImage = global::EOS.Properties.Resources.icon_24643;
            this.accountMenuButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.signedInAsToolStripMenuItem,
            this.logInToolStripMenuItem,
            this.registerToolStripMenuItem,
            this.switchAccountsToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.accountMenuButton.Image = global::EOS.Properties.Resources.icon_24643;
            this.accountMenuButton.Name = "accountMenuButton";
            this.accountMenuButton.Size = new System.Drawing.Size(80, 20);
            this.accountMenuButton.Text = "Account";
            this.accountMenuButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.accountMenuButton.ToolTipText = "Account Management";
            // 
            // signedInAsToolStripMenuItem
            // 
            this.signedInAsToolStripMenuItem.Name = "signedInAsToolStripMenuItem";
            this.signedInAsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.signedInAsToolStripMenuItem.Text = "Signed in as ";
            // 
            // logInToolStripMenuItem
            // 
            this.logInToolStripMenuItem.Name = "logInToolStripMenuItem";
            this.logInToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.logInToolStripMenuItem.Text = "Log in";
            // 
            // registerToolStripMenuItem
            // 
            this.registerToolStripMenuItem.Name = "registerToolStripMenuItem";
            this.registerToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.registerToolStripMenuItem.Text = "Register";
            // 
            // switchAccountsToolStripMenuItem
            // 
            this.switchAccountsToolStripMenuItem.Name = "switchAccountsToolStripMenuItem";
            this.switchAccountsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.switchAccountsToolStripMenuItem.Text = "Switch Accounts";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.logOutToolStripMenuItem.Text = "Log out";
            // 
            // showCalendarMenuButton
            // 
            this.showCalendarMenuButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.showCalendarMenuButton.Image = global::EOS.Properties.Resources.icon_28854;
            this.showCalendarMenuButton.Name = "showCalendarMenuButton";
            this.showCalendarMenuButton.Size = new System.Drawing.Size(110, 20);
            this.showCalendarMenuButton.Text = "Calendar View";
            this.showCalendarMenuButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.showCalendarMenuButton.ToolTipText = "Show Calendar View";
            // 
            // taskListMenuButton
            // 
            this.taskListMenuButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.taskListMenuButton.Image = global::EOS.Properties.Resources.icon_4202;
            this.taskListMenuButton.Name = "taskListMenuButton";
            this.taskListMenuButton.Size = new System.Drawing.Size(87, 20);
            this.taskListMenuButton.Text = "Task View";
            this.taskListMenuButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.taskListMenuButton.ToolTipText = "Show Task List";
            this.taskListMenuButton.Click += new System.EventHandler(this.taskListMenuButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 506);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EOS — Not logged in";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newSubjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newTaskToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem accountMenuButton;
        private System.Windows.Forms.ToolStripMenuItem showCalendarMenuButton;
        private System.Windows.Forms.ToolStripMenuItem taskListMenuButton;
        private System.Windows.Forms.ToolStripMenuItem signedInAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem switchAccountsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registerToolStripMenuItem;
    }
}