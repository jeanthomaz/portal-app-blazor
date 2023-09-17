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
        try
        {
            return _repository.ListAllPresentations();
        }
        catch (Exception e)
        {
            var message = "Falha ao listar apresentações. Erro: ";
            Console.WriteLine(message + e);
            throw;
        }
    }

    public Presentation GetPresentationById(int id)
    {
        try
        {
            return _repository.GetPresentationById(id);
        }
        catch (Exception e)
        {
            var message = $"Falha ao buscar apresentação {id}. Erro: ";
            Console.WriteLine(message + e);
            throw;
        }
    }

    public void UpdatePresentation(int presentationId)
    {
        try
        {
            var presentation = _repository.GetPresentationById(presentationId);
            if (presentation is null)
                throw new Exception("Apresentação não encontrada.");

            _repository.UpdatePresentation(presentation);
        }
        catch (Exception e)
        {
            var message = $"Falha ao atualizar apresentação {presentationId}. Erro: ";
            Console.WriteLine(message + e);
            throw;
        }
    }

    public void DeletePresentation(int presentationId)
    {
        try
        {
            var oldPresentation = _repository.GetPresentationById(presentationId);
            if (oldPresentation is null || oldPresentation.IsDeleted)
                throw new Exception("Apresentação não encontrada.");

            oldPresentation.SoftDelete();
            _repository.UpdatePresentation(oldPresentation);
        }
        catch (Exception e)
        {
            var message = $"Falha ao deletar apresentação {presentationId}. Erro: ";
            Console.WriteLine(message + e);
            throw;
        }
    }

    #endregion

    #region Group Methods

    public void AddGroup(Group group)
    {
        try
        {
            var groupExists = _repository.ListAllGroups().Any(g => g.Subject == group.Subject);
            if (groupExists)
                throw new Exception("Um grupo com esse tema já existe.");
            
            _repository.AddGroup(group);
        }
        catch (Exception e)
        {
            var message = $"Falha ao adicionar grupo '{group.Subject}'. Erro: ";
            Console.WriteLine(message + e);
            throw;
        }
    }

    public List<Group> ListAllGroups()
    {
        try
        {
            return _repository.ListAllGroups();
        }
        catch (Exception e)
        {
            var message = "Falha ao listar grupos. Erro: ";
            Console.WriteLine(message + e);
            throw;
        }
    }

    public Group GetGroupById(int id)
    {
        try
        {
            var group = _repository.GetGroupById(id);
            if (group is null)
                throw new Exception("Grupo não encontrado.");
            
            return group;
        }
        catch (Exception e)
        {
            var message = $"Falha ao buscar grupo {id}. Erro: ";
            Console.WriteLine(message + e);
            throw;
        }
    }

    public void UpdateGroup(int groupId)
    {
        try
        {
            var group = _repository.GetGroupById(groupId);
            if (group is null)
                throw new Exception("Grupo não encontrado.");

            _repository.UpdateGroup(group);
        }
        catch (Exception e)
        {
            var message = $"Falha ao atualizar grupo {groupId}. Erro: ";
            Console.WriteLine(message + e);
            throw;
        }
    }

    public void DeleteGroup(int groupId)
    {
        try
        {
            var oldGroup = _repository.GetGroupById(groupId);
            if (oldGroup is null)
                throw new Exception("Grupo não encontrado.");

            oldGroup.SoftDelete();
            _repository.UpdateGroup(oldGroup);
        }
        catch (Exception e)
        {
            var message = $"Falha ao deletar grupo {groupId}. Erro: ";
            Console.WriteLine(message + e);
            throw;
        }
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

    public void UpdateStudent(int studentId)
    {
        try
        {
            var student = _repository.GetStudentById(studentId);
            if (student is null)
                throw new Exception("Estudante não encontrado.");

            _repository.UpdateStudent(student);
        }
        catch (Exception e)
        {
            var message = $"Falha ao atualizar estudante {studentId}. Erro: ";
            Console.WriteLine(message + e);
            throw;
        }
    }

    public void DeleteStudent(int studentId)
    {
        try
        {
            var student = _repository.GetStudentById(studentId);
            if (student is null)
                throw new Exception("Estudante não encontrado.");

            _repository.DeleteStudent(student);
        }
        catch (Exception e)
        {
            var message = $"Falha ao deletar estudante {studentId}. Erro: ";
            Console.WriteLine(message + e);
            throw;
        }
    }

    #endregion
}