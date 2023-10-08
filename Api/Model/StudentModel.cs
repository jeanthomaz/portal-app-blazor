using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Api.Model
{
    public class StudentModel
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public int GroupId { get; set; }

    }
}
