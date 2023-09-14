using Core.Entities;

namespace Api.Service
{
    public class GroupService
    {
        private List<Group> groups = new List<Group>();

        public List<Group> GetAllGroups()
        {
            return groups;
        }

        public void AddGroup(Group group)
        {
            groups.Add(group);
        }
    }
}