using AutoMapper;
using Models.DTO.Request;
using Models.Models;
using Models.Repositories.DataContext;
using Services.Contracts;

namespace Services.Services
{
    public class GroupService : IGroupService
    {
        private readonly IMapper _mapper;
        private readonly EmsContext _context;
        public GroupService(IMapper mapper, EmsContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public void CreateGroup(GroupDTO groupDTO)
        {
            var userIds = groupDTO.UserIds ?? new List<int>();
            var users = _context.Users.Where((user) => userIds.Contains(user.Id));

            var group = _mapper.Map<Group>(groupDTO);

            _context.Groups.Add(group);
            _context.SaveChanges();
        }

        public void DeleteGroup(int id)
        {
            var group = _context.Groups.Find(id);

            if (group == null)
            {
                throw new Exception("Cannot delete group of null");
            }

            _context.Groups.Remove(group);
            _context.SaveChanges();
        }

        public Group GetGroupById(int id)
        {
            var group = _context.Groups.Find(id);
            if (group == null)
            {
                throw new Exception("Group is null");
            }

            return group;
        }

        public List<Group> GetGroupList(int offset = 0, int limit = 8, string query = "", string queryType = "name")
        {
            return _context.Groups
                .Where((group) => query.Contains(group.Name) || group.Name.Contains(query))
                .Skip(offset)
                .Take(limit)
                .ToList();
        }

        public int GetGroupListCount(int offset, int limit, string query, string queryType)
        {
            return _context.Groups
                .Where((group) => query.Contains(group.Name) || group.Name.Contains(query))
                .Skip(offset)
                .Take(limit)
                .Count();
        }

        public void UpdateGroup(int id, GroupDTO groupDTO)
        {
            var userIds = groupDTO.UserIds ?? new List<int>();
            var users = _context.Users.Where(user => userIds.Contains(user.Id)).ToList();
            var group = _mapper.Map<Group>(groupDTO);

            group.Id = id;
            group.Users = users;
            _context.Groups.Update(group);
            _context.SaveChanges();
        }
    }
}
