namespace HrisApp.Client.Services.Assets.AssetCategoryService
{
    public interface IAssetCategoryService
    {
        List<AssetCategoryT> AssetCategoryTs { get; set; }
        Task<List<AssetCategoryT>> GetObjList();
        Task<AssetCategoryT> GetSingleObj(int id);
        Task GetObj();
        Task CreateObj(AssetCategoryT model);
        Task UpdateObj(AssetCategoryT model);

        Task<int> GetLastCode();
    }
}
