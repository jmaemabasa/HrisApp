using HrisApp.Shared.Models.Assets.Licenses;

namespace HrisApp.Client.Services.Assets.Licenses.AssLicenseService
{
    public interface IAssLicenseService
    {
        List<AssetLicenseT> AssetLicenseTs { get; set; }

        Task<List<AssetLicenseT>> GetObjList();

        Task<AssetLicenseT> GetSingleObj(int id);
        Task<AssetLicenseT> GetSingleObjByCode(string code);

        Task GetObj();

        Task CreateObj(AssetLicenseT model);

        Task UpdateObj(AssetLicenseT model);

        Task<int> GetLastCode(int cat, int subcat);

        Task<HttpResponseMessage> QRPrint(string AssetCode);

        Task<string> QRGenerate(string AssetCode);
    }
}
