namespace HrisApp.Client.Services.Assets.Remarks.ConsumeRemarksService
{
    public interface IConsumeRemarksService
    {
        Task<List<ConsumableRemarksT>> GetObjList(string code);
        Task<string> CreateObj(ConsumableRemarksT obj);
        Task<int> GetExistObj(string verifycode);
        Task UpdateObj(ConsumableRemarksT obj);
        Task DeleteAllObj(string verId);
    }
}
