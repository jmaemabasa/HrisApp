using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.ApplicantDetails
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly DataContext _context;

        public ApplicantController(DataContext context)
        {
            _context = context;
        }

        ///GET APPLICANT
        [HttpGet]
        public async Task<ActionResult<List<ApplicantT>>> GetApplicantList()
        {
            var app = await _context.ApplicantT
                .Include(em => em.App_Gender)
                .Include(em => em.App_CivilStatus)
                .Include(em => em.App_Religion)
                .Include(em => em.App_EmerRelationship)
                .ToListAsync();
            return Ok(app);
        }

        [HttpGet("GetEmployee")]
        public async Task<ActionResult<List<ApplicantT>>> GetApplicant()
        {
            var app = await _context.ApplicantT
                .Include(em => em.App_Gender)
                .Include(em => em.App_CivilStatus)
                .Include(em => em.App_Religion)
                .Include(em => em.App_EmerRelationship)
                .ToListAsync();
            return Ok(app);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicantT>> GetSingleApplicant(int id)
        {
            var app = await _context.ApplicantT
                .Include(em => em.App_Gender)
                .Include(em => em.App_CivilStatus)
                .Include(em => em.App_Religion)
                .Include(em => em.App_EmerRelationship)
                .FirstOrDefaultAsync(h => h.Id == id);
            if (app == null)
            {
                return NotFound("sorry no users here");
            }
            return Ok(app);
        }

        private async Task<List<ApplicantT>> GetDBApplicant()
        {
            return await _context.ApplicantT
                .Include(em => em.App_Gender)
                .Include(em => em.App_CivilStatus)
                .Include(em => em.App_Religion)
                .Include(em => em.App_EmerRelationship)
                .ToListAsync();
        }

        //CREATE AND UPDATEEEE APPLICANT

        [HttpPost("CreateApplicant")]
        public async Task<ActionResult<List<ApplicantT>>> CreateApplicant(ApplicantT applicant)
        {
            _context.ApplicantT.Add(applicant);
            await _context.SaveChangesAsync();

            return Ok(await GetDBApplicant());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<ApplicantT>>> UpdateApplicant(ApplicantT applicant, int id)
        {
            var dbApplicant = await _context.ApplicantT
                .Include(em => em.App_Gender)
                .Include(em => em.App_CivilStatus)
                .Include(em => em.App_Religion)
                .Include(em => em.App_EmerRelationship)
                .FirstOrDefaultAsync(e => e.Id == applicant.Id);

            if (dbApplicant != null)
            {
                dbApplicant.App_FirstName = applicant.App_FirstName;
                dbApplicant.App_LastName = applicant.App_LastName;
                dbApplicant.App_MiddleName = applicant.App_MiddleName;
                dbApplicant.App_Suffix = applicant.App_Suffix;
                dbApplicant.App_ContactNo1 = applicant.App_ContactNo1;
                dbApplicant.App_ContactNo2 = applicant.App_ContactNo2;
                dbApplicant.App_Email = applicant.App_Email;
                dbApplicant.App_DOB = applicant.App_DOB;
                dbApplicant.App_Age = applicant.App_Age;
                dbApplicant.App_Height = applicant.App_Height;
                dbApplicant.App_Weight = applicant.App_Weight;
                dbApplicant.App_Citizenship = applicant.App_Citizenship;
                dbApplicant.App_TIN = applicant.App_TIN;
                dbApplicant.App_SSS = applicant.App_SSS;
                dbApplicant.App_PagIbig = applicant.App_PagIbig;
                dbApplicant.App_Philhealth = applicant.App_Philhealth;

                dbApplicant.App_EmerName = applicant.App_EmerName;
                dbApplicant.App_EmerRelationship = applicant.App_EmerRelationship;
                dbApplicant.App_EmerAddress = applicant.App_EmerAddress;
                dbApplicant.App_EmerMobNum = applicant.App_EmerMobNum;

                dbApplicant.App_GenderId = applicant.App_GenderId;
                dbApplicant.App_CivilStatusId = applicant.App_CivilStatusId;
                dbApplicant.App_ReligionId = applicant.App_ReligionId;

                dbApplicant.App_SpouseName = applicant.App_SpouseName;
                dbApplicant.App_SpouseOccupation = applicant.App_SpouseOccupation;
                dbApplicant.App_FatherName = applicant.App_FatherName;
                dbApplicant.App_FatherOccupation = applicant.App_FatherOccupation;
                dbApplicant.App_MotherName = applicant.App_MotherName;
                dbApplicant.App_MotherOccupation = applicant.App_MotherOccupation;

                await _context.SaveChangesAsync();
            }
            return Ok(await GetDBApplicant());
        }
    }
}
