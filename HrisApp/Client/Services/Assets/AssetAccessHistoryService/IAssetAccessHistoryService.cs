namespace HrisApp.Client.Services.Assets.AssetAccessHistoryService
{
    public interface IAssetAccessHistoryService
    {
        List<AssetAccessHistoryT> AssetAccessHistoryTs { get; set; }

        Task<List<AssetAccessHistoryT>> GetObjList();

        Task<AssetAccessHistoryT> GetSingleObj(int id);

        Task GetObj();

        Task CreateObj(AssetAccessHistoryT model);

        Task UpdateObj(AssetAccessHistoryT model);

        Task UpdateDateUnassigned(AssetAccessHistoryT obj);

        Task<string> GetTestConsole(int obj);
    }
}