using eLearningSystem.Data.Constants;
using eLearningSystem.Data.DTO;
using eLearningSystem.Data.Model;
using eLearningSystem.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace eLearningSystem.WebApi.API
{
    public class ManagerUsersController : ApiController
    {
        private readonly IUserService userService;

        public ManagerUsersController(IUserService service) 
        {
            this.userService = service;
        }

        [Route("api/user/all")]
        public IHttpActionResult GetBooks()
        {
            ResponseDataDTO<IEnumerable<User>> response = new ResponseDataDTO<IEnumerable<User>>();
            try
            {
                response.Code = HttpCode.OK;
                response.Message = MessageResponse.SUCCESS;
                response.Data = userService.GetAll();
            }
            catch (Exception ex)
            {
                response.Code = HttpCode.INTERNAL_SERVER_ERROR;
                response.Message = MessageResponse.FAIL;
                response.Data = null;

                Console.WriteLine(ex.ToString());
            }

            return Ok(response);
        }
    }
}
