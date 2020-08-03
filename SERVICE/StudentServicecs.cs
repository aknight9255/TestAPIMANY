using DATA;
using MODELS;
using SD55TestAPI.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE
{
    public class StudentServicecs
    {
        public void CreateStudent(StudentCreate course)
        {
            var entity = new Student()
            {
                Name = course.Name
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Students.Add(entity);
                ctx.SaveChanges();
            }
        }


        public IEnumerable<StudentCreate> GetStudent()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var all = ctx.Students
                    .Select(e => new StudentCreate
                    {
                        StudentID = e.StudentID,
                        Name = e.Name
                    });


                return all.ToArray();
            }
        }
    }
}
