namespace HrisApp.Client.Services.Assets.Remarks.AccRemarksService
{
    public interface IAccRemarksService
    {
        Task<List<AccessoryRemarksT>> GetObjList(string code);
        Task<string> CreateObj(AccessoryRemarksT obj);
        Task<int> GetExistObj(string verifycode);
        Task UpdateObj(AccessoryRemarksT obj);
        Task DeleteAllObj(string verId);
    }
}
