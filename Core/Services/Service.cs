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
        try
        {
            var group = _repository.GetGroupById(groupId);
            if (group is null)
                throw new Exception("Grupo não encontrado.");
            
            group.AddStudent(student);
            _repository.UpdateGroup(group);
        }
        catch (Exception e)
        {
            var message = $"Falha ao adicionar estudante {student.Name} ao grupo {groupId}. Erro: ";
            Console.WriteLine(message + e);
            throw;
        }
    }

    public List<Student> ListAllStudents()
    {
        try
        {
            return _repository.ListAllStudents();
        }
        catch (Exception e)
        {
            var message = "Falha ao listar estudantes. Erro: ";
            Console.WriteLine(message + e);
            throw;
        }
    }

    public void UpdateStudent(Student student)
    {
        try
        {
            var oldStudent = _repository.GetStudentById(student.Id);
            if (oldStudent is null)
                throw new Exception("Estudante não encontrado.");

            _repository.UpdateStudent(student);
        }
        catch (Exception e)
        {
            var message = $"Falha ao atualizar estudante {student.Id}. Erro: ";
            Console.WriteLine(message + e);
            throw;
        }
    }

    public void DeleteStudent(Student student)
    {
        try
        {
            var oldStudent = _repository.GetStudentById(student.Id);
            if (oldStudent is null)
                throw new Exception("Estudante não encontrado.");

            _repository.DeleteStudent(student);
        }
        catch (Exception e)
        {
            var message = $"Falha ao deletar estudante {student.Id}. Erro: ";
            Console.WriteLine(message + e);
            throw;
        }
    }

    #endregion
}