using HrisApp.Shared.Models.Dashboard;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.MasterData
{
#nullable disable
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly DataContext _context;

        public PositionController(DataContext context)
        {
            _context = context;
        }

        //GEEEEEEETT
        //Get Position by Section
        [HttpGet("PosBySection/{sectionId}")]
        public async Task<ActionResult<List<PositionT>>> GetPosBySection(int sectionId)
        {
            var pos = await _context.PositionT
                .Where(sect => sect.SectionId == sectionId)
                .OrderBy(d => d.DepartmentId)
                .ToListAsync();
            return Ok(pos);
        }

        //Get Position by Division
        [HttpGet("PosByDivision/{divisionId}")]
        public async Task<ActionResult<List<PositionT>>> GetPosByDivision(int divisionId)
        {
            var pos = await _context.PositionT
                .Where(div => div.DivisionId == divisionId)
                .OrderBy(d => d.DepartmentId)
                .ToListAsync();
            return Ok(pos);
        }

        //Get Position by Department
        [HttpGet("PosByDepartment/{departmentId}")]
        public async Task<ActionResult<List<PositionT>>> GetPosByDepartment(int departmentId)
        {
            var pos = await _context.PositionT
                .Where(dep => dep.DepartmentId == departmentId)
                .OrderBy(d => d.DivisionId)
                .OrderBy(s => s.SectionId)
                .ToListAsync();
            return Ok(pos);
        }

        //Get ALL Position List without Filter
        [HttpGet]
        public async Task<ActionResult<List<PositionT>>> GetPositionList()
        {
            var pos = await _context.PositionT
                .ToListAsync();
            return Ok(pos);
        }

        //GET ALL POSITIONs MAIN
        [HttpGet("GetPosition")]
        public async Task<ActionResult<List<PositionT>>> GetPosition()
        {
            var pos = await _context.PositionT
                .ToListAsync();
            return Ok(pos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PositionT>> GetSinglePosition(int id)
        {
            var pos = await _context.PositionT.FindAsync(id);

            if (pos == null)
            {
                return NotFound();
            }

            return pos;
        }

        //Get all list
        private async Task<List<PositionT>> GetDBPosition()
        {
            return await _context.PositionT
                .ToListAsync();
        }

        //CREATE AND UPDATEEEE

        [HttpPost("CreatePosition")]
        public async Task<ActionResult<PositionT>> CreatePosition(PositionT pos)
        {
            _context.PositionT.Add(pos);
            await _context.SaveChangesAsync();

            return Ok(await GetDBPosition());
        }

        [HttpPut("UpdatePosition")]
        public async Task<ActionResult> UpdatePosition(PositionT pos)
        {
            var dbpos = await _context.PositionT.FirstOrDefaultAsync(d => d.Id == pos.Id);

            dbpos.Name = pos.Name;
            dbpos.JobSummary = pos.JobSummary;
            dbpos.OtherCompetencies = pos.OtherCompetencies;
            dbpos.Restrictions = pos.Restrictions;
            dbpos.Plantilla = pos.Plantilla;
            dbpos.PositionType = pos.PositionType;
            dbpos.TemporaryDuration = pos.TemporaryDuration;
            dbpos.PosMPExternalId = pos.PosMPExternalId;
            dbpos.Manpower = pos.Manpower;

            await _context.SaveChangesAsync();

            return Ok(await GetDBPosition());
        }

        //PLANTILLA
        [HttpGet("GetTotalPlantilla")]
        public async Task<ActionResult<int>> GetTotalPlantilla()
        {
            var totalPlantilla = await _context.PositionT.SumAsync(p => p.Plantilla);
            return Ok(totalPlantilla);
        }
        [HttpPost("CreateTotalPlantilla")]
        public async Task<ActionResult<DailyTotalPlantillaT>> CreateTotalPlantilla(DailyTotalPlantillaT obj)
        {
            DateTime today = DateTime.Today;

            // Check if a record already exists for today
            var existingRecord = await _context.DailyTotalPlantillaT
                .FirstOrDefaultAsync(d => d.Date == today);

            if (existingRecord != null)
            {
                //return Conflict("Total plantilla record for today already exists.");
                // Check if the new total plantilla is different from the existing one
                int newTotalPlantilla = await _context.PositionT.SumAsync(p => p.Plantilla);

                if (existingRecord.TotalPlantilla != newTotalPlantilla)
                {
                    // Update the existing record with the new total plantilla
                    existingRecord.TotalPlantilla = newTotalPlantilla;
                    await _context.SaveChangesAsync();
                    return Ok(existingRecord);
                }
                return NoContent();
            }

            // Create a new record for today
            DailyTotalPlantillaT newRecord = new DailyTotalPlantillaT
            {
                Date = today,
                TotalPlantilla = await _context.PositionT.SumAsync(p => p.Plantilla)
            };

            _context.DailyTotalPlantillaT.Add(newRecord);
            await _context.SaveChangesAsync();

            return Ok(newRecord);
        }
        [HttpGet("GetDbTotalPlantilla")]
        public async Task<ActionResult<List<DailyTotalPlantillaT>>> GetDbTotalPlantilla()
        {
            // Define the cutoff date (11 days ago from today)
            DateTime cutoffDate = DateTime.Today.AddDays(-11);

            // Get records from the database
            var pos = await _context.DailyTotalPlantillaT
                .Where(d => d.Date >= cutoffDate)
                .ToListAsync();

            // Delete records older than 11 days
            var recordsToDelete = await _context.DailyTotalPlantillaT
                .Where(d => d.Date < cutoffDate)
                .ToListAsync();

            foreach (var record in recordsToDelete)
            {
                _context.DailyTotalPlantillaT.Remove(record);
            }

            await _context.SaveChangesAsync();

            return Ok(pos);
        }

        //SKILLS
        [HttpGet("GetTechSkill")]
        public async Task<ActionResult<List<PositionTechSkillT>>> GetTechSkill([FromQuery] string posCode)
        {
            var list = await _context.PositionTechSkillT
                .Where(x => x.PosCode == posCode)
                .ToListAsync();

            return Ok(list);
        }
        private async Task<List<PositionTechSkillT>> GetDBTech()
        {
            return await _context.PositionTechSkillT
                .ToListAsync();
        }
        [HttpGet("GetExistingTechSkill")]
        public async Task<ActionResult<int>> GetExistingTechSkill([FromQuery] string verifyCode)
        {
            var allimage = await _context.PositionTechSkillT.ToListAsync();
            var image = allimage.Where(h => h.VerifyId == verifyCode).Count();
            return image;
        }
        [HttpPost("CreateTechSkill")]
        public async Task<ActionResult<PositionTechSkillT>> CreateTechSkill([FromBody] PositionTechSkillT obj)
        {
            if (obj == null)
            {
                return BadRequest("Invalid data");
            }
            _context.PositionTechSkillT.Add(obj);
            await _context.SaveChangesAsync();

            return Ok(obj);
        }
        [HttpPut("UpdateTechSkill/{VerifyId}")]
        public async Task<ActionResult<List<PositionComAppT>>> UpdateTechSkill(PositionTechSkillT emphistory, string VerifyId)
        {
            var dbEmployeeHis = await _context.PositionTechSkillT.FirstOrDefaultAsync(e => e.VerifyId == VerifyId);

            if (dbEmployeeHis != null)
            {
                dbEmployeeHis.SkillName = emphistory.SkillName;

                await _context.SaveChangesAsync();
            }
            return Ok(await GetDBTech());
        }

        [HttpDelete("DeleteAllTechSkills/{verId}")]
        public async Task<ActionResult<List<PositionTechSkillT>>> DeleteAllTechSkills(string verId)
        {
            var dbcol = await _context.PositionTechSkillT.FirstOrDefaultAsync(h => h.VerifyId == verId);
            if (dbcol == null)
                return NotFound("Sorry, but no senior");

            _context.PositionTechSkillT.Remove(dbcol);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //COM APP
        [HttpGet("GetComApp")]
        public async Task<ActionResult<List<PositionComAppT>>> GetComApp([FromQuery] string posCode)
        {
            var list = await _context.PositionComAppT
                .Where(x => x.PosCode == posCode)
                .ToListAsync();

            return Ok(list);
        }
        private async Task<List<PositionComAppT>> GetDBComApp()
        {
            return await _context.PositionComAppT
                .ToListAsync();
        }
        [HttpGet("GetExistingComApp")]
        public async Task<ActionResult<int>> GetExistingComApp([FromQuery] string verifyCode)
        {
            var allimage = await _context.PositionComAppT.ToListAsync();
            var image = allimage.Where(h => h.VerifyId == verifyCode).Count();
            return image;
        }
        [HttpPost("CreateComApp")]
        public async Task<ActionResult<PositionComAppT>> CreateComApp([FromBody] PositionComAppT obj)
        {
            if (obj == null)
            {
                return BadRequest("Invalid data");
            }
            _context.PositionComAppT.Add(obj);
            await _context.SaveChangesAsync();

            return Ok(obj);
        }
        [HttpPut("UpdateComApp/{VerifyId}")]
        public async Task<ActionResult<List<PositionComAppT>>> UpdateComApp(PositionComAppT emphistory, string VerifyId)
        {
            var dbEmployeeHis = await _context.PositionComAppT.FirstOrDefaultAsync(e => e.VerifyId == VerifyId);

            if (dbEmployeeHis != null)
            {
                dbEmployeeHis.ComName = emphistory.ComName;

                await _context.SaveChangesAsync();
            }
            return Ok(await GetDBComApp());
        }

        [HttpDelete("DeleteAllComApp/{verId}")]
        public async Task<ActionResult<List<PositionComAppT>>> DeleteAllComApp(string verId)
        {
            var dbcol = await _context.PositionComAppT.FirstOrDefaultAsync(h => h.VerifyId == verId);
            if (dbcol == null)
                return NotFound("Sorry, but no senior");

            _context.PositionComAppT.Remove(dbcol);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //Knowledge
        [HttpGet("GetKnowledge")]
        public async Task<ActionResult<List<PositionKnowledgeT>>> GetKnowledge([FromQuery] string posCode)
        {
            var list = await _context.PositionKnowledgeT
                .Where(x => x.PosCode == posCode)
                .ToListAsync();

            return Ok(list);
        }
        private async Task<List<PositionKnowledgeT>> GetDBKnow()
        {
            return await _context.PositionKnowledgeT
                .ToListAsync();
        }
        [HttpGet("GetExistingKnowledge")]
        public async Task<ActionResult<int>> GetExistingKnowledge([FromQuery] string verifyCode)
        {
            var allimage = await _context.PositionKnowledgeT.ToListAsync();
            var image = allimage.Where(h => h.VerifyId == verifyCode).Count();
            return image;
        }
        [HttpPost("CreateKnowledge")]
        public async Task<ActionResult<PositionKnowledgeT>> CreateKnowledge([FromBody] PositionKnowledgeT obj)
        {
            if (obj == null)
            {
                return BadRequest("Invalid data");
            }
            _context.PositionKnowledgeT.Add(obj);
            await _context.SaveChangesAsync();

            return Ok(obj);
        }
        [HttpPut("UpdateKnowledge/{VerifyId}")]
        public async Task<ActionResult<List<PositionComAppT>>> UpdateKnowledge(PositionKnowledgeT emphistory, string VerifyId)
        {
            var dbEmployeeHis = await _context.PositionKnowledgeT.FirstOrDefaultAsync(e => e.VerifyId == VerifyId);

            if (dbEmployeeHis != null)
            {
                dbEmployeeHis.KnowName = emphistory.KnowName;

                await _context.SaveChangesAsync();
            }
            return Ok(await GetDBKnow());
        }

        [HttpDelete("DeleteAllKnowledge/{verId}")]
        public async Task<ActionResult<List<PositionKnowledgeT>>> DeleteAllKnowledge(string verId)
        {
            var dbcol = await _context.PositionKnowledgeT.FirstOrDefaultAsync(h => h.VerifyId == verId);
            if (dbcol == null)
                return NotFound("Sorry, but no senior");

            _context.PositionKnowledgeT.Remove(dbcol);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //Education
        [HttpGet("GetWorkExp")]
        public async Task<ActionResult<List<PositionWorkExpT>>> GetWorkExp([FromQuery] string posCode)
        {
            var list = await _context.PositionWorkExpT
                .Where(x => x.PosCode == posCode)
                .ToListAsync();

            return Ok(list);
        }
        private async Task<List<PositionWorkExpT>> GetDBWorkExp()
        {
            return await _context.PositionWorkExpT
                .ToListAsync();
        }
        [HttpGet("GetExistingWorkExp")]
        public async Task<ActionResult<int>> GetExistingWorkExp([FromQuery] string verifyCode)
        {
            var allimage = await _context.PositionWorkExpT.ToListAsync();
            var image = allimage.Where(h => h.VerifyId == verifyCode).Count();
            return image;
        }
        [HttpPost("CreateWorkExp")]
        public async Task<ActionResult<PositionWorkExpT>> CreateWorkExp([FromBody] PositionWorkExpT obj)
        {
            if (obj == null)
            {
                return BadRequest("Invalid data");
            }
            _context.PositionWorkExpT.Add(obj);
            await _context.SaveChangesAsync();

            return Ok(obj);
        }
        [HttpPut("UpdateWorkExp/{VerifyId}")]
        public async Task<ActionResult<List<PositionWorkExpT>>> UpdateWorkExp(PositionWorkExpT emphistory, string VerifyId)
        {
            var dbEmployeeHis = await _context.PositionWorkExpT.FirstOrDefaultAsync(e => e.VerifyId == VerifyId);

            if (dbEmployeeHis != null)
            {
                dbEmployeeHis.ExpName = emphistory.ExpName;

                await _context.SaveChangesAsync();
            }
            return Ok(await GetDBWorkExp());
        }

        [HttpDelete("DeleteAllWorkExp/{verId}")]
        public async Task<ActionResult<List<PositionWorkExpT>>> DeleteAllWorkExp(string verId)
        {
            var dbcol = await _context.PositionWorkExpT.FirstOrDefaultAsync(h => h.VerifyId == verId);
            if (dbcol == null)
                return NotFound("Sorry, but no senior");

            _context.PositionWorkExpT.Remove(dbcol);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //Educ
        [HttpGet("GetEduc")]
        public async Task<ActionResult<List<PositionEducT>>> GetEduc([FromQuery] string posCode)
        {
            var list = await _context.PositionEducT
                .Where(x => x.PosCode == posCode)
                .ToListAsync();

            return Ok(list);
        }
        private async Task<List<PositionEducT>> GetDBEduc()
        {
            return await _context.PositionEducT
                .ToListAsync();
        }
        [HttpGet("GetExistingEduc")]
        public async Task<ActionResult<int>> GetExistingEduc([FromQuery] string verifyCode)
        {
            var allimage = await _context.PositionEducT.ToListAsync();
            var image = allimage.Where(h => h.VerifyId == verifyCode).Count();
            return image;
        }
        [HttpPost("CreateEduc")]
        public async Task<ActionResult<PositionEducT>> CreateEduc([FromBody] PositionEducT obj)
        {
            if (obj == null)
            {
                return BadRequest("Invalid data");
            }
            _context.PositionEducT.Add(obj);
            await _context.SaveChangesAsync();

            return Ok(obj);
        }
        [HttpPut("UpdateEduc/{VerifyId}")]
        public async Task<ActionResult<List<PositionEducT>>> UpdateEduc(PositionEducT emphistory, string VerifyId)
        {
            var dbEmployeeHis = await _context.PositionEducT.FirstOrDefaultAsync(e => e.VerifyId == VerifyId);

            if (dbEmployeeHis != null)
            {
                dbEmployeeHis.EducName = emphistory.EducName;

                await _context.SaveChangesAsync();
            }
            return Ok(await GetDBEduc());
        }

        [HttpDelete("DeleteAllEduc/{verId}")]
        public async Task<ActionResult<List<PositionEducT>>> DeleteAllEduc(string verId)
        {
            var dbcol = await _context.PositionEducT.FirstOrDefaultAsync(h => h.VerifyId == verId);
            if (dbcol == null)
                return NotFound("Sorry, but no senior");

            _context.PositionEducT.Remove(dbcol);
            await _context.SaveChangesAsync();
            return Ok();
        }


    }
}
