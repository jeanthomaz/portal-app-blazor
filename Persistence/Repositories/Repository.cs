using Core.Entities;
using Core.Interfaces;

namespace Persistence.Repositories;

public class Repository : IRepository
{
    private readonly ApplicationDbContext _context;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void AddPresentation(Presentation presentation)
    {
        throw new NotImplementedException();
    }

    public List<Presentation> ListAllPresentations()
    {
        throw new NotImplementedException();
    }

    public Presentation GetPresentationById(int id)
    {
        throw new NotImplementedException();
    }

    public void UpdatePresentation(Presentation presentation)
    {
        throw new NotImplementedException();
    }

    public void DeletePresentation(Presentation presentation)
    {
        throw new NotImplementedException();
    }

    public void AddGroup(Group group)
    {
        throw new NotImplementedException();
    }

    public List<Group> ListAllGroups()
    {
        throw new NotImplementedException();
    }

    public Group GetGroupById(int id)
    {
        throw new NotImplementedException();
    }

    public void UpdateGroup(Group group)
    {
        throw new NotImplementedException();
    }

    public void DeleteGroup(Group group)
    {
        throw new NotImplementedException();
    }

    public void AddStudent(Student student)
    {
        _context.Students.Add(student);
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