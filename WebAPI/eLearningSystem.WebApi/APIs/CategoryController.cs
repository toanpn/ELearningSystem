using eLearningSystem.Data.Model;
using eLearningSystem.Services.IService;
using eLearningSystem.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static eLearningSystem.Data.Model.User;

namespace eLearningSystem.WebApi.APIs
{
    [RoutePrefix("api/Category")]
    [Authorize]
    public class CategoryController : ApiController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //Post: api/Category/AddCategory
        [Route("AddCategory")]
        [HttpPost]
        public IHttpActionResult AddCategory([FromBody]Category category)
        {
            _categoryService.Create(category);
            return Ok();
        }

        //Get: api/Category/GetAllCategory
        [Route("GetAllCategory")]
        [HttpGet]
        public IHttpActionResult GetAllCategory()
        {
            return Ok(new { results = _categoryService.GetAll() });
        }

        //Get: api/Category/DeleteCategory
        [Route("DeleteCategory")]
        [HttpGet]
        public IHttpActionResult DeleteCategory(int idCategory)
        {
            _categoryService.Delete(_categoryService.GetById(idCategory));
            return Ok();
        }

        //Post: api/Category/DeleteCategory
        [Route("DeleteCategory")]
        [HttpPost]
        public IHttpActionResult DeleteCategory([FromBody]Category category)
        {
            _categoryService.Delete(category);
            return Ok();
        }

        //Post: api/Category/UpdateCategory
        [Route("UpdateCategory")]
        [HttpPost]
        public IHttpActionResult UpdateCategory([FromBody]Category category)
        {
            _categoryService.Update(category);
            return Ok();
        }

    }
}
