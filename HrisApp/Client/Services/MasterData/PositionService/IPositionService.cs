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

        Task CreatePositionPerDept(string posName, string posCode,int divId, int deptId, int areaId, string summary, string educ, string work, string tskill, string kof, string capp, string othercom, string restrict, int plantilla, string verifyCode);
        Task CreatePositionPerSection(string posName, string posCode, int divId, int deptId, int sectId, int areaId, string summary, string educ, string work, string tskill, string kof, string capp, string othercom, string restrict, int plantilla, string verifyCode);
        Task UpdatePosition(PositionT position);



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
    }
}
