using Core.Entities;

namespace Core.Interfaces;

public interface IRepository
{
    public void AddGroup(Group group);
    public List<Group> ListAllGroups();
    public Group? GetGroupById(int id);
    public void UpdateGroup(Group group);
    
    public List<Presentation> ListAllPresentations();
    public Presentation? GetPresentationById(int id);
    public void UpdatePresentation(Presentation presentation);
    
    public Student? GetStudentById(int id);
    public List<Student> ListAllStudents();
    public void UpdateStudent(Student student);
    public void DeleteStudent(Student student);
}