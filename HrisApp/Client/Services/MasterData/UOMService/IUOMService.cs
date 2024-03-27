namespace HrisApp.Client.Services.MasterData.UOMService
{
    public interface IUOMService
    {
        List<UOMT> UOMTs { get; set; }
        Task<List<UOMT>> GetObjList();
        Task<UOMT> GetSingleObj(int id);
        Task GetObj();
        Task CreateObj(UOMT model);
        Task UpdateObj(UOMT model);
        Task<string> DeleteObj(int id);

        Task<int> IsExistCode(string code);
    }
}
