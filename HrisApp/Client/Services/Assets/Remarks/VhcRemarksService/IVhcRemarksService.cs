namespace HrisApp.Client.Services.Assets.Remarks.VhcRemarksService
{
    public interface IVhcRemarksService
    {
        Task<List<VehicleRemarksT>> GetObjList(string code);
        Task<string> CreateObj(VehicleRemarksT obj);
        Task<int> GetExistObj(string verifycode);
        Task UpdateObj(VehicleRemarksT obj);
        Task DeleteAllObj(string verId);
    }
}
