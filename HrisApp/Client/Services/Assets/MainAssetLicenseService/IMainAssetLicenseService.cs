namespace HrisApp.Client.Services.Assets.MainAssetLicenseService
{
    public interface IMainAssetLicenseService
    {
        List<MainAssetLicensesT> MainAssetLicensesTs { get; set; }

        Task<List<MainAssetLicensesT>> GetObjList();

        Task<MainAssetLicensesT> GetSingleObj(int id);

        Task GetObj();

        Task CreateObj(MainAssetLicensesT model);

        Task UpdateObj(MainAssetLicensesT model);

        Task DeleteAccessory(int mainid, int accid);
    }
}
