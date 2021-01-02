using System;
using System.Collections.Generic;
using DAWProject.Models.Base;

namespace DAWProject.Models
{
    public class Team: BaseEntity
    {
        public string Name { get; set; }
        public Guid? TeamLeaderId { get; set; }
        public User TeamLeader { get; set; }
        public List<User> Employees { get; set; }
    }
}