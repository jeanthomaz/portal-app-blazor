namespace Core.Entities
{
    public class Group
    {
        public int Id { get; private set; }
        public List<Presentation> Presentations { get; private set; }
        public List<Student> GroupMembers { get; private set; } 
        public string Subject { get; private set; }
        public Guid PrivateKey { get; private set; }
        private const int MaxGroupSize = 5;

        /// <summary>
        /// Construtor pra ORM. Não deve ser utilizado em código.
        /// </summary>
        [Obsolete]
        public Group()
        {
        }

        public Group(string subject, List<Student> groupMembers, List<Presentation> presentations)
        {
            Subject = subject;
            GroupMembers = groupMembers;
            Presentations = presentations;
            PrivateKey = Guid.NewGuid();
        }
        
        public void AddStudent(Student student)
        {
            if (GroupMembers.Contains(student))
                throw new Exception("Aluno já está no grupo.");

            if (GroupMembers.Count == MaxGroupSize)
                throw new Exception($"Grupo está cheio. O limite de {MaxGroupSize} alunos foi atingido.");
            
            GroupMembers.Add(student);
        }
    }
}