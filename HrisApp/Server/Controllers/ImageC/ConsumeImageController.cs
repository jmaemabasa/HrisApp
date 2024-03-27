using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.ImageC
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumeImageController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _evs;
        private readonly ILogger<ImageController> _logger;

        public ConsumeImageController(DataContext context, IWebHostEnvironment evs, ILogger<ImageController> logger)
        {
            _context = context;
            _evs = evs;
            _logger = logger;
        }

        [HttpGet("Getattachmentview")]
        public async Task<ActionResult<byte[]>> Getattachmentview([FromQuery] string jmcode)
        {
            try
            {
                var _masterlist = await _context.ConsumableImageT.ToListAsync();
                var model = _masterlist.Where(a => a.JM_Code == jmcode).FirstOrDefault();

                if (model == null)
                {
                    //not found dapat ni
                    return NoContent();
                }

                var _path = Path.Combine(_evs.ContentRootPath, model.Img_URL, model.Img_Filename);

                var _memory = new MemoryStream();
                using (var _stream = new FileStream(_path, FileMode.Open))
                {
                    await _stream.CopyToAsync(_memory);
                }
                _memory.Position = 0;
                return _memory.ToArray();
            }
            catch (Exception)
            {
                return NoContent();
            }
        }

        [HttpGet("GetattachmentviewAll")]
        public async Task<ActionResult<byte[]>> GetattachmentviewAll([FromQuery] string filename)
        {
            try
            {
                var _masterlist = await _context.ConsumableImageT.ToListAsync();
                var model = _masterlist.Where(a => a.Img_Filename == filename).FirstOrDefault();

                if (model == null)
                {
                    //not found dapat ni
                    return NoContent();
                }

                var _path = Path.Combine(_evs.ContentRootPath, model.Img_URL, model.Img_Filename);

                var _memory = new MemoryStream();
                using (var _stream = new FileStream(_path, FileMode.Open))
                {
                    await _stream.CopyToAsync(_memory);
                }
                _memory.Position = 0;
                return _memory.ToArray();
            }
            catch (Exception)
            {
                return NoContent();
            }
        }

        //NEW DAGDAG 4.1.23
        [HttpPost("PostUploadImage")]
        public async Task<IActionResult> PostUploadImage([FromQuery] int category, [FromQuery] int subcat, [FromQuery] string jmcode, [FromQuery] string remarks)
        {
            try
            {
                var httpRequest = HttpContext.Request;
                if (httpRequest.Form.Files.Count > 0)
                {
                    foreach (var file in httpRequest.Form.Files)
                    {
                        var filePath = Path.Combine(_evs.ContentRootPath, "ConsumabImages", jmcode);
                        if (!Directory.Exists(filePath))
                            Directory.CreateDirectory(filePath);

                        using (var memoryStream = new MemoryStream())
                        {
                            await file.CopyToAsync(memoryStream);
                            System.IO.File.WriteAllBytes(Path.Combine(filePath, file.FileName), memoryStream.ToArray());
                        }

                        //update
                        var db = await _context.ConsumableImageT.Where(a => a.JM_Code == jmcode && a.SubCategoryId == subcat).FirstOrDefaultAsync();
                        if (db != null)
                        {
                            //delete previous image
                            var previousImagePath = Path.Combine(filePath, db.Img_Filename);
                            if (System.IO.File.Exists(previousImagePath))
                            {
                                System.IO.File.Delete(previousImagePath);
                            }

                            db.Img_Filename = file.FileName;

                            await _context.SaveChangesAsync();
                            return Ok();
                        }
                        else
                        {
                            ConsumableImageT _Model = new()
                            {
                                AssetCode = jmcode,
                                Img_Filename = file.Name,
                                Img_Contenttype = file.ContentType,
                                Img_URL = filePath,
                                Img_Data = null,
                                Img_Date = DateTime.Now,
                                CategoryId = category,
                                SubCategoryId = subcat,
                                JM_Code = jmcode,
                                Remarks = remarks,
                            };
                            _context.ConsumableImageT.Add(_Model);
                            await _context.SaveChangesAsync();
                            return Ok();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                return new StatusCodeResult(500);
            }

            return BadRequest("Invalid saving Data");
        }

        [HttpPost("PostUploadImagePanel")]
        public async Task<IActionResult> PostUploadImagePanel([FromQuery] int category, [FromQuery] int subcat, [FromQuery] string jmcode, [FromQuery] string remarks)
        {
            try
            {
                var httpRequest = HttpContext.Request;
                if (httpRequest.Form.Files.Count > 0)
                {
                    foreach (var file in httpRequest.Form.Files)
                    {
                        var divisionName = await _context.DivisionT.Where(d => d.Id == category).Select(d => d.Name).FirstOrDefaultAsync();
                        var departmentName = await _context.DepartmentT.Where(d => d.Id == subcat).Select(d => d.Name).FirstOrDefaultAsync();

                        var filePath = Path.Combine(_evs.ContentRootPath, "ConsumableImages", jmcode);
                        if (!Directory.Exists(filePath))
                            Directory.CreateDirectory(filePath);

                        using (var memoryStream = new MemoryStream())
                        {
                            await file.CopyToAsync(memoryStream);
                            System.IO.File.WriteAllBytes(Path.Combine(filePath, file.FileName), memoryStream.ToArray());
                        }

                        //update
                        ConsumableImageT _Model = new()
                        {
                            AssetCode = jmcode,
                            Img_Filename = file.Name,
                            Img_Contenttype = file.ContentType,
                            Img_URL = filePath,
                            Img_Data = null,
                            Img_Date = DateTime.Now,
                            CategoryId = category,
                            SubCategoryId = subcat,
                            JM_Code = jmcode,
                            Remarks = remarks,
                        };
                        _context.ConsumableImageT.Add(_Model);
                        await _context.SaveChangesAsync();
                        return Ok();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                return new StatusCodeResult(500);
            }

            return BadRequest("Invalid saving Data");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ConsumableImageT>> GetSingleImage(int id)
        {
            var user = await _context.ConsumableImageT
                .FirstOrDefaultAsync(h => h.Id == id);
            if (user == null)
            {
                return NotFound("sorry no users here");
            }
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDBImage(ConsumableImageT img, int id)
        {
            var dbimg = await _context.ConsumableImageT.FirstOrDefaultAsync(d => d.Id == img.Id);

            dbimg.AssetCode = img.AssetCode;
            dbimg.CategoryId = img.CategoryId;
            dbimg.SubCategoryId = img.SubCategoryId;

            await _context.SaveChangesAsync();

            return Ok(dbimg);
        }

        //GEEET
        [HttpGet]
        public async Task<ActionResult<List<ConsumableImageT>>> GetObjList()
        {
            var obj = await _context.ConsumableImageT.ToListAsync();
            return Ok(obj);
        }

        [HttpGet("GetFilteredImages")]
        public async Task<ActionResult<List<ConsumableImageT>>> GetFilteredImages([FromQuery] string jmcode)
        {
            var filteredDiv = await _context.ConsumableImageT.Where(x => x.JM_Code == jmcode).OrderByDescending(e => e.Img_Date).ToListAsync();
            return Ok(filteredDiv);
        }

        [HttpDelete("DeleteAssetImg")]
        public async Task<ActionResult<List<ConsumableImageT>>> DeleteAssetImg([FromQuery] string filename, [FromQuery] string jmcode)
        {
            var dbcol = await _context.ConsumableImageT
                .Where(h => h.Img_Filename.Equals(filename) && h.JM_Code.Equals(jmcode))
                .FirstOrDefaultAsync();

            if (dbcol == null)
                return NotFound("Sorry, but no senior");

            var filePath = Path.Combine(_evs.ContentRootPath, "ConsumableImages", jmcode);
            var previousImagePath = Path.Combine(filePath, dbcol.Img_Filename);
            if (System.IO.File.Exists(previousImagePath))
            {
                System.IO.File.Delete(previousImagePath);
            }

            _context.ConsumableImageT.Remove(dbcol);

            await _context.SaveChangesAsync();

            return Ok(dbcol);
        }
    }
}
