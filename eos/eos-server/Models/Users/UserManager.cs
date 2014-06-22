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
            var user = this.Context.Users.Find(data.Id);

            if (user == null) {
                user = data;

                this.Context.Users.Add(user);
            } else {
                user.Deleted = data.Deleted;
                user.DeletedBy = data.DeletedBy;
                user.DeletedOn = data.DeletedOn;
                user.Email = data.Email;
                user.FirstName = data.FirstName;
                user.LastName = data.LastName;
                user.Password = data.Password;
            }

            this.Context.SaveChanges();
            return user.Id;
        }
    }
}