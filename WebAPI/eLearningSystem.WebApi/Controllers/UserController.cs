using eLearningSystem.Services.IService;
using eLearningSystem.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace eLearningSystem.WebApi.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public int GetDemo()
        {
            return 1;
        }
    }
}
