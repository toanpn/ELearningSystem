using eLearningSystem.Repositories.UnitOfWork;
using eLearningSystem.Services.IService;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;
using System.Web.Http;
using eLearningSystem.Services.Service;

namespace eLearningSystem.WebApi.APIs
{
    public class CourseController : ApiController
    {
        private readonly ICourseService service;

        private readonly UnitOfWork uow;

        public CourseController()
        {
            uow = new UnitOfWork();
            this.service = new CourseService(uow);
        }


        public IHttpActionResult Get()
        {
            //if (service.GetCourses().Count() == 0)
            //    return Ok(new { results = "" });
            return Ok(new { results = service.GetCourses()});
        }

        // GET: api/Course/5
        public IHttpActionResult Get(int id)
        {
            return Ok(new { results = service.GetCourseById(id) });
        }

        // POST: api/Course
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Course/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Course/5
        public void Delete(int id)
        {
            service.DeleteCourse(id);
        }
    }
}