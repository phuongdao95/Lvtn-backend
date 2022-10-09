using AutoMapper;
using Models.DTO.Request;
using Models.Models;
using Models.Repositories.DataContext;
using Services.Contracts;

namespace Services.Services
{
    public class SalaryGroupService : ISalaryGroupService
    {
        private readonly IMapper _mapper;
        private readonly EmsContext _context;
        public SalaryGroupService(IMapper mapper, EmsContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public void CreateSalaryGroup(SalaryGroupDTO salaryGroupDTO)
        {
            var group = _context.Groups.Find(salaryGroupDTO.GroupId);
            if (group == null)
            {
                throw new Exception("Cannot find group for salary group");
            }

            var salaryGroup = _mapper.Map<SalaryGroup>(salaryGroupDTO);

            _context.SalaryGroups.Add(salaryGroup);
            _context.SaveChanges();
        }

        public void DeleteSalaryGroup(int id)
        {
            var group = _context.SalaryGroups.Find(id);

            if (group == null)
            {
                throw new Exception("Cannot delete group of null");
            }

            _context.SalaryGroups.Remove(group);
            _context.SaveChanges();
        }

        public SalaryGroup GetSalaryGroupById(int id)
        {
            var group = _context.SalaryGroups.Find(id);
            if (group == null)
            {
                throw new Exception("Group is null");
            }

            return group;
        }

        public List<SalaryGroup> GetSalaryGroupList(int offset = 0, int limit = 8, string query = "", string queryType = "name")
        {

            var salaryGroupList = _context.SalaryGroups
                .Where((group) => query.Contains(group.Name) || group.Name.Contains(query))
                .Skip(offset)
                .Take(limit)
                .ToList();

            foreach(var salaryGroup in salaryGroupList)
            {
                _context.Entry(salaryGroup)
                    .Reference(s => s.Group)
                    .Load();
            }

            return salaryGroupList;
        }

        public int GetSalaryGroupCount(int offset, int limit, string query, string queryType)
        {
            return _context.SalaryGroups
                .Where((group) => query.Contains(group.Name) || group.Name.Contains(query))
                .Skip(offset)
                .Take(limit)
                .Count();
        }

        public void UpdateSalaryGroup(int id, SalaryGroupDTO groupDTO)
        {
            //var userIds = groupDTO.UserIds ?? new List<int>();
            //var users = _context.Users.Where(user => userIds.Contains(user.Id)).ToList();
            var group = _mapper.Map<SalaryGroup>(groupDTO);

            group.Id = id;
            //group.Users = users;
            _context.SalaryGroups.Update(group);
            _context.SaveChanges();
        }
    }
}
