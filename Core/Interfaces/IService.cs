using Core.Entities;

namespace Core.Interfaces;

public interface IService
{
    public void AddPresentationInGroup(Presentation presentation, int groupId);
    public List<Presentation> ListAllPresentations();
    public Presentation GetPresentationById(int id);
    public void UpdatePresentation(int presentationId);
    public void DeletePresentation(int presentationId);
    
    public void AddGroup(Group group);
    public List<Group> ListAllGroups();
    public Group GetGroupById(int id);
    public void UpdateGroup(int groupId);
    public void DeleteGroup(int groupId);
    
    public void AddStudentToGroup(Student student, int groupId);
    public List<Student> ListAllStudents();
    public void UpdateStudent(int studentId);
    public void DeleteStudent(int studentId);
}