namespace HrisApp.Client.Services.Assets.AssetMasterHistoryService
{
    public interface IAssetMasterHistoryService
    {
        List<AssetMasterHistoryT> AssetMasterHistoryTs { get; set; }

        Task<List<AssetMasterHistoryT>> GetObjList();

        Task<AssetMasterHistoryT> GetSingleObj(int id);

        Task GetObj();

        Task CreateObj(AssetMasterHistoryT model);

        Task UpdateObj(AssetMasterHistoryT model);

        Task UpdateDateReturned(int empid, int mainassetid, DateTime? released, AssetMasterHistoryT model);
    }
}