using HrisApp.Shared.Models.LiscenseAndTraining;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.LicenseTrainingC
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly DataContext _context;

        public TrainingController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetTraininglist")]
        public async Task<ActionResult<List<TrainingT>>> GetTraininglist([FromQuery] string verifyCode)
        {
            var training = await _context.TrainingT
                .Where(x => x.Verify_Id == verifyCode)
                .ToListAsync();
            return Ok(training);
        }

        // PUT: api/Trainings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateTrainings/{id}")]
        public async Task<IActionResult> PutTrainings(int id, TrainingT trainings)
        {
            if (id != trainings.Id)
            {
                return BadRequest();
            }

            _context.Entry(trainings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await GetDbTraining());
        }

        // POST: api/Trainings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrainingT>> CreateTraining([FromBody] TrainingT train)
        {
            if (train == null)
            {
                return BadRequest("Invalid data");
            }

            _context.TrainingT.Add(train);
            await _context.SaveChangesAsync();

            return Ok(train);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TrainingT>>> DeleteTraining(int id)
        {
            var dbtraining = await _context.TrainingT
                .FirstOrDefaultAsync(h => h.Id == id);
            if (dbtraining == null)
                return NotFound("Sorry, but no senior");

            _context.TrainingT.Remove(dbtraining);

            await _context.SaveChangesAsync();

            return Ok(dbtraining);
        }

        private bool TrainingsExists(int id)
        {
            return (_context.TrainingT?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private async Task<List<TrainingT>> GetDbTraining()
        {
            return await _context.TrainingT.ToListAsync();
        }

        [HttpGet("GetExistTrainings")]
        public async Task<ActionResult<IEnumerable<TrainingT>>> GetExistTrainings([FromQuery] string verifyId, [FromQuery] int id)
        {
            return await _context.TrainingT.Where(a => a.Verify_Id == verifyId && a.Id == id).ToListAsync();
        }
    }
}
