using Core.Entities;

namespace Core.Interfaces;

public interface IRepository
{
    public void AddPresentation(Presentation presentation);
    public List<Presentation> ListAllPresentations();
    public Presentation GetPresentationById(int id);
    public void UpdatePresentation(Presentation presentation);
    public void DeletePresentation(Presentation presentation);
    
    public void AddGroup(Group group);
    public List<Group> ListAllGroups();
    public Group GetGroupById(int id);
    public void UpdateGroup(Group group);
    public void DeleteGroup(Group group);
    
    public void AddStudent(Student student);
    public Student? GetStudentById(int id);
    public List<Student> ListAllStudents();
    public void UpdateStudent(Student student);
    public void DeleteStudent(Student student);
}