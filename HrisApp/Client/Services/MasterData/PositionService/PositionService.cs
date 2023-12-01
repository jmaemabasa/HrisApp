﻿using HrisApp.Shared.Models.Employee;
using System.Reflection.Emit;

namespace HrisApp.Client.Services.MasterData.PositionService
{
#nullable disable
    public class PositionService : IPositionService
    {
        MainsService _mainService = new MainsService();
        private readonly HttpClient _httpClient;
        public PositionService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<PositionT> PositionTs { get; set; }

        //GEEEEEEEEEEEET
        //Get/Return All PositionList
        public async Task<List<PositionT>> GetPositionList()
        {
            return await _httpClient.GetFromJsonAsync<List<PositionT>>("api/Position");
        }

        //Get Position by Department
        public async Task GetPosByDepartment(int deptId)
        {
            var pos = await _httpClient.GetFromJsonAsync<List<PositionT>>($"api/Position/PosByDepartment/{deptId}");
            if (pos != null)
            {
                PositionTs = pos;
            }
        }

        //Get Position by Division
        public async Task GetPosByDivision(int divId)
        {
            var pos = await _httpClient.GetFromJsonAsync<List<PositionT>>($"api/Position/PosByDivision/{divId}");
            if (pos != null)
            {
                PositionTs = pos;
            }
        }

        //Get Position by Section
        public async Task GetPosBySection(int sectId)
        {
            var pos = await _httpClient.GetFromJsonAsync<List<PositionT>>($"api/Position/PosBySection/{sectId}");
            if (pos != null)
            {
                PositionTs = pos;
            }
        }

        //Get All PositionList set to PositionTs
        public async Task GetPosition()
        {
            var result = await _httpClient.GetFromJsonAsync<List<PositionT>>("api/Position/GetPosition");
            if (result != null)
            {
                PositionTs = result;
            }
        }
        public async Task<PositionT> GetSinglePosition(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<PositionT>($"api/Position/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        //CREATE AND UPDATEEEEEE
        public async Task CreatePositionPerDept(string posName, string posCode,int divId, int deptId, int areaId, string summary, string educ, string work, string tskill, string kof, string capp, string othercom, string restrict, int plantilla, string verifyCode)
        {
            PositionT newPosition = new()
            {
                Name = posName,
                DivisionId = divId,
                DepartmentId = deptId,
                PosCode = posCode,
                AreaId = areaId,
                JobSummary = summary,
                PosEducation = educ,
                WorkExperience = work,
                OtherCompetencies = othercom,
                Restrictions = restrict,
                Plantilla = plantilla,
                VerifyId = verifyCode
            };

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/Position/CreatePosition", newPosition);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Error: " + errorMessage);
            }
        }
        public async Task CreatePositionPerSection(string posName, string posCode, int divId, int deptId, int sectId, int areaId, string summary,string educ, string work, string tskill, string kof, string capp, string othercom, string restrict, int plantilla, string verifyCode)
        {
            PositionT newPosition = new()
            {
                Name = posName,
                PosCode = posCode,
                DivisionId = divId,
                DepartmentId = deptId,
                SectionId = sectId,
                AreaId = areaId,
                JobSummary = summary,
                PosEducation = educ,
                WorkExperience = work,
                OtherCompetencies = othercom,
                Restrictions = restrict,
                Plantilla = plantilla,
                VerifyId = verifyCode
                
            };

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/Position/CreatePosition", newPosition);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Error: " + errorMessage);
            }
        }
        public async Task UpdatePosition(PositionT position)
        {
            try
            {
                var result = await _httpClient.PutAsJsonAsync($"api/Position/UpdatePosition", position);
                result.EnsureSuccessStatusCode();
                var index = PositionTs.FindIndex(s => s.Id == position.Id);
                if (index >= 0)
                {
                    PositionTs[index] = position;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message + "daot ang services");
            }
        }




        public List<PositionTechSkillT> PositionTechSkillTs { get; set; } = new List<PositionTechSkillT>();
        public async Task<List<PositionTechSkillT>> GetTechSkill(string posCode)
        {
            var result = await _httpClient.GetFromJsonAsync<List<PositionTechSkillT>>($"api/Position/GetTechSkill?posCode={posCode}");
            return result;
        }
        public async Task<int> GetExistTech(string verCode)
        {
            var result = await _httpClient.GetFromJsonAsync<int>($"api/Position/GetExistingTechSkill?verifyCode={verCode}");
            return result;
        }
        public async Task UpdateTechSkill(PositionTechSkillT obj)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Position/UpdateTechSkill/{obj.VerifyId}", obj);
            await SetTechSkill(result);
        }
        public async Task<string> CreateTechSkill(PositionTechSkillT obj)
        {
            Console.WriteLine("Saving tech skills");
            var result = await _httpClient.PostAsJsonAsync("api/Position/CreateTechSkill", obj);
            var response = await result.Content.ReadFromJsonAsync<PositionTechSkillT>();
            return response?.PosCode;
        }
        public async Task DeleteTechSkills(string verId)
        {
            var result = await _httpClient.DeleteAsync($"api/Position/DeleteAllTechSkills/{verId}");
        }
        public async Task SetTechSkill(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<PositionTechSkillT>>();
            PositionTechSkillTs = response;
        }




        public List<PositionKnowledgeT> PositionKnowledgeTs { get; set; } = new List<PositionKnowledgeT>();
        public async Task<List<PositionKnowledgeT>> GetKnowledge(string posCode)
        {
            var result = await _httpClient.GetFromJsonAsync<List<PositionKnowledgeT>>($"api/Position/GetKnowledge?posCode={posCode}");
            return result;
        }
        public async Task<int> GetExistKnowledge(string verCode)
        {
            var result = await _httpClient.GetFromJsonAsync<int>($"api/Position/GetExistingKnowledge?verifyCode={verCode}");
            return result;
        }
        public async Task UpdateKnowledge(PositionKnowledgeT obj)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Position/UpdateKnowledge/{obj.VerifyId}", obj);
            await SetKnowledge(result);
        }
        public async Task<string> CreateKnowledge(PositionKnowledgeT obj)
        {
            Console.WriteLine("Saving knowdlegde");
            var result = await _httpClient.PostAsJsonAsync("api/Position/CreateKnowledge", obj);
            var response = await result.Content.ReadFromJsonAsync<PositionKnowledgeT>();
            return response?.PosCode;
        }
        public async Task DeleteKnowledge(string verId)
        {
            var result = await _httpClient.DeleteAsync($"api/Position/DeleteAllKnowledge/{verId}");
        }
        public async Task SetKnowledge(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<PositionKnowledgeT>>();
            PositionKnowledgeTs = response;
        }



        public List<PositionComAppT> PositionComAppTs { get; set; } = new List<PositionComAppT>();
        public async Task<List<PositionComAppT>> GetComApp(string posCode)
        {
            var result = await _httpClient.GetFromJsonAsync<List<PositionComAppT>>($"api/Position/GetComApp?posCode={posCode}");
            return result;
        }
        public async Task<int> GetExistComApp(string verCode)
        {
            var result = await _httpClient.GetFromJsonAsync<int>($"api/Position/GetExistingComApp?verifyCode={verCode}");
            return result;
        }
        public async Task UpdateComApp(PositionComAppT obj)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Position/UpdateComApp/{obj.VerifyId}", obj);
            await SetComApp(result);
        }
        public async Task<string> CreateComApp(PositionComAppT obj)
        {
            Console.WriteLine("Saving ComApp");
            var result = await _httpClient.PostAsJsonAsync("api/Position/CreateComApp", obj);
            var response = await result.Content.ReadFromJsonAsync<PositionComAppT>();
            return response?.PosCode;
        }
        public async Task DeleteComApp(string verId)
        {
            var result = await _httpClient.DeleteAsync($"api/Position/DeleteAllComApp/{verId}");
        }
        public async Task SetComApp(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<PositionComAppT>>();
            PositionComAppTs = response;
        }
    }
}
