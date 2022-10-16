using AutoMapper;
using Models.DTO.Request;
using Models.Enums;
using Models.Models;
using Models.Repositories.DataContext;
using Services.Contracts;
using System.Data.SqlTypes;

namespace Services.Services
{
    public class SalaryDeltaService : ISalaryDeltaService
    {
        private readonly IMapper _mapper;
        private readonly EmsContext _context;
        public SalaryDeltaService(IMapper mapper, EmsContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public void CreateSalaryDelta(SalaryDeltaDTO salaryDeltaDTO)
        {
            var salaryDelta = _mapper.Map<SalaryDelta>(salaryDeltaDTO);
            var groupId = salaryDeltaDTO.GroupId;
            var group = _context.Groups.Find(groupId);

            salaryDelta.Group = group;
            _context.SalaryDeltas.Add(salaryDelta);
            _context.SaveChanges();
        }

        public void DeleteSalaryDelta(int id)
        {
            var salaryDelta = _context.SalaryDeltas.Find(id);
            if (salaryDelta == null)
            {
                throw new Exception("Cannot delete salary delta of null");
            }

            _context.SalaryDeltas.Remove(salaryDelta);
            _context.SaveChanges();
        }

        public SalaryDelta GetSalaryDeltaById(int id)
        {
            var salaryDelta = _context.SalaryDeltas.Find(id);
            if (salaryDelta == null)
            {
                throw new Exception("Cannot delete salary delta of null");
            }

            return salaryDelta;
        }

        public List<SalaryDelta> GetSalaryDeltaList(
            int offset, 
            int limit, 
            string? query, 
            string? queryType
            )
        {
            return getSalaryDeltaListQuery(offset, limit, query, queryType).ToList();
        }

        public int GetSalaryDeltaListCount(string? query = "", string? queryType = "deduction")
        {
            return getSalaryDeltaListQuery(0, int.MaxValue, query, queryType)
                .Count();
        }

        private IQueryable<SalaryDelta> getSalaryDeltaListQuery(int offset, int limit, string? query = "", string? queryType = "deduction")
        {
            IQueryable<SalaryDelta> salaryDeltaQuery;

            if (queryType == "deduction")
            {
                salaryDeltaQuery = _context.SalaryDeltas.Where(sd => sd.Type == SalaryDeltaType.Deduction);
            }
            else if (queryType == "allowance")
            {
                salaryDeltaQuery = _context.SalaryDeltas.Where(sd => sd.Type == SalaryDeltaType.Deduction);
            }
            else
            {
                salaryDeltaQuery = _context.SalaryDeltas.Where(sd => sd.Type == SalaryDeltaType.Deduction);
            }

            return salaryDeltaQuery
                .Where((salaryDelta) => salaryDelta.Name.Contains(query) || query.Contains(salaryDelta.Name))
                .Skip(offset)
                .Take(limit)
                .OrderByDescending(p => p.ToMonth);
        }

        public void UpdateSalaryDelta(int id, SalaryDeltaDTO salaryDeltaDTO)
        {
            var salaryDelta = _context.SalaryDeltas.Find(id);
            if (salaryDelta == null)
            {
                throw new Exception("Cannot update salary delta of null");
            }

            var group = _context.Groups.Find(id);

            var mapped = _mapper.Map<SalaryDelta>(salaryDeltaDTO);
            mapped.Id = id;
            mapped.Group = group;

            _context.SalaryDeltas.Update(mapped);
            _context.SaveChanges();
        }
    }
}
