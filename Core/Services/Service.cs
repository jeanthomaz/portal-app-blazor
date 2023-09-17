using Core.Entities;
using Core.Interfaces;

namespace Core.Services;

public class Service : IService
{
    private readonly IRepository _repository;

    public Service(IRepository repository)
    {
        _repository = repository;
    }

    #region Presentation Methods

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

    #endregion

    #region Group Methods

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

    #endregion

    #region Student Methods

    public void AddStudentToGroup(Student student, int groupId)
    {
        var group = _repository.GetGroupById(groupId);
        if (group is null)
            throw new Exception("Grupo não encontrado.");
        
        group.AddStudent(student);
        _repository.UpdateGroup(group);
    }

    public List<Student> ListAllStudents()
    {
        return _repository.ListAllStudents();
    }

    public void UpdateStudent(Student student)
    {
        var oldStudent = _repository.GetStudentById(student.Id);
        if (oldStudent is null)
            throw new Exception("Estudante não encontrado.");
        
        _repository.UpdateStudent(student);
    }

    public void DeleteStudent(Student student)
    {
        var oldStudent = _repository.GetStudentById(student.Id);
        if (oldStudent is null)
            throw new Exception("Estudante não encontrado.");
        
        _repository.DeleteStudent(student);
    }

    #endregion
}