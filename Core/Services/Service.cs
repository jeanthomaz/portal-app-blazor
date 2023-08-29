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

    public Presentation GetPresentationById(Guid id)
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

    public Group GetGroupById(Guid id)
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

    public void AddStudent(Student student)
    {
        throw new NotImplementedException();
    }

    public List<Student> ListAllStudents()
    {
        throw new NotImplementedException();
    }

    public void UpdateStudent(Student student)
    {
        throw new NotImplementedException();
    }

    public void DeleteStudent(Student student)
    {
        throw new NotImplementedException();
    }

    #endregion
}