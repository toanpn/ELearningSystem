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
    [RoutePrefix("api/Answer")]
    public class AnswerController : ApiController
    {
        private readonly IAnswerService _answerService;
        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [HttpGet]
        [Route("GetAllAnswer")]
        public ICollection<Anwser> GetAllAnswer()
        {
            return _answerService.GetAll().ToList();
        }

        [HttpGet]
        [Route("GetAllAnswerByQuestion")]
        public ICollection<Anwser> GetAllAnswerByQuestion([FromUri]int id)
        {
            return _answerService.GetListAnswerByQuestion(id).OrderBy(t => t.Type).ToList();
        }

        [HttpGet]
        [Route("GetAnswer")]
        public Anwser GetAnswer([FromUri]int id)
        {
            return _answerService.GetById(id);
        }

        [HttpPost]
        [Route("AddAnswer")]
        public IHttpActionResult AddAnswer([FromBody] Anwser anwser)
        {
            if (anwser != null)
                _answerService.Create(anwser);
            return Ok();
        }

        [HttpPost]
        [Route("UpdateAnswer")]
        public IHttpActionResult UpdateAnswer([FromBody] Anwser anwser)
        {
            if (anwser != null)
                _answerService.Update(anwser);
            return Ok();
        }

        [HttpGet]
        [Route("DeleteAnswer")]
        public IHttpActionResult DeleteAnswer([FromUri] int id)
        {
            var a = _answerService.GetById(id);
            if(a != null)
            {
                _answerService.Delete(a);
            }
            return Ok();
        }
    }
}
