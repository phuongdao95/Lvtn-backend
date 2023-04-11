﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DTO.Request;
using Models.DTO.Response;
using Models.Repositories.DataContext;
using Services.Contracts;
using Services.Services;
using System.Web;

namespace lvtn_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimekeepingManageController : ControllerBase
    {
        private TimekeepingManageService _timekeepingManageService;
        private IMapper _mapper;
        public TimekeepingManageController(
            TimekeepingManageService timekeepingManageService,
            IMapper mapper)
        {
            _timekeepingManageService = timekeepingManageService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetWorkingShifts([FromQuery] int month = 0)
        {
            try
            {
                _timekeepingManageService.getUsers(month);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
