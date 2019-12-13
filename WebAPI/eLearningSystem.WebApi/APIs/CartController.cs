using eLearningSystem.Data.Model;
using eLearningSystem.Services.IService;
using eLearningSystem.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace eLearningSystem.WebApi.APIs
{
    [RoutePrefix("api/Cart")]
    public class CartController : ApiController
    {
        private readonly ICartService _cartService;
        private readonly IUserService _userService;

        public CartController(ICartService cartService, IUserService userService)
        {
            _cartService = cartService;
            _userService = userService;
        }

        [HttpGet]
        [Route("GetAllCart")]
        public ICollection<Cart> GetAllCart()
        {
            return _cartService.GetAll().ToList();
        }

        [HttpPost]
        [Route("AddCart")]
        public IHttpActionResult AddCart([FromBody] CartModel cartModel)
        {
            if (cartModel == null)
                return BadRequest();
            var user = _userService.GetUserByUserName(User.Identity.Name);
            var cart = new Cart()
            {
                Id = 0,
                UserId = user.Id,
                CourseId = cartModel.IdCourse
            };
            var tmp = _cartService.Create(cart);
            if(tmp == null || tmp.Id == 0)
            {
                return BadRequest();
            }
            return Ok(new { Results = tmp });
        }

        [HttpGet]
        [Route("DeleteCart")]
        public IHttpActionResult DeleteCart([FromUri] int id)
        {
            var a = _cartService.GetById(id);
            if (a != null)
            {
                _cartService.Delete(a);
                return Ok();
            }
            return NotFound();
        }

        [HttpGet]
        [Route("GetNumber")]
        public IHttpActionResult GetNumber()
        {
            var user = _userService.GetUserByUserName(User.Identity.Name);
            var tmp = _cartService.GetNumberCart(user.Id);
            return Ok(new { Results = tmp });
        }
    }
}
