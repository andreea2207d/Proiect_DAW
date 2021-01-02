﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAWProject.Helpers;
using DAWProject.Models.DTOs;
using DAWProject.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DAWProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authentificate")]
        public IActionResult Authentificate(UserRequestDTO user)
        {
            var result = _userService.Authentificate(user);

            if(result == null)
            {
                return BadRequest(new { Message = "Username or Password is invalid!" });
            }
            return Ok(result);
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }
        
        [HttpPost]
        public IActionResult CreateUser(UserCreationDto userCreationDto)
        {
            _userService.CreateUser(userCreationDto);
            return Ok();
        }

    }

    
}
