namespace HrisApp.Server.Controllers.ImageC
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainAssetImgLogController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _evs;
        private readonly ILogger<MainAssetImgLogController> _logger;

        public MainAssetImgLogController(DataContext context, IWebHostEnvironment evs, ILogger<MainAssetImgLogController> logger)
        {
            _context = context;
            _evs = evs;
            _logger = logger;
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
                        var filePath = Path.Combine(_evs.ContentRootPath, "AssetLogImages", jmcode);
                        if (!Directory.Exists(filePath))
                            Directory.CreateDirectory(filePath);

                        using (var memoryStream = new MemoryStream())
                        {
                            await file.CopyToAsync(memoryStream);
                            System.IO.File.WriteAllBytes(Path.Combine(filePath, file.FileName), memoryStream.ToArray());
                        }

                        var verifyCode = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                        //update
                        MainAssetImgLogT _Model = new()
                        {ImgVerifyId = verifyCode,
                            AssetCode = jmcode,
                            Img_Filename = file.Name,
                            Img_Contenttype = file.ContentType,
                            Img_URL = filePath,
                            Img_Data = null,
                            Img_Date = DateTime.Now,
                            CategoryId = category,
                            SubCategoryId = subcat,
                            JM_Code = jmcode,
                            FolderTitle = remarks,
                        };
                        _context.MainAssetImgLogT.Add(_Model);
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
                        var filePath = Path.Combine(_evs.ContentRootPath, "AssetLogImages", jmcode);
                        if (!Directory.Exists(filePath))
                            Directory.CreateDirectory(filePath);

                        using (var memoryStream = new MemoryStream())
                        {
                            await file.CopyToAsync(memoryStream);
                            System.IO.File.WriteAllBytes(Path.Combine(filePath, file.FileName), memoryStream.ToArray());
                        }

                        var verifyCode = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                        MainAssetImgLogT _Model = new()
                        {
                            ImgVerifyId = verifyCode,
                            AssetCode = jmcode,
                            Img_Filename = file.Name,
                            Img_Contenttype = file.ContentType,
                            Img_URL = filePath,
                            Img_Data = null,
                            Img_Date = DateTime.Now,
                            CategoryId = category,
                            SubCategoryId = subcat,
                            JM_Code = jmcode,
                            FolderTitle = remarks,
                        };
                        _context.MainAssetImgLogT.Add(_Model);
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

        [HttpGet("GetFilteredImages")]
        public async Task<ActionResult<List<MainAssetImgLogT>>> GetFilteredImages([FromQuery] string jmcode)
        {
            var filteredDiv = await _context.MainAssetImgLogT.Where(x => x.JM_Code == jmcode).OrderByDescending(e => e.Img_Date).ToListAsync();
            return Ok(filteredDiv);
        }
        [HttpGet("GetattachmentviewAll")]
        public async Task<ActionResult<byte[]>> GetattachmentviewAll([FromQuery] string filename)
        {
            try
            {
                var _masterlist = await _context.MainAssetImgLogT.ToListAsync();
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
        [HttpDelete("DeleteAssetImg")]
        public async Task<ActionResult<List<MainAssetImgLogT>>> DeleteAssetImg([FromQuery] string filename, [FromQuery] string jmcode)
        {
            var dbcol = await _context.MainAssetImgLogT
                .Where(h => h.Img_Filename.Equals(filename) && h.JM_Code.Equals(jmcode))
                .FirstOrDefaultAsync();

            if (dbcol == null)
                return NotFound("Sorry, but no senior");

            var filePath = Path.Combine(_evs.ContentRootPath, "AssetLogImages", jmcode);
            var previousImagePath = Path.Combine(filePath, dbcol.Img_Filename);
            if (System.IO.File.Exists(previousImagePath))
            {
                System.IO.File.Delete(previousImagePath);
            }

            _context.MainAssetImgLogT.Remove(dbcol);

            await _context.SaveChangesAsync();

            return Ok(dbcol);
        }
    }
}
