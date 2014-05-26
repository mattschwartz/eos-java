using EOS.app.drawing;
using EOS.Properties;
using EOS.user;
using EOS.utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EOS.app {
    public partial class MainForm : Form {

        #region Data

        private Canvas canvas;
        private ApplicationContext context;

        #endregion

        #region Constructor

        public MainForm(ApplicationContext context) {
            InitializeComponent();
            canvas = new Canvas(this);
            this.context = context;
            this.Shown += MainForm_Shown;
        }

        #region When form is shown

        private void MainForm_Shown(object sender, EventArgs e) {
        }

        #endregion

        #endregion

        #region Set visibility of menu items

        private void setMenuItems(bool online) {
            this.Text = "EOS — " + CurrentUser.getInstance().username;

            if (!online) {
                this.switchAccountsToolStripMenuItem.Visible = false;
                this.logOutToolStripMenuItem.Visible = false;

                this.logInToolStripMenuItem.Visible = true;
                this.registerToolStripMenuItem.Visible = true;
                this.signedInAsToolStripMenuItem.Text = "Not logged in";
                this.signedInAsToolStripMenuItem.Enabled = false;
            } else {
                this.switchAccountsToolStripMenuItem.Visible = true;
                this.logOutToolStripMenuItem.Visible = true;

                this.logInToolStripMenuItem.Visible = false;
                this.registerToolStripMenuItem.Visible = false;
                this.signedInAsToolStripMenuItem.Text = "Signed in as " + CurrentUser.getInstance().username;
                this.signedInAsToolStripMenuItem.Enabled = true;
            }
        }

        #endregion

        #region Rendering method

        private void MainForm_Paint(object sender, PaintEventArgs e) {
            Graphics g = CreateGraphics();
            g.Clear(BackColor);
            canvas.render(g);
        }

        #endregion

        #region Toolstrip buttons clicked

        #region Task List button

        private void taskListMenuButton_Click(object sender, EventArgs e) {
        }

        #endregion

        #region Log-in button

        private void logInToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Hide();
            ((Program) context).loginForm.ShowDialog();
            this.Show();
        }

        #endregion

        #region Register button

        private void registerToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Hide();
            ((Program) context).accountCreationForm.ShowDialog();
            this.Show();
        }

        #endregion

        #region Log out button

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e) {
            DialogResult dr = DialogResult.Yes;

            if (Settings.Default.perform_logout_check) {
                dr = MessageBox.Show("Sync changes and log out?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            if (dr == DialogResult.Yes) {
                this.Hide();
                dr = ((Program) context).loginForm.ShowDialog();

                if (dr == DialogResult.Abort) {
                    Application.Exit();
                }

                this.Show();
            } 
        }

        #endregion

        #region Settings button

        private void settingsMenuItem_Click(object sender, EventArgs e) {
            DialogResult dr = new SettingsForm().ShowDialog();

            if (dr == DialogResult.OK) {

            }
        }

        #endregion

        #endregion

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
            context.ExitThread();
        }

        private void MainForm_VisibleChanged(object sender, EventArgs e) {
            if (Visible) {
                setMenuItems(CurrentUser.getInstance().online);
            }
        }

    }
}
