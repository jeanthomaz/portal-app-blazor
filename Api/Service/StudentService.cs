using Core.Entities;
using Core.Interfaces;
using System.Collections.Generic;

public class StudentService : IService
{
    private readonly IRepository _repository;

    public StudentService(IRepository repository)
    {
        _repository = repository;
    }

    public void AddPresentationInGroup(Presentation presentation, int groupId)
    {
        try
        {
            var group = _repository.GetGroupById(groupId);
            if (group is null)
                throw new Exception("Grupo não encontrado.");

            group.AddPresentation(presentation);
            _repository.UpdateGroup(group);
        }
        catch (Exception e)
        {
            var message = $"Falha ao adicionar apresentação '{presentation.Title}'. Erro: ";
            Console.WriteLine(message + e);
            throw;
        }
    }


    public List<Presentation> ListAllPresentations()
    {
        return _repository.ListAllPresentations();
    }

    public Presentation GetPresentationById(int id)
    {
        return _repository.GetPresentationById(id);
    }

    public void UpdatePresentation(int presentationId)
    {
    }

    public void DeletePresentation(int presentationId)
    {
    }

    public void AddGroup(Group group)
    {
        _repository.AddGroup(group);
    }

    public List<Group> ListAllGroups()
    {
        return _repository.ListAllGroups();
    }


    public Group GetGroupById(int id)
    {
        return _repository.GetGroupById(id);
    }

    public void UpdateGroup(int groupId)
    {
    }

    public void AddPresentation(Presentation presentation)
    {
        _repository.AddPresentation(presentation);
    }

    public void DeleteGroup(int groupId)
    {
    }

    public void AddStudentToGroup(Student student, int groupId)
    {
        var group = _repository.GetGroupById(groupId);
        if (group != null)
        {
            _repository.AddStudent(student);

            group.AddStudent(student);
            _repository.UpdateGroup(group);
        }
    }

    public List<Student> ListAllStudents()
    {
        return _repository.ListAllStudents();
    }

    public Student GetStudentById(int id)
    {
        var student = _repository.GetStudentById(id);

        if (student != null)
        {
            
            student.Group = _repository.GetGroupById(student.GroupId);
        }

        return student;
    }

    public void UpdateStudent(int studentId)
    {
        
    }

    public void DeleteStudent(int studentId)
    {
    }
}
