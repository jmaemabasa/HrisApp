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

        //[HttpPost("createtextfile")]
        //public IActionResult CreateTextFile(AuditLogData auditLogData)
        //{
        //    try
        //    {
        //        var currentDate = DateTime.Now.ToString("yyyyMMdd");
        //        var filePath = Path.Combine(_evs.ContentRootPath, "AuditLogs", $"auditlog_{currentDate}.txt");

        //        // Check if the file exists
        //        bool fileExists = System.IO.File.Exists(filePath);

        //        // Create or append the content to the file
        //        string fileContent = $"{auditLogData.UserId}, {auditLogData.Action}, {auditLogData.TableName}, {auditLogData.AddInfo}, {auditLogData.BeforeUpdate}, {auditLogData.Date}";

        //        // If the file doesn't exist, add headers at the first row
        //        if (!fileExists)
        //        {
        //            string headers = "UserId, Action, TableName, AddInfo, BeforeUpdate, Date";
        //            fileContent = $"{headers}\n{fileContent}";
        //        }

        //        // Append the content to the file (create the file if it doesn't exist)
        //        System.IO.File.AppendAllText(filePath, fileContent + Environment.NewLine + Environment.NewLine, Encoding.UTF8);

        //        _logger.LogInformation($"Text file created/appended at: {filePath}");

        //        return Ok("Text file created/appended successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Error creating/appending text file: {ex.Message}");
        //        return StatusCode(500, "Internal Server Error");
        //    }
        //}

        //[HttpPost("createexcelfile")]
        //public IActionResult CreateExcelFile(AuditLogData auditLogData)
        //{
        //    try
        //    {
        //        var currentDate = DateTime.Now.ToString("yyyyMMdd");
        //        var filePath = Path.Combine(_evs.ContentRootPath, "AuditLogs", $"auditlog_{currentDate}.xlsx");

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
        //                worksheet.Cells[$"A{row + 1}"].Value = auditLogData.UserId;
        //                worksheet.Cells[$"B{row + 1}"].Value = auditLogData.Action;
        //                worksheet.Cells[$"C{row + 1}"].Value = auditLogData.TableName;
        //                worksheet.Cells[$"D{row + 1}"].Value = auditLogData.AddInfo;
        //                worksheet.Cells[$"E{row + 1}"].Value = auditLogData.BeforeUpdate;
        //                worksheet.Cells[$"F{row + 1}"].Value = auditLogData.Date;

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
        //                worksheet.Cells["A2"].Value = auditLogData.UserId;
        //                worksheet.Cells["B2"].Value = auditLogData.Action;
        //                worksheet.Cells["C2"].Value = auditLogData.TableName;
        //                worksheet.Cells["D2"].Value = auditLogData.AddInfo;
        //                worksheet.Cells["E2"].Value = auditLogData.BeforeUpdate;
        //                worksheet.Cells["F2"].Value = auditLogData.Date;

        //                // Save the Excel package
        //                package.SaveAs(filePath);  // Use SaveAs with FileInfo
        //            }
        //        }

        //        _logger.LogInformation($"Excel file created at: {filePath}");

        //        return Ok("Excel file created successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Error creating Excel file: {ex.Message}");
        //        return StatusCode(500, "Internal Server Error");
        //    }
        //}

        [HttpPost("createcsvfile")]
        public IActionResult CreateCsvFile(AuditLogData auditLogData)
        {
            try
            {
                var currentDate = DateTime.Now.ToString("yyyyMMdd");
                var filePath = Path.Combine(_evs.ContentRootPath, "AuditLogs", $"auditlog_{currentDate}.csv");

                // Check if the file already exists
                if (System.IO.File.Exists(filePath))
                {
                    // Append data to the existing CSV file
                    var csvRow = $"{auditLogData.UserId},{auditLogData.Action},{auditLogData.Date}";
                    System.IO.File.AppendAllText(filePath, csvRow + Environment.NewLine);
                }
                else
                {
                    // File does not exist, create a new one
                    var csvContent = new StringBuilder();
                    csvContent.AppendLine("UserId,Action,Date");
                    var csvRow = $"{auditLogData.UserId},{auditLogData.Action},{auditLogData.Date}";
                    csvContent.AppendLine(csvRow);

                    // Save the CSV content to the file
                    System.IO.File.WriteAllText(filePath, csvContent.ToString());
                }

                _logger.LogInformation($"CSV file created at: {filePath}");

                return Ok("CSV file created successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating CSV file: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

    }
}
