using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Linq;

namespace Persistence.Repositories;

public class Repository : IRepository
{
    private readonly ApplicationDbContext _context;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Presentation> ListAllPresentations()
    {
        return _context.Presentations.ToList();
    }

    public Presentation? GetPresentationById(int id)
    {
        return _context.Presentations.FirstOrDefault(p => p.Id == id);
    }

    public void UpdatePresentation(Presentation presentation)
    {
        _context.Presentations.Update(presentation);
        _context.SaveChanges();
    }

    public void DeletePresentation(Presentation presentation)
    {
        _context.Presentations.Remove(presentation);
        _context.SaveChanges();
    }

    public void AddGroup(Group group)
    {
        _context.Groups.Add(group);
        _context.SaveChanges();
    }

    public void AddStudent(Student student)
    {
        _context.Students.Add(student);
        _context.SaveChanges();
    }
    public List<Group> ListAllGroups()
    {
        var groups = _context.Groups.ToList();
        return groups;
    }

    public Group GetGroupById(int id)
    {
        return _context.Groups.FirstOrDefault(g => g.Id == id);
    }

    public void UpdateGroup(Group group)
    {
        _context.Groups.Update(group);
        _context.SaveChanges();
    }

    public void DeleteGroup(Group group)
    {
        _context.Groups.Remove(group);
        _context.SaveChanges();
    }


    public void AddPresentation(Presentation presentation)
    {
        _context.Presentations.Add(presentation);
        _context.SaveChanges();
    }

    public Student? GetStudentById(int id)
    {
        return _context.Students.FirstOrDefault(s => s.Id == id);
    }

    public List<Student> ListAllStudents()
    {
        return _context.Students.ToList();
    }

    public void UpdateStudent(Student student)
    {
        _context.Students.Update(student);
        _context.SaveChanges();
    }

    public void DeleteStudent(Student student)
    {
        _context.Students.Remove(student);
        _context.SaveChanges();
    }
}