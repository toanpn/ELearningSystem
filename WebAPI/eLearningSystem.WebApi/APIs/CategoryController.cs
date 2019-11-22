using eLearningSystem.Data.Model;
using eLearningSystem.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace eLearningSystem.WebApi.APIs
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

        [Route("UpdateCategory")]
        [HttpPost]
        public IHttpActionResult UpdateCategory(Category category)
        {
            _categoryService.Update(category);
            return Ok();
        }

        [Route("DeleteCategory")]
        [HttpPost]
        public IHttpActionResult DeleteCategory(Category category)
        {
            _categoryService.Delete(category);
            return Ok();
        }

        [Route("DeleteCategory")]
        [HttpGet]
        public IHttpActionResult DeleteCategory([FromUri]int Id)
        {
            _categoryService.DeleteById(Id);
            return Ok();
        }
    }
}
