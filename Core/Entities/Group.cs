﻿namespace Core.Entities
{
    public class Group
    {
        public int Id { get; private set; }
        public List<Presentation> Presentations { get; private set; }
        public List<Student> GroupMembers { get; private set; } 
        public string Subject { get; private set; }
        public Guid PrivateKey { get; private set; }

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
            GroupMembers.Add(student);
        }
    }
}