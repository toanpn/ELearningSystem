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
    [RoutePrefix("api/UserRole")]
    [Authorize]
    public class UserRoleController : ApiController
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        //Post: api/UserRole/AddUserRole
        [Route("AddUserRole")]
        [HttpPost]
        public IHttpActionResult AddUserRole([FromBody]UserRoleViewModel userRoleViewModel)
        {
            _userRoleService.Create(new UserRole()
            {
                RoleId = userRoleViewModel.RoleId,
                UserId = userRoleViewModel.UserId
            });
            return Ok();
        }

        //Get: api/UserRole/GetAllUserRole
        [Route("GetAllUserRole")]
        [HttpGet]
        public IHttpActionResult GetAllUserRole()
        {
            var listUserRole = _userRoleService.GetAll();
            return Ok(new { results = listUserRole });
        }

        //Post: api/UserRole/DeleteUserRole
        [Route("DeleteUserRole")]
        [HttpPost]
        public IHttpActionResult DeleteUserRole([FromBody]UserRole userRole)
        {
            _userRoleService.Delete(userRole);
            return Ok();
        }

        //Post: api/UserRole/DeleteUserRoleByUserAndRole
        [Route("DeleteUserRoleByUserAndRole")]
        [HttpPost]
        public IHttpActionResult DeleteUserRoleByUserAndRole([FromBody]UserRoleViewModel userRoleViewModel)
        {
            _userRoleService.Delete(userRoleViewModel.UserId, userRoleViewModel.RoleId);
            return Ok();
        }
    }
}
