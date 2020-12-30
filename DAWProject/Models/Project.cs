using System;
using System.Collections.Generic;
using DAWProject.Models.Base;
using Newtonsoft.Json;

namespace DAWProject.Models
{
    public class Project: BaseEntity
    {
        public string Name { get; set; }
        public string Beneficiary { get; set; }
        public double Budget { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [JsonIgnore]
        public List<UserProject> Users { get; set; }
    }
}