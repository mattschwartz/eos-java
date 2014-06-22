using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eos.Models.Tasks
{
    public class TaskManager : DataManager<Task>
    {
        public void Delete(int id)
        {
            var task = this.Context.Tasks.Find(id);

            if (task == null) {
                return;
            }

            this.Context.Tasks.Remove(task);
            this.Context.SaveChanges();
        }

        public int Save(Task data)
        {
            var task = this.Context.Tasks.Find(data.Id);

            if (task == null) {
                task = data;

                this.Context.Tasks.Add(task);
            } else {
                task.Color = data.Color;
                task.Comments = data.Comments;
                task.Deleted = data.Deleted;
                task.Name = data.Name;
            }

            this.Context.SaveChanges();
            return task.Id;
        }
    }
}