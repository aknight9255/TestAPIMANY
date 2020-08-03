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
    public class StudentController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            StudentServicecs repo = new StudentServicecs();
            var list = repo.GetStudent();
            return Ok(list);
        }

        public IHttpActionResult Post(StudentCreate course)
        {
            var service = new StudentServicecs();
            service.CreateStudent(course);
            return Ok();
        }
    }
}
