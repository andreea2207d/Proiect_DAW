﻿using DAWProject.Models;
using DAWProject.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAWProject.Controllers;

namespace DAWProject.Services.UserService
{
    public interface IUserService
    {
        UserResponseDTO Authentificate(UserRequestDTO model);
        IEnumerable<User> GetAllUsers();
        User GetById(Guid id);

        void CreateUser(UserCreationDto dto);
    }
}
