using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DTO.Request;
using Models.DTO.Response;
using Models.Enums;
using Models.Repositories.DataContext;
using Services.Services;

namespace lvtn_backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SalaryFormulaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly EmsContext _emsContext;
        private readonly SalaryFormulaService _formulaService;

        public SalaryFormulaController(
            EmsContext emsContext,
            IMapper mapper,
            SalaryFormulaService formulaService)
        {
            _mapper = mapper;
            _emsContext = emsContext;
            _formulaService = formulaService;
        }

        [HttpGet]
        public IActionResult GetFormulaList(
            [FromQuery] string? query = "",
            [FromQuery] string? queryType = "area")
        {
            try
            {
                var result = new Dictionary<string, object>();

                var formulaList = _formulaService.GetFormulaList(query, queryType);
                var formulaListTotal = _formulaService.GetFormulaListCount(query, queryType);
                var formulaInfoList = _mapper.Map<IEnumerable<SalaryFormulaInfoDTO>>(formulaList);

                return Ok(new Dictionary<string, object>
                {
                    { "data", formulaInfoList },
                    { "total", formulaListTotal },
                    { "count", formulaInfoList.Count()}
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetFormulaById(int id)
        {
            try
            {
                var formulaDTO = _formulaService.GetFormulaById(id);
                var mapped = _mapper.Map<SalaryFormulaInfoDTO>(formulaDTO);

                return Ok(mapped);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult CreateFormula(SalaryFormulaDTO formulaDTO)
        {
            try
            {
                _formulaService.CreateFormula(formulaDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("/api/salaryvariable/validation/formulaDefine")]
        public IActionResult CheckIfVariableDefinitionValid(SalaryVariableDTO salaryFormulaDto)
        {
            try
            {
                var dataType = new VariableDataType();
                if (salaryFormulaDto.DataType == "Decimal")
                {
                    dataType = VariableDataType.Decimal;
                }
                else if (salaryFormulaDto.DataType == "Integer")
                {
                    dataType = VariableDataType.Integer;
                }
                else if (salaryFormulaDto.DataType == "Text")
                {
                    dataType = VariableDataType.Text;
                }
                else if (salaryFormulaDto.DataType == "Boolean")
                {
                    dataType = VariableDataType.Boolean;
                }

                var isValid = _formulaService.CheckIfVariableDefineValid(salaryFormulaDto.Value ?? "", dataType);
                return Ok(new Dictionary<string, object>
                {
                    ["value"] = isValid
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }



        [HttpPost("/api/salaryformula/validation/formulaDefine")]
        public IActionResult CheckIfFormulaDefinitionValid(SalaryFormulaDTO salaryFormulaDto)
        {
            try
            {
                FormulaArea area = new FormulaArea();
                if (salaryFormulaDto.FormulaArea == "timekeeping")
                {
                    area = FormulaArea.Timekeeping;
                }
                else if (salaryFormulaDto.FormulaArea == "salarydelta")
                {
                    area = FormulaArea.SalaryDelta;
                }
                else
                {
                    area = FormulaArea.SalaryConfig;
                }

                var isValid = _formulaService.CheckIfFormulaDefineIsValid(salaryFormulaDto.Define ?? "", area);
                return Ok(new Dictionary<string, object>
                {
                    ["value"] = isValid
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPost("/api/salaryvariable/validation/name")]
        public IActionResult CheckIfVariableExists(SalaryVariableDTO variableDto)
        {
            try
            {
                FormulaArea area = new FormulaArea();
                if (variableDto.FormulaArea == "timekeeping")
                {
                    area = FormulaArea.Timekeeping;
                }
                else if (variableDto.FormulaArea == "salarydelta")
                {
                    area = FormulaArea.SalaryDelta;
                }
                else
                {
                    area = FormulaArea.SalaryConfig;
                }

                var doesExist = _formulaService.CheckIfVariableExistsByNameAndArea(variableDto.Name ?? "", area);

                return Ok(new Dictionary<string, object>
                {
                    ["value"] = doesExist
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("/api/salaryformula/validation/name")]
        public IActionResult CheckIfFormulaExists(SalaryFormulaDTO formulaDto)
        {
            try
            {
                FormulaArea area = new FormulaArea();
                if (formulaDto.FormulaArea == "timekeeping")
                {
                    area = FormulaArea.Timekeeping;
                }
                else if (formulaDto.FormulaArea == "salarydelta")
                {
                    area = FormulaArea.SalaryDelta;
                }
                else 
                {
                    area = FormulaArea.SalaryConfig;
                }

                var doesExist = _formulaService.CheckIfFormulaExistsByNameAndArea(formulaDto.Name, area);

                return Ok(new Dictionary<string, object>
                {
                    ["value"] = doesExist 
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFormula(int id, SalaryFormulaDTO formulaDTO)
        {
            try
            {
                _formulaService.UpdateFormula(id, formulaDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFormula(int id)
        {
            try
            {
                _formulaService.DeleteFormula(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("/api/SalaryVariable/")]
        public IActionResult CreateVariable(SalaryVariableDTO variableDTO)
        {
            try
            {
                _formulaService.CreateVariable(variableDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("/api/SalaryVariable/{id}")]
        public IActionResult GetVariableById(int id)
        {
            try
            {
                var variable = _formulaService.GetVariableById(id);
                var variableInfoDTO = _mapper.Map<SalaryVariableInfoDTO>(variable);
                
                return Ok(variableInfoDTO);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("/api/SalaryVariable/")]
        public IActionResult GetVariableList(
            [FromQuery(Name = "kind")] string? query = "",
            [FromQuery] string? queryType = "area")
        {
            try
            {
                var variableList = _formulaService.GetVariableList(query, queryType);
                var total = _formulaService.GetVariableListCount(query, queryType);
                var data = _mapper.Map<IEnumerable<SalaryVariableInfoDTO>>(variableList);
                var count = data.Count();

                return Ok(new Dictionary<string, object>
                {
                    {"data", data },
                    {"total", total },
                    {"count", count}
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("/api/SalaryVariable/{id}")]
        public IActionResult UpdateVariable(int id, SalaryVariableDTO variableDTO)
        {
            try
            {
                _formulaService.UpdateVariable(id, variableDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("/api/SalaryVariable/{id}")]
        public IActionResult DeletVariable(int id)
        {
            try
            {
                _formulaService.DeleteVariable(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("/api/SalarySystemVariable")]
        public IActionResult GetSystemVariableList([FromQuery(Name = "kind")] string type)
        {
            try
            {
                SalarySystemVariableKind kind;
                if (type == "salarygroup")
                {
                    kind = SalarySystemVariableKind.SalaryGroup;
                }
                else if (type == "salarydelta")
                {
                    kind = SalarySystemVariableKind.SalaryDelta;
                }
                else if (type == "timekeeping")
                {
                    kind = SalarySystemVariableKind.Timekeeping;
                }
                else if (type == "kpi")
                {
                    kind = SalarySystemVariableKind.KPI;
                }
                else
                {
                    throw new Exception("Variable kind not found.");
                }

                var data = _formulaService.GetSystemVariables(kind);
                var count = data.Count();
                var total = data.Count();

                return Ok(new Dictionary<string, object>
                {
                    { "data", data },
                    { "count", count },
                    { "total", total }
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
