using System.Collections.Generic;
using DAWProject.Models.Base;
using Newtonsoft.Json;

namespace DAWProject.Models
{
    public class Role: BaseEntity
    {
        public string Designation { get; set; }
        
        [JsonIgnore]
        public List<User> Users { get; set; }
    }
}