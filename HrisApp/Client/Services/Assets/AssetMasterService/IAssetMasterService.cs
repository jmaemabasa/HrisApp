namespace HrisApp.Client.Services.Assets.AssetMasterService
{
    public interface IAssetMasterService
    {
        List<AssetMasterT> AssetMasterTs { get; set; }

        Task<List<AssetMasterT>> GetObjList();

        Task<AssetMasterT> GetSingleObj(int id);

        Task GetObj();

        Task CreateObj(AssetMasterT model);

        Task UpdateObj(AssetMasterT model);

        Task<int> GetLastCode(int type, int cat, int subcat);
    }
}