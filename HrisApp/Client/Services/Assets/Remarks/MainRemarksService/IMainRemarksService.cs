namespace HrisApp.Client.Services.Assets.Remarks.MainRemarksService
{
    public interface IMainRemarksService
    {
        Task<List<MainRemarksT>> GetObjList(string code);
        Task<string> CreateObj(MainRemarksT obj);
        Task<int> GetExistObj(string verifycode);
        Task UpdateObj(MainRemarksT obj);
        Task DeleteAllObj(string verId);

    }
}
