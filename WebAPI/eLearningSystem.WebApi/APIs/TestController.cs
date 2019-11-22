using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using eLearningSystem.Data.Model;
using eLearningSystem.Services.Service;
using eLearningSystem.Services.IService;

namespace eLearningSystem.WebApi.APIs
{
    [RoutePrefix("api/Test")]
    public class TestController : ApiController
    {
        private readonly ITestService service;

        public TestController(ITestService TestService) => service = TestService;

        [HttpGet]
        [Route("GetAllTest")]
        public ICollection<Test> GetAllTest()
        {
            return service.GetAll().ToList();
        }

        [HttpGet]
        [Route("GetAllTestByChapter")]
        public ICollection<Test> GetAllTestByChapter([FromUri]int id)
        {
            return service.GetListTestByChapter(id);
        }

        [HttpGet]
        [Route("GetTest")]
        public Test GetTest([FromUri]int id)
        {
            return service.GetById(id);
        }

        [HttpPost]
        [Route("AddTest")]
        public IHttpActionResult AddTest([FromBody]Test test)
        {
            if (test != null)
            {
                service.Create(test);
            }
            return Ok();
        }

        [HttpPost]
        [Route("UpdateTest")]
        public IHttpActionResult UpdateTest([FromBody]Test test)
        {
            if (test != null)
            {
                service.Update(test);
            }
            return Ok();
        }

        [HttpGet]
        [Route("DeleteTest")]
        public IHttpActionResult DeleteTest([FromUri]int id)
        {
            var test = service.GetById(id);
            if( test == null)
            {
                return NotFound();
            }
            service.Delete(test);
            return Ok();
        }
    }
}