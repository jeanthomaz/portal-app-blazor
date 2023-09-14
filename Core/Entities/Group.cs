namespace Core.Entities
{
    public class Group
    {
        public readonly Guid Id;
        public readonly List<Presentation> Presentations;
        public List<Student> GroupMembers { get; set; } 
        public readonly string Subject;
        public readonly Guid PrivateKey;
        public string CreatedByUserId { get; private set; }

        /// <summary>
        /// Construtor pra ORM. Não deve ser utilizado em código.
        /// </summary>
        [Obsolete]
        public Group()
        {
        }

        public Group(string subject, List<Student> groupMembers, List<Presentation> presentations, string createdByUserId)
        {
            Id = Guid.NewGuid();
            Subject = subject;
            GroupMembers = groupMembers;
            Presentations = presentations;
            PrivateKey = Guid.NewGuid();
            CreatedByUserId = createdByUserId; 
        }
    }
}