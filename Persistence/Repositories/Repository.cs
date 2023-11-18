using Core.Entities;
using Core.Exceptions;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class Repository : IRepository
{
    private readonly ApplicationDbContext _context;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddTokenAsync(Token token)
    {
        await _context.Tokens.AddAsync(token);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Token>> ListTokensAsync()
    {
        return await _context.Tokens.ToListAsync();
    }

    public async Task AddProjectAsync(Project project)
    {
        await _context.Projects.AddAsync(project);
        await _context.SaveChangesAsync();
    }

    public async Task<Project> GetProjectByIdAsync(Guid id)
    {
        var project = await _context.Projects
            .Include(p => p.Group)
            .Include(p => p.References)
            .FirstOrDefaultAsync(p => p.Id == id);
        
        if (project is null || project.IsDeleted)
            throw new NotFoundExcecption($"Projeto com id {id} não encontrado.");
        
        return project;
    }

    public async Task<Project> GetProjectByPrivateTokenAsync(Guid privateToken)
    {
        var project = await _context.Projects
            .Include(p => p.Group)
            .Include(p => p.References)
            .FirstOrDefaultAsync(p => p.PrivateToken == privateToken);
        
        if (project is null || project.IsDeleted)
            throw new NotFoundExcecption($"Projeto com token {privateToken} não encontrado.");
        
        return project;
    }

    public async Task<List<Project>> ListProjectsAsync()
    {
        return await _context.Projects
            .Where(p => !p.IsDeleted)
            .Include(p => p.Group)
            .Include(p => p.References)
            .ToListAsync();
    }

    public async Task UpdateProjectAsync(Project project)
    {
        var projectToUpdate = await _context.Projects
            .Include(p => p.Group)
            .Include(p => p.References)
            .FirstOrDefaultAsync(p => p.Id == project.Id);
        
        if (projectToUpdate is null || projectToUpdate.IsDeleted)
            throw new NotFoundExcecption($"Projeto com id {project.Id} não encontrado.");
        
        projectToUpdate.Name = project.Name;
        projectToUpdate.Description = project.Description;
        projectToUpdate.TextBody = project.TextBody;
        projectToUpdate.References = project.References;
        projectToUpdate.Group = project.Group;
        
        _context.Projects.Update(projectToUpdate);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveProjectAsync(Project project)
    {
        var projectToRemove = await _context.Projects
            .Include(p => p.Group)
            .Include(p => p.References)
            .FirstOrDefaultAsync(p => p.Id == project.Id);
        
        if (projectToRemove is null || project.IsDeleted)
            throw new NotFoundExcecption($"Projeto com id {project.Id} não encontrado.");
        
        projectToRemove.IsDeleted = true;
        
        _context.Projects.Update(projectToRemove);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateStudentAsync(Student student)
    {
        var studentToUpdate = await _context.Students
            .FirstOrDefaultAsync(s => s.Id == student.Id);
        
        if (studentToUpdate is null)
            throw new NotFoundExcecption($"Estudante com id {student.Id} não encontrado.");
        
        studentToUpdate.Name = student.Name;
        studentToUpdate.Role = student.Role;
        
        _context.Students.Update(studentToUpdate);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveStudentAsync(Student student)
    {
        var studentToRemove = await _context.Students
            .FirstOrDefaultAsync(s => s.Id == student.Id);
        
        if (studentToRemove is null)
            throw new NotFoundExcecption($"Estudante com id {student.Id} não encontrado.");
        
        _context.Students.Remove(studentToRemove);
        await _context.SaveChangesAsync();
    }
}