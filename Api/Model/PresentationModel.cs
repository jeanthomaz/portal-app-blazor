using System;
using System.Collections.Generic;

namespace Api.Models
{
    public class PresentationModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public List<UrlModel>? References { get; set; }
        public int GroupId { get; set; } 
    }
}