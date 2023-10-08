using Core.ValueObjects;
using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class Presentation
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Body { get; private set; }
        public List<Url> References { get; private set; }
        public bool IsDeleted { get; private set; }
        public int GroupId { get; set; }


        [JsonIgnore] public Group Group { get; set; }

        public Presentation()
        {

        }
        public Presentation(string title, string description, Group group, string body, List<Url> references)
        {
            Title = title;
            Description = description;
            Group = group;
            Body = body;
            References = references;
        }

        public void SoftDelete() => IsDeleted = true;
    }
}