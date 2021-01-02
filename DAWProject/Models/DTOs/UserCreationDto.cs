using System;
using System.Collections.Generic;

namespace DAWProject.Models.DTOs
{
    public class UserCreationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? ContractStartDate { get; set; }
        public DateTime? ContractEndDate { get; set; }
        public Guid? RoleId { get; set; }
        public Guid? TeamId { get; set; }
        public Guid? DepartmentId { get; set; }
    }
}