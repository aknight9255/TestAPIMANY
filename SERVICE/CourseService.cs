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
    public class CourseService
    {
        public void CreateCourse(CourseListItem course)
        {
            var entity = new Course()
            {
                ClassName = course.ClassName
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Courses.Add(entity);
                ctx.SaveChanges();
            }
        }

        public void AddStudentToCourse(int studentID, int courseID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var course = ctx.Courses.Single(e => e.ClassID == courseID);
                var oneStudent = ctx.Students.Single(e => e.StudentID == studentID);

                course.Students.Add(oneStudent);
                ctx.SaveChanges();
            }
        }

        public IEnumerable<CourseListItem> GetCourses()
        {
            using( var ctx = new ApplicationDbContext())
            {
                var all = ctx.Courses
                    .Select(e => new CourseListItem
                {
                    ClassID = e.ClassID,
                    ClassName = e.ClassName
                });


                return all.ToArray();
            }
        }

        public IEnumerable<StudentCreate> GetStudentsInCourse(int courseID)
        {
            var listOfStudents = new List<StudentCreate>();
            using (var ctx = new ApplicationDbContext())
            {
                var oneCourse = ctx.Courses.Single(e => e.ClassID == courseID);
                foreach(var student in oneCourse.Students)
                {
                    var newStudent = new StudentCreate
                    {
                        StudentID = student.StudentID,
                        Name = student.Name
                    };
                    listOfStudents.Add(newStudent);
                }
            }
            return listOfStudents;
        }
    }
}
