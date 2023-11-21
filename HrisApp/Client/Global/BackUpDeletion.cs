using Newtonsoft.Json;
using System.Text;

namespace HrisApp.Client.Global
{
    public class BackUpDeletion
    {
        private readonly HttpClient _http;

        public BackUpDeletion(HttpClient http)
        {
            _http = http;
        }

        public async Task CreateBackUp(EmployeeT employee)
        {
            try
            {
                var jsonAuditData = JsonConvert.SerializeObject(employee);
                var content = new StringContent(jsonAuditData, Encoding.UTF8, "application/json");

                var response = await _http.PostAsync("/api/BackUpEmp/createbackupfile", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Back up created successfully. Response: {responseContent}");
                }
                else
                {
                    Console.WriteLine($"Failed to create Back up. Status Code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating audit: {ex.Message}");
            }
        }
    }
}
