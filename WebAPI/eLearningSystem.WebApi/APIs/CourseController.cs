using eLearningSystem.Data.Model;
using eLearningSystem.Services.IService;
using eLearningSystem.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static eLearningSystem.Data.Model.User;

namespace eLearningSystem.WebApi.APIs
{
    [RoutePrefix("api/Course")]
    [Authorize]
    public class CourseController : ApiController
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        //Post: api/Course/AddCourse
        [Route("AddCourse")]
        [HttpPost]
        public IHttpActionResult AddCourse([FromBody]Course course)
        {
            _courseService.Create(course);
            return Ok();
        }

        //Get: api/Course/GetAllCourse
        [Route("GetAllCourse")]
        [HttpGet]
        public IHttpActionResult GetAllCourse()
        {
            return Ok(new { results = _courseService.GetAll() });
        }

        [HttpGet]
        public IHttpActionResult GetCourse(int idCourse)
        {
            return Ok(new { results = _courseService.GetById(idCourse) });
        }

        [HttpGet]
        [Route("GetStudentsByCourseId")]
        public IHttpActionResult GetStudentsByCourseId(int idCourse)
        {
            return Ok(new { results = _courseService.GetById(idCourse).UserCourse.Where(x=>x.IsOwner == false) });
        }

        //[HttpGet]
        //[Route("GetTeacherByCourseId")]
        //public IHttpActionResult GetTeacherByCourseId(int idCourse)
        //{
        //    return Ok(new { results = _courseService.GetById(idCourse).UserCourse.Where(x=>x.IsOwner == true) });
        //}


        //Get: api/Course/DeleteCourse
        [Route("DeleteCourse")]
        [HttpGet]
        public IHttpActionResult DeleteCourse(int idCourse)
        {
            _courseService.Delete(_courseService.GetById(idCourse));
            return Ok();
        }

        //Post: api/Course/DeleteCourse
        [Route("DeleteCourse")]
        [HttpPost]
        public IHttpActionResult DeleteCourse([FromBody]Course course)
        {
            _courseService.Delete(course);
            return Ok();
        }

        //Post: api/Course/UpdateCourse
        [Route("UpdateCourse")]
        [HttpPost]
        public IHttpActionResult UpdateCourse([FromBody]Course course)
        {
            _courseService.Update(course);
            return Ok();
        }

    }
}
