﻿using HrisApp.Shared.Models.Dashboard;

namespace HrisApp.Client.Services.MasterData.PositionService
{
    public interface IPositionService
    {
        List<PositionT> PositionTs { get; set; }

        Task<List<PositionT>> GetPositionList();

        Task GetPosByDepartment(int deptId);
        Task GetPosByDivision(int divId);
        Task GetPosBySection(int sectId);

        Task GetPosition();
        Task<PositionT> GetSinglePosition(int id);

        Task CreatePositionPerDept(string posName, string posCode, int divId, int deptId, int areaId, string summary, string educ, string work, string tskill, string kof, string capp, string othercom, string restrict, int plantilla, string verifyCode, string posType, string tempDur, int mpinternal, int mpexternal);
        Task CreatePositionPerSection(string posName, string posCode, int divId, int deptId, int sectId, int areaId, string summary, string educ, string work, string tskill, string kof, string capp, string othercom, string restrict, int plantilla, string verifyCode, string posType, string tempDur, int mpinternal, int mpexternal);
        Task UpdatePosition(PositionT position);

        //PLANTILLA
        List<DailyTotalPlantillaT> DailyTotalPlantillaTs { get; set; }
        Task<int> GetTotalPlantilla();
        Task CreateTotalPlantilla(int tootal, DateTime date);
        Task GetDbTotalPlantilla();


        List<PositionTechSkillT> PositionTechSkillTs { get; set; }
        Task<List<PositionTechSkillT>> GetTechSkill(string posCode);
        Task<string> CreateTechSkill(PositionTechSkillT obj);
        Task<int> GetExistTech(string verCode);
        Task UpdateTechSkill(PositionTechSkillT obj);
        Task DeleteTechSkills(string verId);

        List<PositionKnowledgeT> PositionKnowledgeTs { get; set; }
        Task<List<PositionKnowledgeT>> GetKnowledge(string posCode);
        Task<string> CreateKnowledge(PositionKnowledgeT obj);
        Task<int> GetExistKnowledge(string verCode);
        Task UpdateKnowledge(PositionKnowledgeT obj);
        Task DeleteKnowledge(string verId);

        List<PositionComAppT> PositionComAppTs { get; set; }
        Task<List<PositionComAppT>> GetComApp(string posCode);
        Task<string> CreateComApp(PositionComAppT obj);
        Task<int> GetExistComApp(string verCode);
        Task UpdateComApp(PositionComAppT obj);
        Task DeleteComApp(string verId);


        List<PositionWorkExpT> PositionWorkExpTs { get; set; }
        Task<List<PositionWorkExpT>> GetWorkExp(string posCode);
        Task<string> CreateWorkExp(PositionWorkExpT obj);
        Task<int> GetExistWorkExp(string verCode);
        Task UpdateWorkExp(PositionWorkExpT obj);
        Task DeleteWorkExp(string verId);

        List<PositionEducT> PositionEducTs { get; set; }
        Task<List<PositionEducT>> GetEduc(string posCode);
        Task<string> CreateEduc(PositionEducT obj);
        Task<int> GetExistEduc(string verCode);
        Task UpdateEduc(PositionEducT obj);
        Task DeleteEduc(string verId);
    }
}
