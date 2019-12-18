using eLearningSystem.Data.Constants;
using eLearningSystem.Data.DTO;
using eLearningSystem.Data.Model;
using eLearningSystem.Data.ViewModels;
using eLearningSystem.Services.IService;
using eLearningSystem.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace eLearningSystem.WebApi.API
{
    public class ManagerChapterController : ApiController
    {
        private IChapterService _chapterService;

        public ManagerChapterController(IChapterService chapterService)
        {
            this._chapterService = chapterService;
        }

        [Route("api/chapter/create")]
        [HttpPost]
        public IHttpActionResult CreateChapter(CreateChaptersViewModel chaptersViewModel)
        {
            ResponseDataDTO<int> response = new ResponseDataDTO<int>();
            try
            {
                response.Data = this._chapterService.CreateChapters(chaptersViewModel);
                response.Message = MessageResponse.SUCCESS;
                response.Code = HttpCode.OK;

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

        [Route("api/chapter/getbycourseId/{courseId}")]
        [HttpGet]
        public IHttpActionResult GetChapters(int courseId)
        {
            ResponseDataDTO<List<Chapter>> response = new ResponseDataDTO<List<Chapter>>();
            try
            {
                response.Data = this._chapterService.GetChaptersByCourseId(courseId);
                response.Message = MessageResponse.SUCCESS;
                response.Code = HttpCode.OK;

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
