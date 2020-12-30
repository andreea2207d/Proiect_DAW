using System;

namespace DAWProject.Models.DTOs
{
    public class TeamAssignmentDto
    {
        public Guid UserId { get; set; }
        public Guid TeamId { get; set; }
    }
}