using EOS.utility;
using EOS.user;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EOS.app;
using Eos.Enteprise;

namespace EOS {
    public partial class LoginForm : Form {

        #region Data

        private ApplicationContext context;

        #endregion

        #region Constructor

        public LoginForm(ApplicationContext context) {
            InitializeComponent();
            this.context = context;
        }

        #endregion

        #region Login

        private void loginButton_Click(object sender, EventArgs e) {
            string username = usernameTextBox.Text;
            string hashedPassword = passwordTextBox.Text;

            if (hasErrors()) {
                return;
            }

            hashedPassword = SecurityHelper.hash(hashedPassword);

            tryLogin(username, hashedPassword);
        }

        private void tryLogin(string username, string hashedPassword) {
            // Sends to server, checks data, gets result
            bool success = false; //loginUser(username, hashedPassword);
            UserService service = new UserService();
            UserTO user = service.authenticateUser(username, hashedPassword);
            if (user != null) {
                success = true;
            }

            if (!success) {
                MessageBox.Show("Incorrect username or password. Please try again.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CurrentUser.getInstance().setUser(usernameTextBox.Text, true);
            launch();
        }

        #endregion

        #region Validating

        private bool hasErrors() {
            errorProvider1.SetError(usernameTextBox, "");
            errorProvider1.SetError(passwordTextBox, "");

            if (String.IsNullOrEmpty(usernameTextBox.Text)) {
                errorProvider1.SetError(usernameTextBox, "This field is required.");
            }

            if (String.IsNullOrEmpty(passwordTextBox.Text)) {
                errorProvider1.SetError(passwordTextBox, "This field is required.");
            }

            if (errorProvider1.GetError(usernameTextBox) != String.Empty) {
                return true;
            }
            if (errorProvider1.GetError(passwordTextBox) != String.Empty) {
                return true;
            }

            return false;
        }

        private void usernameTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            errorProvider1.SetError(usernameTextBox, "");
        }

        private void passwordTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            errorProvider1.SetError(passwordTextBox, "");
        }

        #endregion

        #region Create a new account

        private void newAccountButton_Click(object sender, EventArgs e) {
            this.Hide();
            DialogResult dr = ((Program)context).accountCreationForm.ShowDialog();

            if (dr == DialogResult.OK) {
                launch();
            } else {
                this.Show();
            }
        }

        #endregion

        #region Continue offline

        private void continueOfflineButton_Click(object sender, EventArgs e) {
            CurrentUser.getInstance().setUser(usernameTextBox.Text, false);
            launch();
        }

        #endregion

        private void launch() {
            this.Hide();
            ((Program) context).mainForm.Show();
        }

        #region Exit

        private void exitButton_Click(object sender, EventArgs e) {
            context.ExitThread();
        }

        #endregion

    }
}
