using Core.Entities;
using Core.Exceptions;
using Core.Interfaces;
using Core.ValueObjects;

namespace Core.Services;

public class Service : IService
{
    private readonly IRepository _repository;

    public Service(IRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<string> GenerateTokenAsync()
    {
        var token = new Token();
        await _repository.AddTokenAsync(token);
        return token.Id.ToString();
    }

    public async Task<List<Token>> ListTokensAsync()
    {
        return await _repository.ListTokensAsync();
    }

    public async Task AddProjectAsync(Project project, Guid privateToken)
    {
        var existingProjects = await _repository.ListProjectsAsync();
        
        if (existingProjects.Any(p => p.Name == project.Name))
            throw new Exception($"Já existe um projeto com o nome {project.Name}.");
        
        if (await TokenNotAvailable(privateToken))
            throw new UnavailableTokenException($"Não foi possível usar o token {privateToken}.");
        
        project.AssignPrivateToken(privateToken);
        
        await _repository.AddProjectAsync(project);
        await _repository.UpdateTokenAsync(new () {Id = privateToken, ProjectId = project.Id});
    }

    private async Task<bool> TokenNotAvailable(Guid privateToken)
    {
        var allTokens = await _repository.ListTokensAsync();
        
        var token = allTokens.FirstOrDefault(t => t.Id == privateToken);
        
        if (token is null)
            return true;
        
        if (token.ProjectId is not null)
            return true;
        
        return false;
    }

    public async Task<Project> GetProjectByIdAsync(Guid id)
    {
        return await _repository.GetProjectByIdAsync(id);
    }

    public async Task<List<Project>> ListProjectsAsync()
    {
        return await _repository.ListProjectsAsync();
    }

    public async Task UpdateProjectAsync(Project project, Guid privateToken)
    {
        await _repository.UpdateProjectAsync(project);
    }

    public async Task RemoveProjectAsync(Project project, Guid privateToken)
    {
        await _repository.RemoveProjectAsync(project);
        
        var token = await _repository.ListTokensAsync();
        var tokenToRemove = token.FirstOrDefault(t => t.Id == privateToken);
        
        if (tokenToRemove is not null)
        {
            tokenToRemove.ProjectId = null;
            await _repository.UpdateTokenAsync(tokenToRemove);
        }
    }

    public async Task AddStudentToProjectAsync(Student student, Guid privateToken)
    {
        var project = await _repository.GetProjectByPrivateTokenAsync(privateToken);
        project.Group.AddStudent(student);
        
        await _repository.UpdateProjectAsync(project);
    }

    public async Task UpdateStudentAsync(Student student, Guid privateToken)
    {
        var project = await _repository.GetProjectByPrivateTokenAsync(privateToken);
        project.Group.UpdateStudent(student);
        
        await _repository.UpdateProjectAsync(project);
    }

    public async Task RemoveStudentAsync(Student student, Guid privateToken)
    {
        var project = await _repository.GetProjectByPrivateTokenAsync(privateToken);
        project.Group.RemoveStudent(student);
        
        await _repository.UpdateProjectAsync(project);
    }

    public async Task AddReferenceToProjectAsync(Url reference, Guid privateToken)
    {
        var project = await _repository.GetProjectByPrivateTokenAsync(privateToken);
        project.AddReference(reference);
        
        await _repository.UpdateProjectAsync(project);
    }

    public async Task RemoveReferenceFromProjectAsync(Url reference, Guid privateToken)
    {
        var project = await _repository.GetProjectByPrivateTokenAsync(privateToken);
        project.RemoveReference(reference);
        
        await _repository.UpdateProjectAsync(project);
    }
}