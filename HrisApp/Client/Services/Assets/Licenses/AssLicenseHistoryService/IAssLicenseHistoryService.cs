using HrisApp.Shared.Models.Assets.Licenses;

namespace HrisApp.Client.Services.Assets.Licenses.AssLicenseHistoryService
{
    public interface IAssLicenseHistoryService
    {
        List<AssetLicenseHistoryT> AssetLicenseHistoryTs { get; set; }

        Task<List<AssetLicenseHistoryT>> GetObjList();

        Task<AssetLicenseHistoryT> GetSingleObj(int id);

        Task<AssetLicenseHistoryT> GetObjByAccIDMainId(int accid, int mainid);

        Task GetObj();

        Task CreateObj(AssetLicenseHistoryT model);

        Task UpdateObj(AssetLicenseHistoryT model);

        Task UpdateDateUnassigned(AssetLicenseHistoryT obj);

        Task<string> GetTestConsole(int obj);
    }
}
