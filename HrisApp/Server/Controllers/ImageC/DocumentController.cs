using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.ImageC
{
#nullable disable
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _evs;
        private readonly ILogger<DocumentController> _logger;

        public DocumentController(DataContext context, IWebHostEnvironment evs, ILogger<DocumentController> logger)
        {
            _context = context;
            _evs = evs;
            _logger = logger;
        }

        //NEW DAGDAG 4.1.23
        [HttpPost("Postoutletfile")]
        public async Task<IActionResult> Postoutletfile([FromQuery] string EmployeeId, [FromQuery] int division, [FromQuery] int department, [FromQuery] string lastname, [FromQuery] string verify)
        {
            try
            {
                var httpRequest = HttpContext.Request;
                if (httpRequest.Form.Files.Count > 0)
                {
                    foreach (var file in httpRequest.Form.Files)
                    {
                        var divisionPDF = await _context.DivisionT.Where(d => d.Id == division).Select(d => d.Name).FirstOrDefaultAsync();
                        var departmentPDF = await _context.DepartmentT.Where(d => d.Id == department).Select(d => d.Name).FirstOrDefaultAsync();

                        //var filePath = Path.Combine(_evs.ContentRootPath, "EmployeeImages", divisionPDF, departmentPDF, lastname);
                        var filePath = Path.Combine(_evs.ContentRootPath, "EmployeeImages", verify + "_" + lastname);
                        if (!Directory.Exists(filePath))
                            Directory.CreateDirectory(filePath);

                        using (var memoryStream = new MemoryStream())
                        {
                            await file.CopyToAsync(memoryStream);
                            System.IO.File.WriteAllBytes(Path.Combine(filePath, file.FileName), memoryStream.ToArray());


                            DocumentT _Model = new DocumentT()
                            {
                                EmployeeNo = EmployeeId,
                                Img_Filename = file.FileName,
                                Img_Contenttype = file.ContentType,
                                Img_URL = filePath,
                                Img_Data = null,
                                Img_Date = DateTime.Now,
                                DivisionId = division,
                                DepartmentId = department,
                                LastName = lastname,
                                Verify_Id = verify,
                            };
                            _context.DocumentT.Add(_Model);
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

        // GET: attachment file download
        [HttpGet("Getdocumentfile")]
        public async Task<IActionResult> Getattachmentdownload([FromQuery] string employeeId, [FromQuery] string verifyCode)
        {
            var _model = await _context.DocumentT.FirstOrDefaultAsync(d => d.EmployeeNo.Equals(employeeId) && d.Verify_Id.Equals(verifyCode));
            var _path = Path.Combine(_evs.ContentRootPath, _model.Img_URL, _model.Img_Filename);

            var _memory = new MemoryStream();
            using (var _stream = new FileStream(_path, FileMode.Open))
            {
                await _stream.CopyToAsync(_memory);
            }
            _memory.Position = 0;
            return File(_memory, _model.Img_Contenttype, Path.GetFileName(_path));
        }

        [HttpGet("GetPDFview")]
        public async Task<ActionResult<List<byte[]>>> GetAttachmentView([FromQuery] string verifyCode)
        {
            var models = await _context.DocumentT.Where(a => a.Verify_Id == verifyCode).ToListAsync();

            if (models.Count == 0)
            {
                return NotFound("No PDFs available");
            }

            var pdfList = new List<byte[]>();

            foreach (var model in models)
            {
                var path = Path.Combine(_evs.ContentRootPath, model.Img_URL, model.Img_Filename);

                using (var stream = new FileStream(path, FileMode.Open))
                {
                    var memory = new MemoryStream();
                    await stream.CopyToAsync(memory);
                    pdfList.Add(memory.ToArray());
                }
            }

            return pdfList;
        }

        [HttpGet("GetDocuImagelist")]
        public async Task<ActionResult<List<Emp_PrimaryT>>> GetDocuImagelist([FromQuery] string verCode)
        {
            var doculist = await _context.DocumentT
                .Where(x => x.Verify_Id == verCode)
                .ToListAsync();

            if (doculist == null || doculist.Count == 0)
            {
                return NotFound("No work experiences found");
            }

            return Ok(doculist);
        }

        [HttpGet("GetFilteredPDF")]
        public async Task<ActionResult<List<DocumentT>>> GetFilteredPDF([FromQuery] string verifyId, [FromQuery] string employeId)
        {
            var filteredDiv = await _context.DocumentT.Where(x => x.Verify_Id == verifyId && x.EmployeeNo == employeId).ToListAsync();
            return Ok(filteredDiv);
        }

        [HttpGet("Getdocumentfileview")]
        public async Task<ActionResult<byte[]>> Getattachmentview([FromQuery] string employeeId, [FromQuery] string verifyCode, [FromQuery] string filename)
        {
            var _model = await _context.DocumentT.FirstOrDefaultAsync(d => d.EmployeeNo.Equals(employeeId) && d.Verify_Id.Equals(verifyCode) && d.Img_Filename == filename);
            if (_model == null)
            {
                return NotFound("No image available");
            }

            var _path = Path.Combine(_evs.ContentRootPath, _model.Img_URL, _model.Img_Filename);

            var _memory = new MemoryStream();
            using (var _stream = new FileStream(_path, FileMode.Open))
            {
                await _stream.CopyToAsync(_memory);
            }
            _memory.Position = 0;
            return _memory.ToArray();
        }
    }
}
