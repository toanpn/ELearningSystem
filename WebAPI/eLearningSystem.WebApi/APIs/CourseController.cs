using eLearningSystem.Repositories.UnitOfWork;
using eLearningSystem.Services.IService;
using eLearningSystem.Services.Service;
using System.Web.Http;

namespace eLearningSystem.WebApi.APIs
{
    public class CourseController : ApiController
    {
        ICourseService service;

   
        public CourseController(ICourseService CourseService)
        {
            service = CourseService;
        }

        public IHttpActionResult Get()
        {
            //if (service.GetCourses().Count() == 0)
            //    return Ok(new { results = "" });
            return Ok(new { results = service.GetAll() });
        }

        // GET: api/Course/5
        public IHttpActionResult Get(int id)
        {
            return Ok(new { results = service.GetById(id) });
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
            service.Delete(service.GetById(id));
        }
    }
}