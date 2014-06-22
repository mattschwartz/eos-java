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
            var task = this.Context.Tasks.Find(data.id);

            if (task == null) {
                task = data;

                this.Context.Tasks.Add(task);
            } else {
                task.color = data.color;
                task.comments = data.comments;
                task.deleted = data.deleted;
                task.name = data.name;
            }

            this.Context.SaveChanges();
            return task.id;
        }
    }
}