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
    public class ManagerCategoryController : ApiController
    {

        private ICategoryService _categoryService;

        public ManagerCategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        [Route("api/category/all")]
        public IHttpActionResult GetAll()
        {
            ResponseDataDTO<IEnumerable<Category>> response = new ResponseDataDTO<IEnumerable<Category>>();
            try
            {
                response.Code = HttpCode.OK;
                response.Message = MessageResponse.SUCCESS;
                response.Data = _categoryService.GetAll();
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
