using AutoMapper;
using Models.DTO.Request;
using Models.Models;
using Models.Repositories.DataContext;

namespace Services.Services
{
    public class GroupService 
    {
        private EmsContext _context;
        private IMapper _mapper;
        public GroupService(EmsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Group> GetGroupList(
            int offset = 0,
            int limit = 8,
            string? query = "", 
            string? queryType = "name")
        {
            return getGroupListQuery(offset, limit, query, queryType)
                .ToList();
        }

        public int GetGroupListCount(string? query = "", string? queryType = "")
        {
            return getGroupListQuery(0, int.MaxValue, query, queryType)
                .Count();

        }

        public IQueryable<Group> getGroupListQuery(int offset, int limit, string? query = "", string? queryType = "")
        {
            return _context.Groups
                .Where(group => group.Name.Contains(query) || query.Contains(group.Name))
                .Skip(offset)
                .Take(limit)
            ;
        }

        public Group GetGroupById(int id, bool loadUser = false)
        {
            var group = _context.Groups.Find(id);
            if (group == null)
            {
                throw new Exception("Cannot find group by id");
            }

            if (loadUser)
            {
                _context.Entry(group)
                    .Collection(g => g.Users)
                    .Load();
            }

            return group;
        }

        public void CreateGroup(GroupDTO groupDTO)
        {
            if (groupDTO.UserIds == null)
            {
                groupDTO.UserIds = new List<int>();
            }

            var users = _context.Users.Where(u => groupDTO.UserIds.Contains(u.Id)).ToList();
            var group = _mapper.Map<Group>(groupDTO);
            group.Users = users;

            _context.Groups.Add(group);
            _context.SaveChanges();
            
        }

        public void UpdateGroup(int id, GroupDTO groupDTO)
        {

            var group = _context.Groups.Find(id);
            if (group == null)
            {
                throw new Exception("Group not found");
            }

            _context.Entry(group).Collection(group => group.Users).Load();
            group.Users = null;
            _context.Groups.Update(group);
            _context.SaveChanges();

                group.Users = _context.Users.Where(user => groupDTO.UserIds.Contains(user.Id)).ToList();
            group.Name = groupDTO.Name;
            group.Description = groupDTO.Description;

            _context.Groups.Update(group);
            _context.SaveChanges();
        }

        public void DeleteGroup(int id)
        {
            var group = _context.Groups.Find(id);
            if (group == null)
            {
                throw new Exception("Cannot find group by id");
            }

            _context.Groups.Remove(group);
            _context.SaveChanges();
        }

        public List<User> GetUsersOfGroup(int id)
        {
            var group = _context.Groups.Find(id);
            if(group == null)
            {
                throw new Exception("Group not found");
            }

            _context.Entry(group).Collection(g => g.Users).Load();

            return group.Users ?? new List<User>();
        }
    }
}
