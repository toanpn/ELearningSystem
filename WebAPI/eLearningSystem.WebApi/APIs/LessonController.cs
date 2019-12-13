using eLearningSystem.Data.Model;
using eLearningSystem.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace eLearningSystem.WebApi.APIs
{
    [RoutePrefix("api/Lesson")]
    public class LessonController : ApiController
    {
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [Route("GetAllLesson")]
        [HttpGet]
        public ICollection<Lesson> GetAllLesson()
        {
            return _lessonService.GetAll().ToList();
        }

        [Route("GetLesson")]
        [HttpGet]
        public Lesson GetLesson([FromUri]int Id)
        {
            return _lessonService.GetById(Id);
        }

        [Route("GetLessonByChapter")]
        [HttpGet]
        public ICollection<Lesson> GetLessonByChapter([FromUri]int Id)
        {
            return _lessonService.GetByChapter(Id);
        }

        [Route("AddLesson")]
        [HttpPost]
        public IHttpActionResult AddLesson(Lesson lesson)
        {
            var tmp = _lessonService.Create(lesson);
            return Ok(new { Results = tmp });
        }

        [Route("UpdateLesson")]
        [HttpPost]
        public IHttpActionResult UpdateLesson(Lesson lesson)
        {
            _lessonService.Update(lesson);
            return Ok();
        }

        [Route("DeleteLesson")]
        [HttpPost]
        public IHttpActionResult DeleteLesson(Lesson lesson)
        {
            _lessonService.Delete(lesson);
            return Ok();
        }

        [Route("DeleteLesson")]
        [HttpGet]
        public IHttpActionResult DeleteLesson([FromUri]int Id)
        {
            _lessonService.DeleteById(Id);
            return Ok();
        }
    }
}
