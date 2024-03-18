﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.AssetC
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetVehicleController : ControllerBase
    {
        private readonly DataContext _context;

        public AssetVehicleController(DataContext context)
        {
            _context = context;
        }

        //GEEET
        [HttpGet]
        public async Task<ActionResult<List<AssetVehiclesT>>> GetObjList()
        {
            var obj = await _context.AssetVehiclesT
                .Include(e => e.AssetStatus)
                .Include(e => e.Category)
                .Include(e => e.SubCategory)
                .Include(e => e.Type)
                .Include(e => e.Employee)
                .Include(e => e.Employee!.Division)
                .Include(e => e.Employee!.Department)
                .Include(e => e.Area)
                .ToListAsync();
            return Ok(obj);
        }

        [HttpGet("GetObj")]
        public async Task<ActionResult<List<AssetVehiclesT>>> GetObj()
        {
            var obj = await _context.AssetVehiclesT
                .Include(e => e.AssetStatus)
                .Include(e => e.Category)
                .Include(e => e.SubCategory)
                .Include(e => e.Type)
                .Include(e => e.Employee)
                .Include(e => e.Employee!.Division)
                .Include(e => e.Employee!.Department)
                .Include(e => e.Area)
                .ToListAsync();
            return Ok(obj);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AssetVehiclesT>> GetSingleObj(int id)
        {
            var obj = await _context.AssetVehiclesT
                 .Include(e => e.AssetStatus)
                .Include(e => e.Category)
                .Include(e => e.SubCategory)
                .Include(e => e.Type)
                .Include(e => e.Employee)
                .Include(e => e.Area)
                .Include(e => e.Employee!.Division)
                .Include(e => e.Employee!.Department)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        private async Task<List<AssetVehiclesT>> GetDBObj()
        {
            return await _context.AssetVehiclesT
                .Include(e => e.AssetStatus)
                .Include(e => e.Category)
                .Include(e => e.SubCategory)
                .Include(e => e.Type)
                .Include(e => e.Employee)
                .Include(e => e.Employee!.Division)
                .Include(e => e.Employee!.Department)
                .Include(e => e.Area)
                .ToListAsync();
        }

        //CREATE AND UPDATEEE
        [HttpPost("CreateObj")]
        public async Task<ActionResult<AssetVehiclesT>> CreateArea(AssetVehiclesT model)
        {
            _context.AssetVehiclesT.Add(model);
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }

        [HttpPut("UpdateObj")]
        public async Task<ActionResult> UpdateArea(AssetVehiclesT model)
        {
            var dbarea = await _context.AssetVehiclesT.FirstOrDefaultAsync(d => d.Id == model.Id);

            dbarea.WorksationName = model.WorksationName;
            dbarea.Brand = model.Brand;
            dbarea.Model = model.Model;
            dbarea.Serial = model.Serial;
            dbarea.DeviceID = model.DeviceID;
            dbarea.ProductID = model.ProductID;
            dbarea.ProductID = model.ProductID;
            dbarea.Processor = model.Processor;
            dbarea.RAM = model.RAM;
            dbarea.Quantity = model.Quantity;
            dbarea.Barcode = model.Barcode;
            dbarea.StorageType = model.StorageType;
            dbarea.Storage = model.Storage;
            dbarea.MacAddress = model.MacAddress;
            dbarea.ClientIP = model.ClientIP;
            dbarea.CategoryId = model.CategoryId;
            dbarea.SubCategoryId = model.SubCategoryId;
            dbarea.TypeId = model.TypeId;
            dbarea.AreaId = model.AreaId;
            dbarea.PurchaseDate = model.PurchaseDate;
            dbarea.PurchaseAmount = model.PurchaseAmount;
            dbarea.EUF = model.EUF;
            dbarea.AssetStatusId = model.AssetStatusId;
            dbarea.UsernameAdmin = model.UsernameAdmin;
            dbarea.PasswordAdmin = model.PasswordAdmin;
            dbarea.Asset = model.Asset;
            dbarea.Remarks = model.Remarks;
            dbarea.InUseStatusDate = model.InUseStatusDate;
            dbarea.ChassisNumber = model.ChassisNumber;
            dbarea.PlateNumber = model.PlateNumber;

            dbarea.StatusDate = model.StatusDate;

            dbarea.EmployeeId = model.EmployeeId;
            dbarea.AssignedDate = model.AssignedDate;
            dbarea.AssignedDateReleased = model.AssignedDateReleased;
            dbarea.AssignedDateToReturn = model.AssignedDateToReturn;
            dbarea.LastCheckDate = model.LastCheckDate;
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }

        [HttpGet("GetObjId/{name}")]
        public async Task<ActionResult<int>> GetAreaId(string code)
        {
            var Masterlist = await _context.AssetVehiclesT
                .ToListAsync();

            var _returnId = Masterlist.Where(d => d.JMCode.Contains(code, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            return Ok(_returnId.Id);
        }

        [HttpGet("GetLastCode")]
        public async Task<ActionResult<int>> GetLastCode([FromQuery] int type, [FromQuery] int cat, [FromQuery] int subcat)
        {
            var fromquery = $"{cat}-{subcat}";
            var filtered = await _context.AssetVehiclesT.Where(e => e.TypeId == type && e.CategoryId == cat && e.SubCategoryId == subcat).ToListAsync();
            var lastItem = filtered.OrderByDescending(e => e.Id).FirstOrDefault();

            if (lastItem != null)
            {
                string code = lastItem.JMCode;

                string splitcode = code.Split("-")[3];
                return Ok(Convert.ToInt32(splitcode));
            }

            return Ok(0);
        }
    }
}