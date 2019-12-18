using eLearningSystem.Services.IService;
using System.Collections.Generic;
using System.Web.Http;

namespace eLearningSystem.WebApi.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        private readonly IUserService userService;
        public ValuesController(IUserService userService)
        {
            this.userService = userService;
        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        [HttpGet]
        [Route("api/Value/GetUserLogin")]
        public IHttpActionResult GetUserLogin()
        {
            var user = userService.GetUserByUserName(User.Identity.Name);
            return Ok(new
            {
                Data = user,
                ResponseMessage = "Success",
                StatusCode = 200
            });
        }
    }
}