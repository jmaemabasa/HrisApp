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

        Task CreatePositionPerDept(string posName, string posCode,int divId, int deptId, int areaId, string summary, string educ, string work, string tskill, string kof, string capp, string othercom, string restrict, int plantilla);
        Task CreatePositionPerSection(string posName, string posCode, int divId, int deptId, int sectId, int areaId, string summary, string educ, string work, string tskill, string kof, string capp, string othercom, string restrict, int plantilla);
        Task UpdatePosition(PositionT position);
    }
}
