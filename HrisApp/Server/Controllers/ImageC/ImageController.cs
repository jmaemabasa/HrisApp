using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.ImageC
{
#nullable disable
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _evs;
        private readonly ILogger<ImageController> _logger;

        public ImageController(DataContext context, IWebHostEnvironment evs, ILogger<ImageController> logger)
        {
            _context = context;
            _evs = evs;
            _logger = logger;
        }

        [HttpGet("Getattachmentview")]
        public async Task<ActionResult<byte[]>> Getattachmentview([FromQuery] string verifyCode)
        {
            {


                var _masterlist = await _context.EmpPictureT.ToListAsync();
                var model = _masterlist.Where(a => a.Verify_Id == verifyCode).FirstOrDefault();

                if (model == null)
                {
                    return NotFound("No image available");
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
        public async Task<IActionResult> PostUploadImage([FromQuery] string EmployeeId, [FromQuery] int division, [FromQuery] int department, [FromQuery] string lastname, [FromQuery] string verify)
        {
            try
            {
                var httpRequest = HttpContext.Request;
                if (httpRequest.Form.Files.Count > 0)
                {
                    foreach (var file in httpRequest.Form.Files)
                    {
                        var divisionName = await _context.DivisionT.Where(d => d.Id == division).Select(d => d.Name).FirstOrDefaultAsync();
                        var departmentName = await _context.DepartmentT.Where(d => d.Id == department).Select(d => d.Name).FirstOrDefaultAsync();

                        //var filePath = Path.Combine(_evs.ContentRootPath, "EmployeeImages", divisionName, departmentName, lastname);
                        var filePath = Path.Combine(_evs.ContentRootPath, "EmployeeImages", EmployeeId + "_" + lastname);
                        if (!Directory.Exists(filePath))
                            Directory.CreateDirectory(filePath);

                        using (var memoryStream = new MemoryStream())
                        {
                            await file.CopyToAsync(memoryStream);
                            System.IO.File.WriteAllBytes(Path.Combine(filePath, file.FileName), memoryStream.ToArray());


                            EmpPictureT _Model = new EmpPictureT()
                            {
                                EmployeeNo = EmployeeId,
                                Img_Filename = file.Name,
                                Img_Contenttype = file.ContentType,
                                Img_URL = filePath,
                                Img_Data = null,
                                Img_Date = DateTime.Now,
                                DivisionId = division,
                                DepartmentId = department,
                                LastName = lastname,
                                Verify_Id = verify,
                            };
                            _context.EmpPictureT.Add(_Model);
                        }
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
    }
}
