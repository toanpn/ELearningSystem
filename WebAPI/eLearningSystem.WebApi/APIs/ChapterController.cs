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
    [RoutePrefix("api/Chapter")]
    public class ChapterController : ApiController
    {
        private readonly IChapterService _chapterService;

        public ChapterController(IChapterService chapterService)
        {
            _chapterService = chapterService;
        }

        [Route("GetAllChapter")]
        [HttpGet]
        public ICollection<Chapter> GetAllChapter()
        {
            return _chapterService.GetAll().ToList();
        }

        [Route("GetChapter")]
        [HttpGet]
        public Chapter GetChapter([FromUri]int Id)
        {
            return _chapterService.GetById(Id);
        }

        [Route("GetChapterByCourse")]
        [HttpGet]
        public ICollection<Chapter> GetChapterByCourse([FromUri]int Id)
        {
            return _chapterService.GetByCourse(Id);
        }

        [Route("AddChapter")]
        [HttpPost]
        public IHttpActionResult AddChapter(Chapter chapter)
        {
            var tmp = _chapterService.Create(chapter);
            return Ok(new { Results = tmp });
        }

        [Route("UpdateChapter")]
        [HttpPost]
        public IHttpActionResult UpdateChapter(Chapter chapter)
        {
            _chapterService.Update(chapter);
            return Ok();
        }

        [Route("DeleteChapter")]
        [HttpPost]
        public IHttpActionResult DeleteChapter(Chapter chapter)
        {
            _chapterService.Delete(chapter);
            return Ok();
        }

        [Route("DeleteChapter")]
        [HttpGet]
        public IHttpActionResult DeleteChapter([FromUri]int Id)
        {
            _chapterService.DeleteById(Id);
            return Ok();
        }
    }
}
