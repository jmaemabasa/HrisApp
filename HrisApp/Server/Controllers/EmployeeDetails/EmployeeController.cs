using HrisApp.Client.Pages.Employee;
using HrisApp.Shared.Models.StaticData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.EmployeeDetails
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext _context;

        public EmployeeController(DataContext context)
        {
            _context = context;
        }

        ///GET EMPLOYEEE
        [HttpGet]
        public async Task<ActionResult<List<EmployeeT>>> GetEmployeeList()
        {
            var emp = await _context.EmployeeT
                .Include(em => em.Status)
                .Include(em => em.EmploymentStatus)
                .Include(em => em.EmerRelationship)
                .Include(em => em.Gender)
                .Include(em => em.CivilStatus)
                .Include(em => em.Religion)
                .Include(em => em.Division)
                .Include(em => em.Department)
                .Include(em => em.Area)
                .Include(em => em.Position)
                .Include(em => em.InactiveStatus)
                .ToListAsync();
            return Ok(emp);
        }

        [HttpGet("GetEmployee")]
        public async Task<ActionResult<List<EmployeeT>>> GetEmployee()
        {
            var emp = await _context.EmployeeT
                .Include(em => em.Status)
                .Include(em => em.EmploymentStatus)
                .Include(em => em.EmerRelationship)
                .Include(em => em.Gender)
                .Include(em => em.CivilStatus)
                .Include(em => em.Religion)
                .Include(em => em.Division)
                .Include(em => em.Department)
                .Include(em => em.Area)
                .Include(em => em.Position)
                .Include(em => em.InactiveStatus)
                .ToListAsync();
            return Ok(emp);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeT>> GetSingleEmployee(int id)
        {
            var user = await _context.EmployeeT
                .Include(em => em.Status)
                .Include(em => em.EmploymentStatus)
                .Include(em => em.EmerRelationship)
                .Include(em => em.Gender)
                .Include(em => em.CivilStatus)
                .Include(em => em.Religion)
                .Include(em => em.Division)
                .Include(em => em.Department)
                .Include(em => em.Area)
                .Include(em => em.Position)
                .Include(em => em.InactiveStatus)
                .FirstOrDefaultAsync(h => h.Id == id);
            if (user == null)
            {
                return NotFound("sorry no users here");
            }
            return Ok(user);
        }

        private async Task<List<EmployeeT>> GetDBEmployee()
        {
            return await _context.EmployeeT
                .Include(em => em.Status)
                .Include(em => em.EmploymentStatus)
                .Include(em => em.EmerRelationship)
                .Include(em => em.Gender)
                .Include(em => em.CivilStatus)
                .Include(em => em.Religion)
                .Include(em => em.Division)
                .Include(em => em.Department)
                .Include(em => em.Area)
                .Include(em => em.Position)
                .Include(em => em.InactiveStatus)
                .ToListAsync();
        }

        //CREATE AND UPDATEEEE EMPLOYEEE

        [HttpPost("CreateEmployee")]
        public async Task<ActionResult<List<EmployeeT>>> CreateEmployee(EmployeeT employee)
        {
            _context.EmployeeT.Add(employee);
            await _context.SaveChangesAsync();

            return Ok(await GetDBEmployee());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<EmployeeT>>> UpdateEmployee(EmployeeT employee, int id)
        {
            var dbEmployee = await _context.EmployeeT
                .Include(em => em.Status)
                .Include(em => em.EmploymentStatus)
                .Include(em => em.EmerRelationship)
                .Include(em => em.Gender)
                .Include(em => em.CivilStatus)
                .Include(em => em.Religion)
                .Include(em => em.Division)
                .Include(em => em.Department)
                .Include(em => em.Area)
                .Include(em => em.Position)
                .Include(em => em.InactiveStatus)
                
                .FirstOrDefaultAsync(e => e.Id == employee.Id);

            if (dbEmployee != null)
            {
                dbEmployee.FirstName = employee.FirstName;
                dbEmployee.LastName = employee.LastName;
                dbEmployee.MiddleName = employee.MiddleName;
                dbEmployee.Extension = employee.Extension;
                dbEmployee.Height = employee.Height;
                dbEmployee.Weight = employee.Weight;
                dbEmployee.Nationality = employee.Nationality;
                dbEmployee.Birthdate = employee.Birthdate;
                dbEmployee.Age = employee.Age;
                dbEmployee.MobileNumber = employee.MobileNumber;
                dbEmployee.Email = employee.Email;
                dbEmployee.DateHired = employee.DateHired;
                dbEmployee.DateInactiveStatus = employee.DateInactiveStatus;
                dbEmployee.EmployeeNo = employee.EmployeeNo;

                dbEmployee.EmerName = employee.EmerName;
                dbEmployee.EmerRelationshipId = employee.EmerRelationshipId;
                dbEmployee.EmerAddress = employee.EmerAddress;
                dbEmployee.EmerMobNum = employee.EmerMobNum;

                dbEmployee.GenderId = employee.GenderId;
                dbEmployee.CivilStatusId = employee.CivilStatusId;
                dbEmployee.ReligionId = employee.ReligionId;
                dbEmployee.DivisionId = employee.DivisionId;
                dbEmployee.DepartmentId = employee.DepartmentId;
                dbEmployee.SectionId = employee.SectionId;
                dbEmployee.PositionId = employee.PositionId;
                dbEmployee.AreaId = employee.AreaId;
                dbEmployee.StatusId = employee.StatusId;
                dbEmployee.EmploymentStatusId = employee.EmploymentStatusId;
                dbEmployee.InactiveStatusId = employee.InactiveStatusId;

                await _context.SaveChangesAsync();
            }
            return Ok(await GetDBEmployee());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<EmployeeT>>> DeleteEmployee(int id)
        {
            var dbemp = await _context.EmployeeT
                .FirstOrDefaultAsync(h => h.Id == id);
            if (dbemp == null)
                return NotFound("Sorry, but no senior");

            _context.EmployeeT.Remove(dbemp);

            await _context.SaveChangesAsync();

            return Ok(dbemp);
        }
    }
}
