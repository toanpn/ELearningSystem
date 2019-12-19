using eLearningSystem.Data.Model;
using eLearningSystem.Services.IService;
using eLearningSystem.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace eLearningSystem.WebApi.Controllers
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
            string username = User.Identity.Name;
            return _cartService.GetCartsByUserName(username);
        }

        [HttpPost]
        [Route("AddCart")]
        public IHttpActionResult AddCart(Cart cart)
        {
            if (cart != null)
            {
                User user = _userService.GetUserByUserName(User.Identity.Name);
                if (user != null)
                {
                    if (this._cartService.CheckExistCart(cart.CourseId, user.Id))
                    {
                        cart.UserId = user.Id;
                        _cartService.Create(cart);
                    }
                }
            }
            return Ok();
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
