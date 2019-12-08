﻿using eLearningSystem.Data.Model;
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
    [RoutePrefix("api/User")]
    [Authorize]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //Post: api/User/AddUser
        [Route("AddUser")]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult AddUser([FromBody]User user)
        {
            user.EmailConfirmed = false;
            user.PhoneNumberConfirmed = false;
            user.TwoFactorEnabled = false;
            user.LockoutEnabled = false;
            user.AccessFailedCount = 10;
            _userService.Create(user);
            return Ok();
        }

        //Get: api/User/GetAllUser
        [Route("GetAllUser")]
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IHttpActionResult GetAllUser()
        {
            return Ok(new { results = _userService.GetAll() });
        }

        //Get: api/User/DeleteUser
        [Route("DeleteUser")]
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IHttpActionResult DeleteUser(int idUser)
        {
            _userService.Delete(idUser);
            return Ok();
        }


        //Get: api/User/{id}
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IHttpActionResult GetUser(int idUser)
        {
            return Ok(new { results = _userService.GetById(idUser) });
        }

        [HttpGet]
        [Route("GetTeacherByCourseId")]
        public IHttpActionResult GetTeacherByCourseId(int idCourse)
        {
            return Ok(new { results = _userService.GetTeacherByCourseId(idCourse) });
        }

        ////Post: api/User/DeleteUser
        //[Route("DeleteUser")]
        //[HttpPost]
        //public IHttpActionResult DeleteUser([FromBody]UserViewModel userViewModel)
        //{
        //    _userService.Delete(userViewModel.id);
        //    return Ok();
        //}

        //Post: api/User/UpdateUser
        [Route("UpdateUser")]
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IHttpActionResult UpdateUser([FromBody]User user)
        {
            _userService.Update(user);
            return Ok();
        }

    }
}
