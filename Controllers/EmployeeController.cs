using API.DTOS;
using API.EmployeesData;
using API.Model;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeData _repository;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeData repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

       // private readonly MockEmployeeData _repository = new MockEmployeeData();
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAllCommands()
        {
            var commandItem = _repository.GetAllCommand();

            return Ok(_mapper.Map<IEnumerable<EmployeeReadDtos>>(commandItem));

        }

        [HttpGet("{id}")]
        public ActionResult <Employee> GetCommandById(int id)
        {

            var CommandItem = _repository.GetCommandById(id);
            if(CommandItem != null)
            {
                return Ok(_mapper.Map<EmployeeReadDtos>(CommandItem) );
            }
            return NotFound();

        }

        [HttpPost]
        public ActionResult <EmployeeReadDtos> CreateCommand(EmployeeCreateDtos employeeCreateDtos)
        {
            var employeeModel = _mapper.Map<Employee>(employeeCreateDtos);
            _repository.CreateCommand(employeeModel);
            _repository.SaveChanges();

            var employeeReadDto = _mapper.Map<EmployeeReadDtos>(employeeModel);
            return Ok();

        }

        



        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, EmployeeUpdateDtos employeeUpdate)
        {
            var employeeModelRepo = _repository.GetCommandById(id);
            if (employeeModelRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(employeeUpdate, employeeModelRepo);

            _repository.UpdateCommand(employeeModelRepo);

            _repository.SaveChanges();

            return NoContent();
        }


        // Patch /api/commands/{id}
        public ActionResult PartialCommandUpdate(int id , JsonPatchDocument<EmployeeUpdateDtos> patchDoc)
        {
            


            var employeeModelRepo = _repository.GetCommandById(id);
            if (employeeModelRepo == null)
            {
                return NotFound();
            }

            var employeePatch = _mapper.Map<EmployeeUpdateDtos>(employeeModelRepo);
            patchDoc.ApplyTo(employeePatch, ModelState);

            if (!TryValidateModel(employeePatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(employeePatch, employeeModelRepo);

            _repository.UpdateCommand(employeeModelRepo);

            _repository.SaveChanges();

            return NoContent();

        }


        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var employeeModelRepo = _repository.GetCommandById(id);
            if (employeeModelRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteCommand(employeeModelRepo);
            _repository.SaveChanges();

            return NoContent();
        }



    }
}
