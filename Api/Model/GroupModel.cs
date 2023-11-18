// GroupModel.cs
using Api.Model;
using System;
using System.Collections.Generic;
using Core.Entities;

namespace Api.Models
{
    public class GroupModel
    {
        public string Subject { get; set; }
        public List<Student> GroupMembers { get; set; }
    }
}