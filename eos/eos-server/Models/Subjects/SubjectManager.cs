using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eos.Models.Subjects
{
    public class SubjectManager : DataManager<Subject>
    {
        public void Delete(int id)
        {
            var subject = this.Context.Subjects.Find(id);

            if (subject == null) {
                return;
            }

            this.Context.Subjects.Remove(subject);
            this.Context.SaveChanges();
        }

        public int Save(Subject data)
        {
            var subject = this.Context.Subjects.Find(data.Id);

            if (subject == null) {
                subject = data;

                this.Context.Subjects.Add(subject);
            } else {
                subject.XPos = data.XPos;
                subject.YPos = data.YPos;
            }

            this.Context.SaveChanges();
            return subject.Id;
        }
    }
}