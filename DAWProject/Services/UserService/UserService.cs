using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DAWProject.Helpers;
using DAWProject.Models;
using DAWProject.Models.DTOs;
using DAWProject.Repositories.ContractRepository;
using DAWProject.Repositories.UserRepository;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DAWProject.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly IUserRepository _userRepository;
        private readonly IContractRepository _contractRepository;

        public UserService(IOptions<AppSettings> appSettings, IUserRepository userRepository, IContractRepository contractRepository)
        {
            _appSettings = appSettings.Value;
            _userRepository = userRepository;
            _contractRepository = contractRepository;
        }

        public UserResponseDTO Authentificate(UserRequestDTO model)
        {
            var user = _userRepository.FindByCredentials(model.Username, model.Password);

            if (user == null) return null;

            var token = GenerateUserJWTToken(user);

            return new UserResponseDTO(user, token);
        }

        public void CreateUser(UserCreationDto dto)
        {
            var newUser = _userRepository.Create(new User
            {
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Username = dto.Username,
                Password = dto.Password,
                RoleId = dto.RoleId,
                TeamId = dto.TeamId,
                DepartmentId = dto.DepartmentId
            });
            _userRepository.Save();
            if (dto.ContractStartDate == null || dto.ContractEndDate == null) return;
            _contractRepository.Create(new Contract
            {
                EmployeeId = newUser.Id,
                ContractNumber = new Random().Next(),
                DateCreated = DateTime.Now,
                StartTime = dto.ContractStartDate.Value,
                EndDateTime = dto.ContractEndDate.Value
            });
            _contractRepository.Save();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllAsQuerable();
        }

        public User GetById(Guid id)
        {
            return _userRepository.FindById(id);
        }

        private string GenerateUserJWTToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {new Claim("id", user.Id.ToString())}),
                Expires = DateTime.UtcNow.AddDays(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}