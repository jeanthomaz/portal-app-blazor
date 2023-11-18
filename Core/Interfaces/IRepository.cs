using Core.Entities;

namespace Core.Interfaces;

public interface IRepository
{
    public Task AddTokenAsync(Token token);
    public Task<List<Token>> ListTokensAsync();
    
    public Task AddProjectAsync(Project project);
    public Task<Project> GetProjectByIdAsync(Guid id);
    public Task<Project> GetProjectByPrivateTokenAsync(Guid privateToken);
    public Task<List<Project>> ListProjectsAsync();
    public Task UpdateProjectAsync(Project project);
    public Task RemoveProjectAsync(Project project);
}