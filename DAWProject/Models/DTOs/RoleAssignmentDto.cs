using System;

namespace DAWProject.Models.DTOs
{
    public class RoleAssignmentDto
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}