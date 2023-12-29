﻿using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.Attendance
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveHistoryController : ControllerBase
    {
        private readonly DataContext _context;

        public LeaveHistoryController(DataContext context)
        {
            _context = context;
        }

        //GEEET
        [HttpGet]
        public async Task<ActionResult<List<Emp_LeaveHistoryT>>> GetLeaveHistoryList()
        {
            var obj = await _context.Emp_LeaveHistoryT.ToListAsync();
            return Ok(obj);
        }

        [HttpGet("GetLeaveHistory")]
        public async Task<ActionResult<List<Emp_LeaveHistoryT>>> GetLeaveHistory()
        {
            var obj = await _context.Emp_LeaveHistoryT.ToListAsync();
            return Ok(obj);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Emp_LeaveHistoryT>> GetSingleLeaveHistory(int id)
        {
            var area = await _context.Emp_LeaveHistoryT.FirstOrDefaultAsync(h => h.Id == id);

            if (area == null)
            {
                return NotFound();
            }
            return Ok(area);
        }

        [HttpGet("GetSingleLeaveHistoryByVerId/{verid}")]
        public async Task<ActionResult<Emp_LeaveHistoryT>> GetSingleLeaveHistoryByVerId(string verid)
        {
            var area = await _context.Emp_LeaveHistoryT.FirstOrDefaultAsync(h => h.Verify_Id == verid);

            if (area == null)
            {
                return NotFound();
            }
            return Ok(area);
        }

        private async Task<List<Emp_LeaveHistoryT>> GetDBLeaveHistory()
        {
            return await _context.Emp_LeaveHistoryT.ToListAsync();
        }

        //CREATE AND UPDATEEE
        [HttpPost("CreateLeaveHistory")]
        public async Task<ActionResult<Emp_LeaveHistoryT>> CreateLeaveHistory(Emp_LeaveHistoryT obj)
        {
            _context.Emp_LeaveHistoryT.Add(obj);
            await _context.SaveChangesAsync();

            return Ok(await GetDBLeaveHistory());
        }

        [HttpPut("UpdateLeaveHistory")]
        public async Task<ActionResult> UpdateLeaveHistory(Emp_LeaveHistoryT obj)
        {
            var dbobj = await _context.Emp_LeaveHistoryT.FirstOrDefaultAsync(d => d.Id == obj.Id);

            dbobj.LeaveType = obj.LeaveType;
            dbobj.From = obj.From;
            dbobj.To = obj.To;
            dbobj.NoOfDays = obj.NoOfDays;
            dbobj.Purpose = obj.Purpose;
            await _context.SaveChangesAsync();

            return Ok(await GetDBLeaveHistory());
        }
    }
}