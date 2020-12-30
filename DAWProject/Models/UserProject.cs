using System;
using Newtonsoft.Json;

namespace DAWProject.Models
{
    public class UserProject
    {
        public Guid UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        
        public Guid ProjectId { get; set; }
        [JsonIgnore]
        public Project Project { get; set; }
    }
}