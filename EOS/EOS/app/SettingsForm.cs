using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EOS.app {
    public partial class SettingsForm : Form {

        #region Data

        private bool changesMade;

        #endregion

        #region Constructor

        public SettingsForm() {
            InitializeComponent();
        }

        #endregion

        #region Button clicks

        private void cancelButton_Click(object sender, EventArgs e) {
            this.Dispose();
        }

        #endregion

    }
}
