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
            dbpos.PosEducation = pos.PosEducation;
            dbpos.WorkExperience = pos.WorkExperience;
            dbpos.OtherCompetencies = pos.OtherCompetencies;
            dbpos.Restrictions = pos.Restrictions;
            dbpos.Plantilla = pos.Plantilla;

            await _context.SaveChangesAsync();

            return Ok(await GetDBPosition());
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



    }
}
