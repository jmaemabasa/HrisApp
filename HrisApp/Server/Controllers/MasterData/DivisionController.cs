﻿using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.MasterData
{
#nullable disable

    [Route("api/[controller]")]
    [ApiController]
    public class DivisionController : ControllerBase
    {
        private readonly DataContext _context;

        public DivisionController(DataContext context)
        {
            _context = context;
        }

        //GEEET
        [HttpGet]
        public async Task<ActionResult<List<DivisionT>>> GetDivisionList()
        {
            var division = await _context.DivisionT.ToListAsync();
            return Ok(division);
        }

        [HttpGet("GetDivision")]
        public async Task<ActionResult<List<DivisionT>>> GetDivision()
        {
            var division = await _context.DivisionT.ToListAsync();
            return Ok(division);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DivisionT>> GetSingleDivision(int id)
        {
            var division = await _context.DivisionT.FindAsync(id);

            if (division == null)
            {
                return NotFound();
            }

            return division;
        }

        private async Task<List<DivisionT>> GetDBDivision()
        {
            return await _context.DivisionT.ToListAsync();
        }

        //CREATE AND UPDATEEE
        [HttpPost("CreateDivision")]
        public async Task<ActionResult<DivisionT>> CreateDivision(DivisionT division)
        {
            _context.DivisionT.Add(division);
            await _context.SaveChangesAsync();

            return Ok(await GetDBDivision());
        }

        [HttpPut("UpdateDivision")]
        public async Task<ActionResult> UpdateDivision(DivisionT division)
        {
            var dbdiv = await _context.DivisionT.FirstOrDefaultAsync(d => d.Id == division.Id);

            dbdiv.Name = division.Name;
            await _context.SaveChangesAsync();

            return Ok(await GetDBDivision());
        }

        [HttpGet("DivisionCount")]
        public async Task<ActionResult<int>> GetDivisionCount()
        {
            var Masterlist = await _context.DivisionT
                .ToListAsync();

            var returnCount = Masterlist.Count();
            return Ok(returnCount);
        }

        [HttpGet("GetDivisionId/{name}")]
        public async Task<ActionResult<int>> GetDivisionId(string name)
        {
            var Masterlist = await _context.DivisionT
                .ToListAsync();

            var _returnId = Masterlist.Where(d => d.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            return Ok(_returnId.Id);
        }
    }
}
