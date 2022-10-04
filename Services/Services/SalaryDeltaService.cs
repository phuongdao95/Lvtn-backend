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
            var userIds = salaryDeltaDTO.UserIds ?? new List<int>();
            var users = _context.Users.Where((user) => userIds.Contains(user.Id)).ToList();

            //salaryDelta.Users = users;
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
            SalaryDeltaType type,
            string? query, 
            string? queryType
            )
        {
            var salaryDeltaList = _context.SalaryDeltas.Where((salaryDelta) => salaryDelta.Type == type);

            return salaryDeltaList
                .Where((salaryDelta) => salaryDelta.Name.Contains(query) || query.Contains(salaryDelta.Name))
                .Skip(offset)
                .Take(limit)
                .ToList();
        }

        public int GetSalaryDeltaListCount(int offset, int limit, SalaryDeltaType type, string? query = "", string? queryType = "name")
        {
            return GetSalaryDeltaList(offset, limit, type, query, queryType)
                .Count();
        }

        public void UpdateSalaryDelta(int id, SalaryDeltaDTO salaryDeltaDTO)
        {
            var salaryDelta = _context.SalaryDeltas.Find(id);
            if (salaryDelta == null)
            {
                throw new Exception("Cannot update salary delta of null");
            }

            var mapped = _mapper.Map<SalaryDelta>(salaryDeltaDTO);
            mapped.Id = id;

            _context.SalaryDeltas.Update(mapped);
            _context.SaveChanges();
        }
    }
}
