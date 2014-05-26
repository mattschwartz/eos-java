using EOS.user;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EOS.app {
    public partial class AccountCreationForm : Form {

        #region Constructor

        public AccountCreationForm() {
            InitializeComponent();
        }

        #endregion

        #region Button clicks

        private void cancelButton_Click(object sender, EventArgs e) {
            this.Dispose();
        }

        private void registerButton_Click(object sender, EventArgs e) {
            if (hasErrors()) {
                return;
            }

            MessageBox.Show("Your account was created successfully!\n\n"
                          + "Please validate your account by checking your email. You will now be logged in.", 
                            "Account Created", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CurrentUser.getInstance().setUser(usernameTextBox.Text, true);
            this.DialogResult = DialogResult.OK;
        }

        #endregion

        #region Validate text fields & set errors

        private bool hasErrors() {
            if (!validateRequiredFields()) {
                return true;
            }

            if (!validateEmail()) {
                return true;
            }

            if (!validateUsername()) {
                return true;
            }

            return false;
        }

        #region Validate required fields

        private bool validateRequiredFields() {
            errorProvider1.SetError(usernameTextBox, "");
            errorProvider1.SetError(passwordTextBox, "");
            errorProvider1.SetError(usernameTextBox, "");

            if (String.IsNullOrEmpty(usernameTextBox.Text)) {
                errorProvider1.SetError(usernameTextBox, "This field is required.");
            }

            if (String.IsNullOrEmpty(passwordTextBox.Text)) {
                errorProvider1.SetError(passwordTextBox, "This field is required.");
            }

            if (String.IsNullOrEmpty(emailTextBox.Text)) {
                errorProvider1.SetError(emailTextBox, "This field is required.");
            }

            foreach (Control c in Controls) {
                if (errorProvider1.GetError(c) != String.Empty) {
                    return false;
                }
            }

            return true;
        }

        private void emailTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            errorProvider1.SetError(emailTextBox, "");
        }

        private void usernameTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            errorProvider1.SetError(usernameTextBox, "");
        }

        private void passwordTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            errorProvider1.SetError(passwordTextBox, "");
        }

        #endregion

        #region Validate user input

        private bool validateEmail() {
            Regex regex = new Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");


            if (!regex.IsMatch(emailTextBox.Text)) {
                errorProvider1.SetError(emailTextBox, "Please enter a valid email address.");
                return false;
            }

            return true;
        }

        private bool validateUsername() {
            // make a call to ensure the username is not in use already

            return true;
        }

        #endregion

        #endregion

    }
}
