using eLearningSystem.Data.Model;
using eLearningSystem.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace eLearningSystem.WebApi.API
{
    [RoutePrefix("api/Category")]
    public class CategoryController : ApiController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Route("GetAllCategories")]
        [HttpGet]
        public ICollection<Category> GetAllCategories()
        {
            return _categoryService.GetAll().ToList();
        }

        [Route("GetCategory")]
        [HttpGet]
        public Category GetCategory([FromUri]int Id)
        {
            return _categoryService.GetById(Id);
        }

        [Route("AddCategory")]
        [HttpPost]
        public IHttpActionResult AddCategory(Category category)
        {
            _categoryService.Create(category);
            return Ok();
        }


    }
}