using System.Collections.Generic;
using DAWProject.Models.Base;
using Newtonsoft.Json;

namespace DAWProject.Models
{
    public class Department: BaseEntity
    {
        public string Name { get; set; }
        [JsonIgnore]
        public List<User> Employees { get; set; }
    }
}