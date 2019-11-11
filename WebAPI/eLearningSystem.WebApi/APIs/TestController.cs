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
    public class TestController : ApiController
    {
        ITestService service;


        public TestController(ITestService TestService) => service = TestService;

        // GET: api/Test
        public IQueryable<Test> GetTests()
        {
            return service.GetAll().AsQueryable();
        }

        // GET: api/Test/5
        [ResponseType(typeof(Test))]
        public IHttpActionResult GetTest(int id)
        {
            Test test = service.GetById(id);
            if (test == null)
            {
                return NotFound();
            }

            return Ok(test);
        }

        // PUT: api/Test/5x`
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTest(int id, Test test)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != test.id)
            {
                return BadRequest();
            }

            service.Create(test);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Test
        [ResponseType(typeof(Test))]
        public IHttpActionResult PostTest(Test test)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            service.Create(test);

            return CreatedAtRoute("DefaultApi", new { id = test.id }, test);
        }

        // DELETE: api/Test/5
        [ResponseType(typeof(Test))]
        public IHttpActionResult DeleteTest(int id)
        {
            Test test = service.GetById(id);
            if (test == null)
            {
                return NotFound();
            }

            service.Delete(test);
            return Ok(test);
        }

    }
}