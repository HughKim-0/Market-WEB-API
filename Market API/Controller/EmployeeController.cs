using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Market_API.Interface;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Market_API.Dto;
using Market_API.Models;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using Controller = Microsoft.AspNetCore.Mvc.Controller;

namespace Market_API.Controllers
{

        [Route("api/[employee]")]
        [ApiController]
        public class EmployeeController : Controller
        {
            private readonly IEmployeeRepository _employeeRepository;
            private readonly IMapper _mapper;
            public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper)
            {
                _employeeRepository = employeeRepository;
                _mapper = mapper;
            }

            [HttpGet]
            [ProducesResponseType(200, Type = typeof(IEnumerable<Employee>))]
            public IActionResult GetEmployees()
            {
                var employees = _mapper.Map<List<EmployeeDto>>(_employeeRepository.GetEmployees());

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(employees);
            }

            [HttpGet("{employeeId}")]
            [ProducesResponseType(200, Type = typeof(Employee))]
            [ProducesResponseType(400)]
            public IActionResult GetEmployee(int employeeId)
            {
                if (!_employeeRepository.EmployeeExists(employeeId))
                    return NotFound();

                var employee = _mapper.Map<EmployeeDto>(_employeeRepository.GetEmployee(employeeId));

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(employee);
            }

            [HttpGet("{employeeName}")]
            [ProducesResponseType(200, Type = typeof(Employee))]
            [ProducesResponseType(400)]
            public IActionResult GetEmployee(string employeeName)
            {
                if (!_employeeRepository.EmployeeExists(employeeName))
                    return NotFound();

                var employee = _mapper.Map<EmployeeDto>(_employeeRepository.GetEmployee(employeeName));

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(employee);
            }

            [HttpGet("employee/{employeeId}")]
            [ProducesResponseType(200, Type = typeof(IEnumerable<Employee>))]
            [ProducesResponseType(400)]
            public IActionResult GetEmployeeByPhone(int employeePhone)
            {
                var employee = _mapper.Map<List<EmployeeDto>>(
                    _employeeRepository.GetEmployeeByPhone(employeePhone));

                if (!ModelState.IsValid)
                    return BadRequest();

                return Ok(employee);
            }

            [HttpPost]
            [ProducesResponseType(204)]
            [ProducesResponseType(400)]
            public IActionResult CreateEmployee([FromBody] EmployeeDto employeeCreate)
            {
                if (employeeCreate == null)
                    return BadRequest(ModelState);

                var employee = _employeeRepository.GetEmployees().FirstOrDefault();

                if (employee != null)
                {
                    ModelState.AddModelError("", "Employee already exists");
                    return StatusCode(422, ModelState);
                }

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var employeeMap = _mapper.Map<Employee>(employeeCreate);

                if (!_employeeRepository.CreateEmployee(employeeMap))
                {
                    ModelState.AddModelError("", "Something went wrong while savin");
                    return StatusCode(500, ModelState);
                }

                return Ok("Successfully created");
            }

            [HttpPut("{employeeId}")]
            [ProducesResponseType(400)]
            [ProducesResponseType(204)]
            [ProducesResponseType(404)]
            public IActionResult UpdateEmployee(int employeeId, [FromBody] EmployeeDto updatedEmployee)
            {
                if (updatedEmployee == null)
                    return BadRequest(ModelState);

                if (employeeId != updatedEmployee.EmployeeId)
                    return BadRequest(ModelState);

                if (!_employeeRepository.EmployeeExists(employeeId))
                    return NotFound();

                if (!ModelState.IsValid)
                    return BadRequest();

                var employeeMap = _mapper.Map<Employee>(updatedEmployee);

                if (!_employeeRepository.UpdateEmployee(employeeMap))
                {
                    ModelState.AddModelError("", "Something went wrong updating category");
                    return StatusCode(500, ModelState);
                }

                return NoContent();
            }

            [HttpDelete("{employeeId}")]
            [ProducesResponseType(400)]
            [ProducesResponseType(204)]
            [ProducesResponseType(404)]
            public IActionResult DeleteEmployee(int employeeId)
            {
                if (!_employeeRepository.EmployeeExists(employeeId))
                {
                    return NotFound();
                }

                var employeeToDelete = _employeeRepository.GetEmployee(employeeId);

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (!_employeeRepository.DeleteEmployee(employeeToDelete))
                {
                    ModelState.AddModelError("", "Something went wrong deleting category");
                }

                return NoContent();
            }
        }
    }

