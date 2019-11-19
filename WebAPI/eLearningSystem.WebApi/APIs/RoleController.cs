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
    [RoutePrefix("api/Role")]
    [Authorize]
    public class RoleController : ApiController
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        //Post: api/Role/AddRole
        [Route("AddRole")]
        [HttpPost]
        public IHttpActionResult AddRole([FromBody]RoleViewModel roleViewModel)
        {
            var role = new Role()
            {
                Name = roleViewModel.Name
            };
            _roleService.Create(role);
            return Ok();
        }

        //Get: api/Role/GetAllRole
        [Route("GetAllRole")]
        [HttpGet]
        public IHttpActionResult GetAllRole()
        {
            return Ok(new { results = _roleService.GetAll() });
        }

        //Get: api/Role/DeleteRole
        [Route("DeleteRole")]
        [HttpGet]
        public IHttpActionResult DeleteRole(int idRole)
        {
            _roleService.DeleteById(idRole);
            return Ok();
        }

        //Post: api/Role/DeleteRole
        [Route("DeleteRole")]
        [HttpPost]
        public IHttpActionResult DeleteRole([FromBody]RoleViewModel roleViewModel)
        {
            _roleService.DeleteByName(roleViewModel.Name);
            return Ok();
        }

        //Post: api/Role/UpdateRole
        [Route("UpdateRole")]
        [HttpPost]
        public IHttpActionResult UpdateRole([FromBody]Role role)
        {
            _roleService.Update(role);
            return Ok();
        }

    }
}
