using MODELS;
using SERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SD55TestAPI.Controllers
{

    public class COurseController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            CourseService repo = new CourseService();
            var list = repo.GetCourses();
            return Ok(list);
        }

        public IHttpActionResult Post(CourseListItem course)
        {
            var service = new CourseService();
            service.CreateCourse(course);
            return Ok();
        }

        public IHttpActionResult Post(int studentID, int courseID)
        {
            var service = new CourseService();
            service.AddStudentToCourse(studentID, courseID);
            return Ok();
        }

        public IHttpActionResult GetAllById(int courseID)
        {
            var service = new CourseService();
            var list = service.GetStudentsInCourse(courseID);
            return Ok(list);
        }
    }
}
