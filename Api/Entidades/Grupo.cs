namespace APIPortal.Entidades
{
    public class Group
    {
        public readonly Guid Id;
        public readonly List<Apresentação> Presentations;
        public readonly List<Estudante> GroupMembers;
        public readonly string Subject;
        public readonly Guid PrivateKey;

        
    }

}
