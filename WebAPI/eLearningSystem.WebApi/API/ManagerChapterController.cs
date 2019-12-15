using eLearningSystem.Data.Constants;
using eLearningSystem.Data.DTO;
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
        public IHttpActionResult CreateChapter(ChapterViewModel chapterViewModel)
        {
            ResponseDataDTO<int> response = new ResponseDataDTO<int>();
            try
            {
                response.Data = this._chapterService.CreateChapter(chapterViewModel);
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
    }
}
