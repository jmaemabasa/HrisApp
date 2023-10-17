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

        Task CreatePositionPerDept(string posName, int divId, int deptId);
        Task CreatePositionPerSection(string posName, int divId, int deptId, int sectId);
        Task UpdatePosition(PositionT position);
    }
}
