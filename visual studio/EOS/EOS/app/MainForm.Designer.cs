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
            this.settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountMenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.signedInAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchAccountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showCalendarMenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.taskListMenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSubjectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newTaskToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syncToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syncToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getHelpOnlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gettingStartedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseNotesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
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
            this.settingsMenuItem,
            this.accountMenuButton,
            this.showCalendarMenuButton,
            this.taskListMenuButton});
            this.menuStrip1.Location = new System.Drawing.Point(0, 24);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(735, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsMenuItem
            // 
            this.settingsMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.settingsMenuItem.Image = global::EOS.Properties.Resources.icon_34727;
            this.settingsMenuItem.Name = "settingsMenuItem";
            this.settingsMenuItem.Size = new System.Drawing.Size(77, 20);
            this.settingsMenuItem.Text = "Settings";
            this.settingsMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.settingsMenuItem.Click += new System.EventHandler(this.settingsMenuItem_Click);
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
            this.logInToolStripMenuItem.Click += new System.EventHandler(this.logInToolStripMenuItem_Click);
            // 
            // registerToolStripMenuItem
            // 
            this.registerToolStripMenuItem.Name = "registerToolStripMenuItem";
            this.registerToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.registerToolStripMenuItem.Text = "Register";
            this.registerToolStripMenuItem.Click += new System.EventHandler(this.registerToolStripMenuItem_Click);
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
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
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
            // menuStrip2
            // 
            this.menuStrip2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuStrip2.BackgroundImage")));
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.syncToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(735, 24);
            this.menuStrip2.TabIndex = 2;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSubjectToolStripMenuItem1,
            this.newTaskToolStripMenuItem1,
            this.toolStripSeparator6,
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.toolStripSeparator5,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newSubjectToolStripMenuItem1
            // 
            this.newSubjectToolStripMenuItem1.Name = "newSubjectToolStripMenuItem1";
            this.newSubjectToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newSubjectToolStripMenuItem1.Size = new System.Drawing.Size(200, 22);
            this.newSubjectToolStripMenuItem1.Text = "New Subject";
            // 
            // newTaskToolStripMenuItem1
            // 
            this.newTaskToolStripMenuItem1.Name = "newTaskToolStripMenuItem1";
            this.newTaskToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
            this.newTaskToolStripMenuItem1.Size = new System.Drawing.Size(200, 22);
            this.newTaskToolStripMenuItem1.Text = "New Task";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(197, 6);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(197, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator4,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(141, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // syncToolStripMenuItem
            // 
            this.syncToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.syncToolStripMenuItem1});
            this.syncToolStripMenuItem.Name = "syncToolStripMenuItem";
            this.syncToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.syncToolStripMenuItem.Text = "Tools";
            // 
            // syncToolStripMenuItem1
            // 
            this.syncToolStripMenuItem1.Name = "syncToolStripMenuItem1";
            this.syncToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.syncToolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
            this.syncToolStripMenuItem1.Text = "Sync";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getHelpOnlineToolStripMenuItem,
            this.gettingStartedToolStripMenuItem,
            this.toolStripSeparator2,
            this.checkForUpdatesToolStripMenuItem,
            this.releaseNotesToolStripMenuItem,
            this.toolStripSeparator1,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // getHelpOnlineToolStripMenuItem
            // 
            this.getHelpOnlineToolStripMenuItem.Name = "getHelpOnlineToolStripMenuItem";
            this.getHelpOnlineToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.getHelpOnlineToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.getHelpOnlineToolStripMenuItem.Text = "Get Help Online";
            // 
            // gettingStartedToolStripMenuItem
            // 
            this.gettingStartedToolStripMenuItem.Name = "gettingStartedToolStripMenuItem";
            this.gettingStartedToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.gettingStartedToolStripMenuItem.Text = "Getting Started";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(174, 6);
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.checkForUpdatesToolStripMenuItem.Text = "Check for Updates";
            // 
            // releaseNotesToolStripMenuItem
            // 
            this.releaseNotesToolStripMenuItem.Name = "releaseNotesToolStripMenuItem";
            this.releaseNotesToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.releaseNotesToolStripMenuItem.Text = "Release Notes";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(174, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 506);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EOS — Not logged in";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.VisibleChanged += new System.EventHandler(this.MainForm_VisibleChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem settingsMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getHelpOnlineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gettingStartedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releaseNotesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem syncToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem syncToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newSubjectToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newTaskToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}