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

    public void UpdatePresentation(Presentation presentation)
    {
        try
        {
            var oldPresentation = _repository.GetPresentationById(presentation.Id);
            if (oldPresentation is null)
                throw new Exception("Apresentação não encontrada.");

            _repository.UpdatePresentation(presentation);
        }
        catch (Exception e)
        {
            var message = $"Falha ao atualizar apresentação {presentation.Id}. Erro: ";
            Console.WriteLine(message + e);
            throw;
        }
    }

    public void DeletePresentation(Presentation presentation)
    {
        try
        {
            var oldPresentation = _repository.GetPresentationById(presentation.Id);
            if (oldPresentation is null)
                throw new Exception("Apresentação não encontrada.");

            _repository.DeletePresentation(presentation);
        }
        catch (Exception e)
        {
            var message = $"Falha ao deletar apresentação {presentation.Id}. Erro: ";
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
            return _repository.GetGroupById(id);
        }
        catch (Exception e)
        {
            var message = $"Falha ao buscar grupo {id}. Erro: ";
            Console.WriteLine(message + e);
            throw;
        }
    }

    public void UpdateGroup(Group group)
    {
        try
        {
            var oldGroup = _repository.GetGroupById(group.Id);
            if (oldGroup is null)
                throw new Exception("Grupo não encontrado.");

            _repository.UpdateGroup(group);
        }
        catch (Exception e)
        {
            var message = $"Falha ao atualizar grupo {group.Id}. Erro: ";
            Console.WriteLine(message + e);
            throw;
        }
    }

    public void DeleteGroup(Group group)
    {
        try
        {
            var oldGroup = _repository.GetGroupById(group.Id);
            if (oldGroup is null)
                throw new Exception("Grupo não encontrado.");

            _repository.DeleteGroup(group);
        }
        catch (Exception e)
        {
            var message = $"Falha ao deletar grupo {group.Id}. Erro: ";
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