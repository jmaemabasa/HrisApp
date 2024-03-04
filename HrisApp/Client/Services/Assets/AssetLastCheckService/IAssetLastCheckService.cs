namespace HrisApp.Client.Services.Assets.AssetLastCheckService
{
    public interface IAssetLastCheckService
    {
        List<AssetLastCheckT> AssetLastCheckTs { get; set; }

        Task<List<AssetLastCheckT>> GetObjList();

        Task<AssetLastCheckT> GetSingleObj(int id);

        Task GetObj();

        Task CreateObj(AssetLastCheckT model);

        Task UpdateObj(AssetLastCheckT model);
    }
}