using HrisApp.Shared.Models.Assets.Licenses;

namespace HrisApp.Client.Services.Assets.Remarks.LicenseRemarksService
{
    public interface ILicenseRemarksService
    {
        Task<List<AssetLicenseRemarksT>> GetObjList(string code);
        Task<string> CreateObj(AssetLicenseRemarksT obj);
        Task<int> GetExistObj(string verifycode);
        Task UpdateObj(AssetLicenseRemarksT obj);
        Task DeleteAllObj(string verId);
    }
}
