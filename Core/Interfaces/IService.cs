using Core.Entities;

namespace Core.Interfaces;

public interface IService
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
    
    public void AddStudentToGroup(Student student, int groupId);
    public List<Student> ListAllStudents();
    public void UpdateStudent(Student student);
    public void DeleteStudent(Student student);
}