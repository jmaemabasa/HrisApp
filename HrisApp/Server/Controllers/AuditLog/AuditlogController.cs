using HrisApp.Server.Controllers.ImageC;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.Text;

namespace HrisApp.Server.Controllers.AuditLog
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditlogController : ControllerBase
    {
        private readonly IWebHostEnvironment _evs;
        private readonly ILogger<AuditlogController> _logger;

        public AuditlogController(IWebHostEnvironment evs, ILogger<AuditlogController> logger)
        {
            _evs = evs;
            _logger = logger;
        }

        //[HttpPost("createexcelfile")]
        //public IActionResult CreateExcelFile([FromQuery] int userId, [FromQuery] string action, [FromQuery] string tableName, [FromQuery] string addInfo, [FromQuery] string beforeUpdate, DateTime date)
        //{
        //    try
        //    {
        //        // Your logic to generate content for the Excel file
        //        var filePath = Path.Combine(_evs.ContentRootPath, "AuditLogs", "auditlog.xlsx");

        //        FileInfo fileInfo;

        //        // Check if the file already exists
        //        if (System.IO.File.Exists(filePath))
        //        {
        //            fileInfo = new FileInfo(filePath);

        //            using (var package = new ExcelPackage(fileInfo))
        //            {
        //                var worksheet = package.Workbook.Worksheets.FirstOrDefault(ws => ws.Name == "AuditLog");

        //                // If the worksheet exists, find the next available row
        //                int row = worksheet.Dimension?.Rows ?? 1;

        //                // Add data to the next available row
        //                worksheet.Cells[$"A{row + 1}"].Value = userId;
        //                worksheet.Cells[$"B{row + 1}"].Value = action;
        //                worksheet.Cells[$"C{row + 1}"].Value = tableName;
        //                worksheet.Cells[$"D{row + 1}"].Value = addInfo;
        //                worksheet.Cells[$"E{row + 1}"].Value = beforeUpdate;
        //                worksheet.Cells[$"F{row + 1}"].Value = date;

        //                // Save the Excel package
        //                package.SaveAs(fileInfo);  // Use SaveAs with FileInfo
        //            }
        //        }
        //        else
        //        {
        //            // File does not exist, create a new one
        //            using (var package = new ExcelPackage())
        //            {
        //                var worksheet = package.Workbook.Worksheets.Add("AuditLog");

        //                // Add headers
        //                worksheet.Cells["A1"].Value = "UserId";
        //                worksheet.Cells["B1"].Value = "Action";
        //                worksheet.Cells["C1"].Value = "TableName";
        //                worksheet.Cells["D1"].Value = "AddInfo";
        //                worksheet.Cells["E1"].Value = "BeforeUpdate";
        //                worksheet.Cells["F1"].Value = "Date";

        //                // Add data
        //                worksheet.Cells["A2"].Value = userId;
        //                worksheet.Cells["B2"].Value = action;
        //                worksheet.Cells["C2"].Value = tableName;
        //                worksheet.Cells["D2"].Value = addInfo;
        //                worksheet.Cells["E2"].Value = beforeUpdate;
        //                worksheet.Cells["F2"].Value = date;

        //                // Save the Excel package
        //                package.SaveAs(filePath);  // Use SaveAs with FileInfo
        //            }
        //        }

        //        _logger.LogInformation($"Excel file created at: {filePath}");

        //        return Ok("Excel file created successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log any exceptions
        //        _logger.LogError($"Error creating Excel file: {ex.Message}");
        //        return StatusCode(500, "Internal Server Error");
        //    }
        //}

        [HttpPost("createexcelfile")]
        public IActionResult CreateExcelFile(AuditLogData auditLogData)
        {
            try
            {
                // Your logic to generate content for the Excel file
                var filePath = Path.Combine(_evs.ContentRootPath, "AuditLogs", "auditlog.xlsx");

                FileInfo fileInfo;

                // Check if the file already exists
                if (System.IO.File.Exists(filePath))
                {
                    fileInfo = new FileInfo(filePath);

                    using (var package = new ExcelPackage(fileInfo))
                    {
                        var worksheet = package.Workbook.Worksheets.FirstOrDefault(ws => ws.Name == "AuditLog");

                        // If the worksheet exists, find the next available row
                        int row = worksheet.Dimension?.Rows ?? 1;

                        // Add data to the next available row
                        worksheet.Cells[$"A{row + 1}"].Value = auditLogData.UserId;
                        worksheet.Cells[$"B{row + 1}"].Value = auditLogData.Action;
                        worksheet.Cells[$"C{row + 1}"].Value = auditLogData.TableName;
                        worksheet.Cells[$"D{row + 1}"].Value = auditLogData.AddInfo;
                        worksheet.Cells[$"E{row + 1}"].Value = auditLogData.BeforeUpdate;
                        worksheet.Cells[$"F{row + 1}"].Value = auditLogData.Date;

                        // Save the Excel package
                        package.SaveAs(fileInfo);  // Use SaveAs with FileInfo
                    }
                }
                else
                {
                    // File does not exist, create a new one
                    using (var package = new ExcelPackage())
                    {
                        var worksheet = package.Workbook.Worksheets.Add("AuditLog");

                        // Add headers
                        worksheet.Cells["A1"].Value = "UserId";
                        worksheet.Cells["B1"].Value = "Action";
                        worksheet.Cells["C1"].Value = "TableName";
                        worksheet.Cells["D1"].Value = "AddInfo";
                        worksheet.Cells["E1"].Value = "BeforeUpdate";
                        worksheet.Cells["F1"].Value = "Date";

                        // Add data
                        worksheet.Cells["A2"].Value = auditLogData.UserId;
                        worksheet.Cells["B2"].Value = auditLogData.Action;
                        worksheet.Cells["C2"].Value = auditLogData.TableName;
                        worksheet.Cells["D2"].Value = auditLogData.AddInfo;
                        worksheet.Cells["E2"].Value = auditLogData.BeforeUpdate;
                        worksheet.Cells["F2"].Value = auditLogData.Date;

                        // Save the Excel package
                        package.SaveAs(filePath);  // Use SaveAs with FileInfo
                    }
                }

                _logger.LogInformation($"Excel file created at: {filePath}");

                return Ok("Excel file created successfully.");
            }
            catch (Exception ex)
            {
                // Log any exceptions
                _logger.LogError($"Error creating Excel file: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
