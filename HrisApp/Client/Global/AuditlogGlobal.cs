using Newtonsoft.Json;
using System.Text;

namespace HrisApp.Client.Global
{
    public class AuditlogGlobal
    {
        private readonly HttpClient _http;

        public AuditlogGlobal(HttpClient http)
        {
            _http = http;
        }

        //public async Task CreateAudit(int userId, string action, string tablename, string addInfo, string beforeUpdate, DateTime date)
        //{
        //    try
        //    {
        //        var auditData = new
        //        {
        //            UserId = userId,
        //            Action = action,
        //            TableName = tablename,
        //            AddInfo = addInfo, 
        //            BeforeUpdate = beforeUpdate,
        //            Date = date
        //        };

        //        var jsonAuditData = JsonConvert.SerializeObject(auditData);
        //        var content = new StringContent(jsonAuditData, Encoding.UTF8, "application/json");

        //        var response = await _http.PostAsync($"/api/Auditlog/createexcelfile?UserID={userId}&Action={action}&TableName={tablename}&AddInfo={addInfo}&BeforeUpdate={beforeUpdate}&Date={date}", content);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var responseContent = await response.Content.ReadAsStringAsync();
        //            Console.WriteLine($"Audit created successfully. Response: {responseContent}");
        //        }
        //        else
        //        {
        //            Console.WriteLine($"Failed to create audit. Status Code: {response.StatusCode}");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error creating audit: {ex.Message}");
        //    }
        //}
        //public async Task CreateAudit(int userId, string action, string tablename, string addInfo, string beforeUpdate, DateTime date)
        //{
        //    try
        //    {
        //        var auditData = new
        //        {
        //            UserId = userId,
        //            Action = action,
        //            TableName = tablename,
        //            AddInfo = addInfo,
        //            BeforeUpdate = beforeUpdate,
        //            Date = date
        //        };

        //        var jsonAuditData = JsonConvert.SerializeObject(auditData);
        //        var content = new StringContent(jsonAuditData, Encoding.UTF8, "application/json");

        //        var response = await _http.PostAsync("/api/Auditlog/createexcelfile", content);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var responseContent = await response.Content.ReadAsStringAsync();
        //            Console.WriteLine($"Audit created successfully. Response: {responseContent}");
        //        }
        //        else
        //        {
        //            Console.WriteLine($"Failed to create audit. Status Code: {response.StatusCode}");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error creating audit: {ex.Message}");
        //    }
        //}

        public async Task CreateAudit(int userId, string action, string tablename, string addInfo, string beforeUpdate, DateTime date)
        {
            try
            {
                var auditData = new
                {
                    UserId = userId,
                    Action = action,
                    TableName = tablename,
                    AddInfo = addInfo,
                    BeforeUpdate = beforeUpdate,
                    Date = date
                };

                var jsonAuditData = JsonConvert.SerializeObject(auditData);
                var content = new StringContent(jsonAuditData, Encoding.UTF8, "application/json");

                var response = await _http.PostAsync("/api/Auditlog/createtextfile", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Audit created successfully. Response: {responseContent}");
                }
                else
                {
                    Console.WriteLine($"Failed to create audit. Status Code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating audit: {ex.Message}");
            }
        }
    }
}
