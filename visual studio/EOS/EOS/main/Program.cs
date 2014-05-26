using EOS.app;
using EOS.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EOS {
    class Program : ApplicationContext {
        public MainForm mainForm;
        public LoginForm loginForm;
        public AccountCreationForm accountCreationForm;

        private Program() {
            mainForm = new MainForm(this);
            loginForm = new LoginForm(this);

            accountCreationForm = new AccountCreationForm();

            if (!FileHelper.isUserLoggedIn()) {
                loginForm.Show();
            } else {
                mainForm.Show();
            }
        }

        [STAThread]
        public static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Program());
        }
    }
}
