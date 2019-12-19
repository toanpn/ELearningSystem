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
    public class UserCourseController : ApiController
    {
        private IUserCourseService _userCourseService;
        public UserCourseController(IUserCourseService userCourseService)
        {
            this._userCourseService = userCourseService;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        [Route("api/user-course/all")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            String userName = User.Identity.Name;
            ResponseDataDTO<List<Course>> response = new ResponseDataDTO<List<Course>>();
            try
            {
                response.Code = HttpCode.OK;
                response.Message = MessageResponse.SUCCESS;
                response.Data = _userCourseService.GetOwnCourses(userName);
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

        [Route("api/user-course/create/{courseId}")]
        [HttpGet]
        public IHttpActionResult BuyCourse(int courseId)
        {
            String userName = User.Identity.Name;
            ResponseDataDTO<int> response = new ResponseDataDTO<int>();
            try
            {
                response.Code = HttpCode.OK;
                response.Message = MessageResponse.SUCCESS;
                response.Data = _userCourseService.BuyCourse(courseId, userName);
            }
            catch (Exception ex)
            {
                response.Code = HttpCode.INTERNAL_SERVER_ERROR;
                response.Message = MessageResponse.FAIL;
                response.Data = 0;

                Console.WriteLine(ex.ToString());
            }

            return Ok(response);
        }

        [Route("api/user-course/id")]
        [HttpGet]
        public IHttpActionResult GetAllCourseID()
        {
            String userName = User.Identity.Name;
            ResponseDataDTO<List<int>> response = new ResponseDataDTO<List<int>>();
            try
            {
                response.Code = HttpCode.OK;
                response.Message = MessageResponse.SUCCESS;
                response.Data = _userCourseService.GetOwnCourseID(userName);
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
