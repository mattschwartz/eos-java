using EOS.app.drawing;
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

        private Thread renderThread;
        private Canvas canvas;

        #endregion

        #region Constructor

        public MainForm() {
            InitializeComponent();
            this.Text = "EOS — " + CurrentUser.getInstance().username;
            setMenuItems(CurrentUser.getInstance().online);
            canvas = new Canvas(this);
        }

        #endregion

        #region Set visibility of menu items

        private void setMenuItems(bool online) {
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

        #region Menu buttons clicked

        private void taskListMenuButton_Click(object sender, EventArgs e) {
            Console.WriteLine("Showing task list now");
        }

        #endregion

        #region Rendering method

        private void MainForm_Paint(object sender, PaintEventArgs e) {
            Graphics g = CreateGraphics();
            g.Clear(BackColor);
            canvas.render(g);
        }

        #endregion

        // ♬♪ look at this code ♬♪
        // ♬♪ this code is amazing ♬♪
        // ♬♪ give it a call ♬♪
        // cuz it don't do shit right now...
        // @deprecated
        private void render() {
            long start;
            long end;
            long renderTime;
            long sleepFor;
            Graphics g = CreateGraphics();

            while (this.Visible) {
                start = TimeHelper.Now();
                canvas.render(g);
                end = TimeHelper.Now();

                renderTime = end - start;

                sleepFor = (long) Math.Max(TimeHelper.MILLISECONDS_PER_FRAME - renderTime, 0); // milliseconds per frame @ 60 FPS

                Thread.Sleep((int) sleepFor);
            }

            g.Dispose();
        }
    }
}
