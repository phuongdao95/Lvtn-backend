using Models.DTO.Request;
using Models.Models;

namespace Services.Contracts
{
    public interface IGroupService
    {
        public Group GetGroupById(int id, bool loadUser);
        public List<Group> GetGroupList(int offset, int limit, string? query = "", string? queryType = "");
        public int GetGroupListCount(string? query = "", string? queryType = "");
        public void CreateGroup(GroupDTO groupDTO);
        public void UpdateGroup(int id, GroupDTO groupDTO);
        public void DeleteGroup(int id);
        public List<User> GetUsersOfGroup(int id);
    }
}
