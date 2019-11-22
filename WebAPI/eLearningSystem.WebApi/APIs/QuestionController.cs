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
    [RoutePrefix("api/Question")]
    [Authorize]
    public class QuestionController : ApiController
    {
        private readonly IQuestionService _questionService; 

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [Route("GetAllQuestion")]
        [HttpGet]
        [AllowAnonymous]
        public ICollection<Question> GetAllQuestion()
        {
            return _questionService.GetAll().ToList();
        }

        [HttpGet]
        [Route("GetAllQuestionByTest")]
        public ICollection<Question> GetAllQuestionByTest([FromUri]int id)
        {
            return _questionService.GetListQuestionByTest(id);
        }

        [HttpGet]
        [Route("GetQuestion")]
        public Question GetQuestion([FromUri]int id)
        {
            return _questionService.GetById(id);
        }

        [HttpPost]
        [Route("AddQuestion")]
        public IHttpActionResult AddQuestion([FromBody]Question question)
        {
            if(question != null)
            {
                _questionService.Create(question);
            }
            return Ok();
        }

        [HttpGet]
        [Route("DeleteQuestion")]
        public IHttpActionResult DeleteQuestion([FromUri]int id)
        {
            var q = _questionService.GetById(id);
            if(q != null)
            {
                _questionService.Delete(q);
            }
            return Ok();
        }

        [HttpPost]
        [Route("UpdateQuestion")]
        public IHttpActionResult UpdateQuestion([FromBody]Question question)
        {
            if (question != null)
            {
                _questionService.Update(question);
            }
            return Ok();
        }
    }
}
