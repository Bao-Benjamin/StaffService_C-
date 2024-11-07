using Microsoft.AspNetCore.Mvc;
using StaffServices.Models;
using StaffServices.Repositories;
[Route("api123  /employees")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository employeeRepository;

    public EmployeeController(IEmployeeRepository employeeRepository)
    {
        this.employeeRepository = employeeRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployees()
    {
        try
        {
            var employees = await employeeRepository.GetEmployees();
            return Ok(employees);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
        }
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<Staff>> GetEmployee(int id)
    {
        try
        {
            var result = await employeeRepository.GetEmployee(id);
            if (result == null)
                return NotFound();
            return result;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, 
                "Error retrieving data from the database");
        }
    }

    [HttpPost]
    public async Task<ActionResult<Staff>> CreateEmployee(Staff staff)
    {
        try
        {
            if (staff == null)
            
            {
                return BadRequest();
            }

            var createdEmployee = await employeeRepository.AddEmployee(staff);

            return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.EmployeeId }, createdEmployee);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, 
                "Error retrieving data from the database");
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Staff>> UpdateEmployee(int id, Staff staff)
    {
        try
        {
            if (id != staff.EmployeeId)
                return BadRequest("Employee ID mismatch");

            var employeeToUpdate = await employeeRepository.GetEmployee(id);

            if (employeeToUpdate == null)
                return NotFound($"Employee with Id = {id} not found");

            return await employeeRepository.UpdateEmployee(staff);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, 
                "Error updating data");
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Staff>> DeleteEmployee(int id)
    {
        try
        {
            var employeeToDelete = await employeeRepository.GetEmployee(id);

            if (employeeToDelete == null)
            {
                return NotFound($"Employee with Id = {id} not found");
            }

            return await employeeRepository.DeleteEmployee(id);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, 
                "Error deleting data");
        }
    }

}