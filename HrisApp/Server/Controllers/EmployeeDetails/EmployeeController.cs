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
                //.Include(em => em.Position)
                //.Include(em => em.InactiveStatus)
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
                //.Include(em => em.Position)
                //.Include(em => em.InactiveStatus)
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
                //.Include(em => em.Position)
                //.Include(em => em.InactiveStatus)
                .FirstOrDefaultAsync(h => h.Id == id);
            if (user == null)
            {
                return NotFound("sorry no users here");
            }
            return Ok(user);
        }

        [HttpGet("GetSingleEmployeeByVerId/{verId}")]
        public async Task<ActionResult<EmployeeT>> GetSingleEmployeeByVerId(string verId)
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
                //.Include(em => em.Position)
                //.Include(em => em.InactiveStatus)
                .FirstOrDefaultAsync(h => h.Verify_Id == verId);
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
                //.Include(em => em.Position)
                //.Include(em => em.InactiveStatus)
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
                //.Include(em => em.Position)
                //.Include(em => em.InactiveStatus)

                .FirstOrDefaultAsync(e => e.Id == employee.Id);

            if (dbEmployee != null)
            {
                if (employee.StatusId == 1)
                {
                    var valStatus = await _context.Emp_EvaluationT.FirstOrDefaultAsync(e => e.Verify_Id == dbEmployee.Verify_Id);
                    if (valStatus != null)
                    {
                        int calculateMonth = 0;
                        int totalMonth = 12;

                        DateTime todayDate = DateTime.Now;
                        calculateMonth = todayDate.Month - employee.DateHired.Month;

                        if (calculateMonth < 0)
                        {
                            calculateMonth += totalMonth;
                        }

                        switch (calculateMonth)
                        {
                            case 0:
                                valStatus.Eval1Status = "Pending";
                                valStatus.Eval2Status = "Pending";
                                valStatus.Eval3Status = "Pending";
                                valStatus.Eval4Status = "Pending";
                                valStatus.Eval5Status = "Pending";
                                valStatus.Eval6Status = "Pending";
                                valStatus.EvalStatus = "Pending";
                                valStatus.DateEvaluate = todayDate;
                                valStatus.TimesEvaluate = +1;
                                break;

                            case 1:
                                valStatus.Eval1Status = "Pending";
                                valStatus.Eval2Status = "Pending";
                                valStatus.Eval3Status = "Pending";
                                valStatus.Eval4Status = "Pending";
                                valStatus.Eval5Status = "Pending";
                                valStatus.Eval6Status = "Pending";
                                valStatus.EvalStatus = "Pending";
                                valStatus.DateEvaluate = todayDate;
                                valStatus.TimesEvaluate = +1;
                                break;

                            case 2:
                                valStatus.Eval1Status = "Done";
                                valStatus.Eval2Status = "Pending";
                                valStatus.Eval3Status = "Pending";
                                valStatus.Eval4Status = "Pending";
                                valStatus.Eval5Status = "Pending";
                                valStatus.Eval6Status = "Pending";
                                valStatus.EvalStatus = "Pending";
                                valStatus.DateEvaluate = todayDate;
                                valStatus.TimesEvaluate = +1;
                                break;

                            case 3:
                                valStatus.Eval1Status = "Done";
                                valStatus.Eval2Status = "Done";
                                valStatus.Eval3Status = "Pending";
                                valStatus.Eval4Status = "Pending";
                                valStatus.Eval5Status = "Pending";
                                valStatus.Eval6Status = "Pending";
                                valStatus.EvalStatus = "Pending";
                                valStatus.DateEvaluate = todayDate;
                                valStatus.TimesEvaluate = +1;
                                break;

                            case 4:
                                valStatus.Eval1Status = "Done";
                                valStatus.Eval2Status = "Done";
                                valStatus.Eval3Status = "Done";
                                valStatus.Eval4Status = "Pending";
                                valStatus.Eval5Status = "Pending";
                                valStatus.Eval6Status = "Pending";
                                valStatus.EvalStatus = "Pending";
                                valStatus.DateEvaluate = todayDate;
                                valStatus.TimesEvaluate = +1;
                                break;

                            case 5:
                                valStatus.Eval1Status = "Done";
                                valStatus.Eval2Status = "Done";
                                valStatus.Eval3Status = "Done";
                                valStatus.Eval4Status = "Done";
                                valStatus.Eval5Status = "Pending";
                                valStatus.Eval6Status = "Pending";
                                valStatus.EvalStatus = "Pending";
                                valStatus.DateEvaluate = todayDate;
                                valStatus.TimesEvaluate = +1;
                                break;

                            case 6:
                                valStatus.Eval1Status = "Done";
                                valStatus.Eval2Status = "Done";
                                valStatus.Eval3Status = "Done";
                                valStatus.Eval4Status = "Done";
                                valStatus.Eval5Status = "Done";
                                valStatus.Eval6Status = "Pending";
                                valStatus.EvalStatus = "Pending";
                                valStatus.DateEvaluate = todayDate;
                                valStatus.TimesEvaluate = +1;
                                break;

                            default:
                                valStatus.Eval1Status = "Done";
                                valStatus.Eval2Status = "Done";
                                valStatus.Eval3Status = "Done";
                                valStatus.Eval4Status = "Done";
                                valStatus.Eval5Status = "Done";
                                valStatus.Eval6Status = "Done";
                                valStatus.EvalStatus = "Done";
                                valStatus.DateEvaluate = todayDate;
                                valStatus.TimesEvaluate = +1;
                                break;
                        }
                    }
                }
                else
                {
                    var valStatus = await _context.Emp_EvaluationT.FirstOrDefaultAsync(e => e.Verify_Id == dbEmployee.Verify_Id);
                    if (valStatus != null)
                    {
                        valStatus.EvalStatus = "Inactive";
                        valStatus.DateEvaluate = DateTime.Now;
                        valStatus.TimesEvaluate = +1;
                    }
                }

                if (dbEmployee.DateHired.ToString("MM/dd/yyyy") == employee.DateHired.ToString("MM/dd/yyyy"))
                {
                    Console.WriteLine("test");
                }
                else
                {
                    var evaluation = await _context.Emp_EvaluationT.FirstOrDefaultAsync(e => e.Verify_Id == dbEmployee.Verify_Id);

                    if (evaluation != null)
                    {
                        evaluation.DateHired = employee.DateHired;
                    }
                }

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
                //dbEmployee.InactiveStatusId = employee.InactiveStatusId;

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

        [HttpGet("GetEmpName/{empid}")]
        public async Task<ActionResult<List<EmployeeT>>> Getname(int empid)
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
                //.Include(em => em.Position)
                //.Include(em => em.InactiveStatus)
                .ToListAsync();

            var _response = emp.Where(e => e.Id == empid).ToList();
            return Ok(_response);
        }

        [HttpGet("EmployeeCount")]
        public async Task<ActionResult<int>> GetEmployeeCount()
        {
            var Masterlist = await _context.EmployeeT
                .ToListAsync();

            var returnCount = Masterlist.Count();
            return Ok(returnCount);
        }

        [HttpGet("GetEmployeeExist/{companyId}")]
        public async Task<ActionResult<int>> GetEmployeeExist(string companyId)
        {
            var Masterlist = await _context.EmployeeT
                .ToListAsync();
            var _isexist = Masterlist.Where(d => d.EmployeeNo == companyId).Count();

            return Ok(_isexist);
        }

    }
}
