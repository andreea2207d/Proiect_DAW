using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAWProject.Models.Base;
using Newtonsoft.Json;

namespace DAWProject.Models
{
    public class User: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        public Contract Contract { get; set; }
        public Guid? RoleId { get; set; }
        public Role Role { get; set; }
        public Guid? TeamId { get; set; }
        public Team Team { get; set; }
        public Guid? DepartmentId { get; set; }
        public Department Department { get; set; }
        [JsonIgnore]
        public List<UserProject> Projects { get; set; }
    }
}
