using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DTO.Request;
using Models.DTO.Response;
using Models.Models;
using Models.Repositories.DataContext;
using Services.Contracts;

namespace Services.Services
{
    public class SalaryGroupService
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

        [HttpDelete("{id}")]
        public void DeleteSalaryGroup(int id)
        {
            if (id <= 1)
            {
                throw new Exception("Cannot delete group default");
            }

            var group = _context.SalaryGroups.Find(id);

            if (group == null)
            {
                throw new Exception("Cannot delete group of null");
            }


            _context.SalaryGroups.Remove(group);
            _context.SaveChanges();
        }

        [HttpGet("{id}")]
        public SalaryGroup GetSalaryGroupById(int id)
        {
            var group = _context.SalaryGroups
                .Include(salaryGroup => salaryGroup.Group)
                .Where(salaryGroup => salaryGroup.Id == id)
                .Single();

            if (group == null)
            {
                throw new Exception("Group is null");
            }

            return group;
        }

        public List<SalaryGroup> GetSalaryGroupList(string query)
        {
            return _context.SalaryGroups
                   .Include(group => group.Group)
                   .Where(predicate: (group) => query.Contains(group.Name) || 
                        group.Name.Contains(query))
                   .ToList();
        }

        public void UpdateSalaryGroup(int id, SalaryGroupDTO groupDTO)
        {
            if (groupDTO.GroupId == null)
            {
                throw new Exception("Group not found");
            }

            var group = _mapper.Map<SalaryGroup>(groupDTO);

            group.Id = id;

            _context.SalaryGroups.Update(group);
            _context.SaveChanges();
        }
    }
}
