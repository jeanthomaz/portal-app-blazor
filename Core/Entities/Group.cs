namespace Core.Entities
{
    public class Group
    {
        public int Id { get; private set; }
        public string Subject { get; private set; }
        public Guid PrivateKey { get; private set; }
        public bool IsDeleted { get; private set; }
        public List<Presentation> Presentations { get; set; }
        public ICollection<Student> GroupMembers { get; set; }

        /// <summary>
        /// Construtor pra ORM. Não deve ser utilizado em código.
        /// </summary>

        public void AddStudent(Student student)
        {
            // Verifique se o estudante já não está no grupo
            if (!GroupMembers.Contains(student))
            {
                // Adicione o estudante ao grupo
                GroupMembers.Add(student);
            }
        }
        public void AddPresentation(Presentation presentation)
        {
            // Verifique se a apresentação já não está no grupo
            if (!Presentations.Contains(presentation))
            {
                // Adicione a apresentação ao grupo
                Presentations.Add(presentation);
            }
        }


        public Group()
        {

        }
        public Group(string subject)
        {
            Subject = subject;
            Presentations = new List<Presentation>();
            PrivateKey = Guid.NewGuid();
            GroupMembers = new List<Student>();
        }
        
        public void SoftDelete() => IsDeleted = true;
    }
}