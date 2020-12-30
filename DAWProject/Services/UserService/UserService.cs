using DAWProject.Models;
using DAWProject.Models.DTOs;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using DAWProject.Controllers;
using DAWProject.Helpers;
using DAWProject.Repositories.UserRepository;
using Microsoft.Extensions.Options;

namespace DAWProject.Services.UserService
{
    public class UserService: IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly IUserRepository _userRepository;

        public UserService(AppSettings appSettings, IUserRepository userRepository)
        {
            _appSettings = appSettings;
            _userRepository = userRepository;
        }

        public UserResponseDTO Authentificate(UserRequestDTO model)
        {
            var user = _userRepository.FindByCredentials(model.Username, model.Password);

            if (user == null) return null;

            var token = GenerateUserJWTToken(user);

            return new UserResponseDTO(user, token);
        }

        private string GenerateUserJWTToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public void CreateUser(UserCreationDto dto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
