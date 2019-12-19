using eLearningSystem.Data.Constants;
using eLearningSystem.Data.DTO;
using eLearningSystem.Data.Model;
using eLearningSystem.Data.ViewModels;
using eLearningSystem.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace eLearningSystem.WebApi.API
{
    public class TestController : ApiController
    {
        private ITestService _testService;

        public TestController(ITestService testService)
        {
            this._testService = testService;
        }

        /// <summary>
        /// Lấy ra câu hỏi theo id
        /// </summary>
        /// <returns></returns>
        [Route("api/test/{courseId}/{chapterId}")]
        public IHttpActionResult GetCourseById(int courseId, int chapterId)
        {
            ResponseDataDTO<Test> response = new ResponseDataDTO<Test>();
            try
            {
                response.Code = HttpCode.OK;
                response.Message = MessageResponse.SUCCESS;
                response.Data = _testService.GetTest(courseId, chapterId);
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

        [Route("api/test/check/{courseId}/{chapterId}")]
        [HttpPost]
        public IHttpActionResult CheckTest(int courseId, int chapterId, List<SubmitTestViewModel> submitTests)
        {
            ResponseDataDTO<int> response = new ResponseDataDTO<int>();
            try
            {
                response.Code = HttpCode.OK;
                response.Message = MessageResponse.SUCCESS;
                response.Data = _testService.CheckTest(courseId, chapterId, submitTests);
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
    }
}
