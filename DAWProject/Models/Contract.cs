using System;
using DAWProject.Models.Base;

namespace DAWProject.Models
{
    public class Contract: BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public User Employee { get; set; }
        public int ContractNumber { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}