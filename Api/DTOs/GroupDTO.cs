using System;
using System.Collections.Generic; 

namespace APIPortal.DTOs
{
    public class UrlDTO
    {
        public string UrlString { get; set; }
    }

    public class GroupDTO
    {
        public Guid Id { get; set; }
        public List<PresentationDTO> Presentations { get; set; }
        public List<StudentDTO> GroupMembers { get; set; }
        public string Subject { get; set; }
    }

    public class PresentationDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public List<UrlDTO> References { get; set; }
    }

    public class StudentDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}
