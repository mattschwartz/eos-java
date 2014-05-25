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

        public MainForm() {
            InitializeComponent();
            this.Text = "EOS — " + CurrentUser.getInstance().username;
            canvas = new Canvas(this);
        }

        private void MainForm_Paint(object sender, PaintEventArgs e) {
            renderThread = new Thread(new ThreadStart(render));
            renderThread.Start();
        }

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
