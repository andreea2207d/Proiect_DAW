using System;

namespace DAWProject.Models.DTOs
{
    public class DepartmentAssignmentDto
    {
        public Guid UserId { get; set; }
        public Guid DepartmentId { get; set; }
    }
}