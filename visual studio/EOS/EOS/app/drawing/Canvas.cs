using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOS.app.drawing {
    class Canvas {
        #region Data

        private readonly MainForm mainForm;

        #endregion

        #region Constructor

        public Canvas(MainForm mainForm) {
            this.mainForm = mainForm;
        }

        #endregion

        public void render(Graphics g) {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            SolidBrush brush = new SolidBrush(Color.FromArgb(120, 200, 200));
            g.DrawEllipse(new Pen(brush), halfWidth() - 25, halfHeight() - 25, 50, 50);
            brush.Dispose();
        }

        private int halfWidth() {
            return mainForm.Width / 2;
        }

        private int halfHeight() {
            return mainForm.Height / 2;
        }
    }
}
