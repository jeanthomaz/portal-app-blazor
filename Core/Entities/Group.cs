namespace Core.Entities
{
    public class Group
    {
        public int Id { get; private set; }
        public List<Student> GroupMembers { get; set; }

        /// <summary>
        /// Construtor pra ORM. Não deve ser utilizado em código.
        /// </summary>
        /// 
        public Group()
        {
        }

        public void AddStudent(Student student)
        {
            // Verifique se o estudante já não está no grupo
            if (!GroupMembers.Contains(student))
            {
                // Adicione o estudante ao grupo
                GroupMembers.Add(student);
            }
        }
        
        public void UpdateStudent(Student student)
        {
            // Verifique se o estudante já não está no grupo
            foreach (Student member in GroupMembers)
            {
                if (member.Id == student.Id)
                {
                    member.Name = student.Name;
                    member.Role = student.Role;
                }
            }
        }
        
        public void RemoveStudent(Student student)
        {
            // Verifique se o estudante já não está no grupo
            if (GroupMembers.Contains(student))
            {
                // Adicione o estudante ao grupo
                GroupMembers.Remove(student);
            }
        }
    }
}