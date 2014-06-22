using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eos.Models.Data;

namespace eos.Models.Users
{
    public class UserManager : DataManager<User>
    {
        public void Delete(int id)
        {
            var user = this.Context.Users.Find(id);

            if (user == null) {
                return;
            }

            this.Context.Users.Remove(user);
            this.Context.SaveChanges();
        }

        public int Save(User data)
        {
            var user = this.Context.Users.Find(data.id);

            if (user == null) {
                user = data;

                this.Context.Users.Add(user);
            } else {
                user.deleted = data.deleted;
                user.deletedBy = data.deletedBy;
                user.deletedOn = data.deletedOn;
                user.email = data.email;
                user.firstName = data.firstName;
                user.lastName = data.lastName;
                user.password = data.password;
            }

            this.Context.SaveChanges();
            return user.id;
        }
    }
}