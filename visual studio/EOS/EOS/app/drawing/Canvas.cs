using System;
using System.Collections.Generic;
using System.Drawing;
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
            SolidBrush brush = new SolidBrush(Color.Red);
            g.FillRectangle(brush, new Rectangle(0, 0, 200, 300));
            brush.Dispose();
        }
    }
}
