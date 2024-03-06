namespace HrisApp.Server.Controllers.ImageC
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetImageController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _evs;
        private readonly ILogger<ImageController> _logger;

        public AssetImageController(DataContext context, IWebHostEnvironment evs, ILogger<ImageController> logger)
        {
            _context = context;
            _evs = evs;
            _logger = logger;
        }

        [HttpGet("Getattachmentview")]
        public async Task<ActionResult<byte[]>> Getattachmentview([FromQuery] string jmcode)
        {
            {
                var _masterlist = await _context.AssetImageT.ToListAsync();
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
        }

        [HttpGet("GetattachmentviewAll")]
        public async Task<ActionResult<byte[]>> GetattachmentviewAll([FromQuery] string assetcode)
        {
            {
                var _masterlist = await _context.AssetImageT.ToListAsync();
                var model = _masterlist.Where(a => a.Img_Filename == assetcode).FirstOrDefault();

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
        }

        //NEW DAGDAG 4.1.23
        [HttpPost("PostUploadImage")]
        public async Task<IActionResult> PostUploadImage([FromQuery] string assetcode, [FromQuery] int category, [FromQuery] int subcat, [FromQuery] string jmcode, [FromQuery] string Remarks)
        {
            try
            {
                var httpRequest = HttpContext.Request;
                if (httpRequest.Form.Files.Count > 0)
                {
                    foreach (var file in httpRequest.Form.Files)
                    {
                        var filePath = Path.Combine(_evs.ContentRootPath, "AssetImages", assetcode + "_" + jmcode);
                        if (!Directory.Exists(filePath))
                            Directory.CreateDirectory(filePath);

                        using (var memoryStream = new MemoryStream())
                        {
                            await file.CopyToAsync(memoryStream);
                            System.IO.File.WriteAllBytes(Path.Combine(filePath, file.FileName), memoryStream.ToArray());
                        }

                        //update
                        var db = await _context.AssetImageT.Where(a => a.AssetCode == assetcode && a.JM_Code == jmcode && a.SubCategoryId == subcat).FirstOrDefaultAsync();
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
                            AssetImageT _Model = new()
                            {
                                AssetCode = assetcode,
                                Img_Filename = file.Name,
                                Img_Contenttype = file.ContentType,
                                Img_URL = filePath,
                                Img_Data = null,
                                Img_Date = DateTime.Now,
                                CategoryId = category,
                                SubCategoryId = subcat,
                                JM_Code = jmcode,
                                Remarks = Remarks,
                            };
                            _context.AssetImageT.Add(_Model);
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
        public async Task<IActionResult> PostUploadImagePanel([FromQuery] string assetcode, [FromQuery] int category, [FromQuery] int subcat, [FromQuery] string jmcode, [FromQuery] string Remarks)
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

                        var filePath = Path.Combine(_evs.ContentRootPath, "AssetImages", assetcode + "_" + jmcode);
                        if (!Directory.Exists(filePath))
                            Directory.CreateDirectory(filePath);

                        using (var memoryStream = new MemoryStream())
                        {
                            await file.CopyToAsync(memoryStream);
                            System.IO.File.WriteAllBytes(Path.Combine(filePath, file.FileName), memoryStream.ToArray());
                        }

                        //update
                        AssetImageT _Model = new()
                        {
                            AssetCode = assetcode,
                            Img_Filename = file.Name,
                            Img_Contenttype = file.ContentType,
                            Img_URL = filePath,
                            Img_Data = null,
                            Img_Date = DateTime.Now,
                            CategoryId = category,
                            SubCategoryId = subcat,
                            JM_Code = jmcode,
                            Remarks = Remarks,
                        };
                        _context.AssetImageT.Add(_Model);
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
        public async Task<ActionResult<AssetImageT>> GetSingleImage(int id)
        {
            var user = await _context.AssetImageT
                .FirstOrDefaultAsync(h => h.Id == id);
            if (user == null)
            {
                return NotFound("sorry no users here");
            }
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDBImage(AssetImageT img, int id)
        {
            var dbimg = await _context.AssetImageT.FirstOrDefaultAsync(d => d.Id == img.Id);

            dbimg.AssetCode = img.AssetCode;
            dbimg.CategoryId = img.CategoryId;
            dbimg.SubCategoryId = img.SubCategoryId;

            await _context.SaveChangesAsync();

            return Ok(dbimg);
        }

        //GEEET
        [HttpGet]
        public async Task<ActionResult<List<AssetImageT>>> GetObjList()
        {
            var obj = await _context.AssetImageT.ToListAsync();
            return Ok(obj);
        }

        [HttpGet("GetFilteredImages")]
        public async Task<ActionResult<List<AssetImageT>>> GetFilteredImages([FromQuery] string jmcode)
        {
            var filteredDiv = await _context.AssetImageT.Where(x => x.JM_Code == jmcode).ToListAsync();
            return Ok(filteredDiv);
        }

        [HttpDelete("DeleteAssetImg")]
        public async Task<ActionResult<List<AssetImageT>>> DeleteAssetImg([FromQuery] string filename, [FromQuery] string assetcode)
        {
            var dbcol = await _context.AssetImageT
                .Where(h => h.Img_Filename.Equals(filename) && h.AssetCode.Equals(assetcode))
                .FirstOrDefaultAsync();

            if (dbcol == null)
                return NotFound("Sorry, but no senior");

            var filePath = Path.Combine(_evs.ContentRootPath, "AssetImages", assetcode + "_" + dbcol.JM_Code);
            var previousImagePath = Path.Combine(filePath, dbcol.Img_Filename);
            if (System.IO.File.Exists(previousImagePath))
            {
                System.IO.File.Delete(previousImagePath);
            }

            _context.AssetImageT.Remove(dbcol);

            await _context.SaveChangesAsync();

            return Ok(dbcol);
        }
    }
}