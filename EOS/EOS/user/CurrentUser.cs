using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOS.user {
    class CurrentUser {

        #region Private data

        private static readonly CurrentUser INSTANCE = new CurrentUser();

        private string _username;
        private bool _online;

        #endregion

        #region Public access data

        public string username {
            set {
            }
            get {
                return _username;
            }
        }
        public bool online {
            set {
            }
            get {
                return _online;
            }
        }

        #endregion

        #region Constructor

        private CurrentUser() {
            if (INSTANCE != null) {
                throw new FieldAccessException(this + " has already been initialized.");
            }
        }

        #endregion

        public static CurrentUser getInstance() {
            return INSTANCE;
        }

        public void setUser(string username, bool online) {
            _username = username;
            _online = online;

            if (!online) {
                _username = "Not logged in";
            }
        }
    }
}
