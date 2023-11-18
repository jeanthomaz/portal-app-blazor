using Core.Entities;
using Core.ValueObjects;

namespace Core.Interfaces;

public interface IService
{
    public Task<string> GenerateTokenAsync();
    public Task<List<Token>> ListTokensAsync();
    
    public Task AddProjectAsync(Project project, Guid privateToken);
    public Task<Project> GetProjectByIdAsync(Guid id);
    public Task<List<Project>> ListProjectsAsync();
    public Task UpdateProjectAsync(Project project, Guid privateToken);
    public Task RemoveProjectAsync(Project project, Guid privateToken);
    
    public Task AddStudentToProjectAsync(Student student, Guid privateToken);
    public Task UpdateStudentAsync(Student student, Guid privateToken);
    public Task RemoveStudentAsync(Student student, Guid privateToken);
    
    public Task AddReferenceToProjectAsync(Url reference, Guid privateToken);
    public Task RemoveReferenceFromProjectAsync(Url reference, Guid privateToken);
}