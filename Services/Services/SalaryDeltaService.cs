using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models.DTO.Request;
using Models.Enums;
using Models.Models;
using Models.Repositories.DataContext;
using Services.Contracts;
using System.Data.SqlTypes;
using System.Linq.Expressions;

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
            var group = _context.Groups.Find(salaryDeltaDTO.GroupId);

            if (group == null)
            {
                throw new Exception("Group not found");
            }

            var type = SalaryDeltaType.Deduction;
            if (salaryDeltaDTO.Type == "Deduction")
            {
                type = SalaryDeltaType.Deduction;
            }
            else if (salaryDeltaDTO.Type == "Allowance")
            {
                type = SalaryDeltaType.Allowance;
            }
            else if (salaryDeltaDTO.Type == "Bonus")
            {
                type = SalaryDeltaType.Bonus;
            }


            var mapped = _mapper.Map<SalaryDelta>(salaryDeltaDTO);

            mapped.Type = type;
            mapped.FromMonth = new DateTime(salaryDeltaDTO.Year, salaryDeltaDTO.FromMonth, 1);
            mapped.ToMonth = new DateTime(salaryDeltaDTO.Year, salaryDeltaDTO.ToMonth,
                DateTime.DaysInMonth(salaryDeltaDTO.Year, salaryDeltaDTO.ToMonth));
            mapped.GroupId = group.Id;

            _context.SalaryDeltas.Add(mapped);
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
            var salaryDelta = _context.SalaryDeltas.Where(sd => sd.Id == id)
                .Include(sd => sd.Group)
                .Single();

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

        public int GetSalaryDeltaListCount(string? query = "", string? queryType = "")
        {
            return getSalaryDeltaListQuery(0, int.MaxValue, query, queryType)
                .Count();
        }

        private IQueryable<SalaryDelta> getSalaryDeltaListQuery(int offset, int limit, string? query = "", string? queryType = "")
        {
            if (query == null)
            {
                query = "";
            }

            IQueryable<SalaryDelta> salaryDeltaQuery;

            if (queryType == "deduction")
            {
                salaryDeltaQuery = _context.SalaryDeltas.Where(sd => sd.Type == SalaryDeltaType.Deduction);
            }
            else if (queryType == "allowance")
            {
                salaryDeltaQuery = _context.SalaryDeltas.Where(sd => sd.Type == SalaryDeltaType.Allowance);
            }
            else if (queryType == "bonus")
            {
                salaryDeltaQuery = _context.SalaryDeltas.Where(sd => sd.Type == SalaryDeltaType.Bonus);
            }
            else
            {
                salaryDeltaQuery = _context.SalaryDeltas.AsQueryable();
            }


            return salaryDeltaQuery
                .Where((salaryDelta) => salaryDelta.Name.Contains(query) || query.Contains(salaryDelta.Name))
                .Skip(offset)
                .Take(limit)
                .OrderByDescending(p => p.ToMonth);
        }

        public void UpdateSalaryDelta(int id, SalaryDeltaDTO salaryDeltaDTO)
        {
            var group = _context.Groups.Find(salaryDeltaDTO.GroupId);

            if (group == null)
            {
                throw new Exception("Group not found");
            }

            var type = SalaryDeltaType.Deduction;
            if (salaryDeltaDTO.Type == "Deduction")
            {
                type = SalaryDeltaType.Deduction;
            }
            else if (salaryDeltaDTO.Type == "Allowance")
            {
                type = SalaryDeltaType.Allowance;
            }
            else if (salaryDeltaDTO.Type == "Bonus")
            {
                type = SalaryDeltaType.Bonus;
            }


            var mapped = _mapper.Map<SalaryDelta>(salaryDeltaDTO);

            mapped.Id = id;
            mapped.Type = type;
            mapped.FromMonth = new DateTime(salaryDeltaDTO.Year, salaryDeltaDTO.FromMonth, 1);
            mapped.ToMonth = new DateTime(salaryDeltaDTO.Year, salaryDeltaDTO.ToMonth,
                DateTime.DaysInMonth(salaryDeltaDTO.Year, salaryDeltaDTO.ToMonth));
            mapped.GroupId = group.Id;


            _context.SalaryDeltas.Update(mapped);
            _context.SaveChanges();
        }
    }
}
