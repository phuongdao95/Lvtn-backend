﻿using Models.DTO.Request;
using Models.Models;

namespace Services.Contracts
{
    public interface IGroupService
    {
        public void CreateGroup(GroupDTO groupDTO);
        public void UpdateGroup(int id, GroupDTO groupDTO);
        public void DeleteGroup(int id);
        public SalaryGroup GetGroupById(int id);
        public List<SalaryGroup> GetGroupList(int offset, int limit, string? query = "", string? queryType = "name");
        public int GetGroupListCount(int offset, int limit, string? query = "", string? queryType = "name");
    }
}
