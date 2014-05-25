using EOS.app.drawing;
using EOS.user;
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
            canvas = new Canvas();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e) {
            renderThread = new Thread(new ThreadStart(render));
            renderThread.Start();
        }

        private void render() {
            long renderTime;
            long sleepFor;
            Graphics g = CreateGraphics();

            while (this.Visible) {
                renderTime = 0;
                canvas.render(g);
                renderTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

                sleepFor = (long) Math.Max(((1 / 60f) * 1000) - renderTime, 0); // milliseconds per frame @ 60 FPS

                Thread.Sleep((int) sleepFor);
            }

            g.Dispose();
        }
    }
}
