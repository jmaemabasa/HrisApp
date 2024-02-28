namespace HrisApp.Client.Services.Assets.AssetSubCategoryService
{
    public interface IAssetSubCategoryService
    {
        List<AssetSubCategoryT> AssetSubCategoryTs { get; set; }
        Task<List<AssetSubCategoryT>> GetObjList();
        Task<AssetSubCategoryT> GetSingleObj(int id);
        Task GetObj();
        Task CreateObj(AssetSubCategoryT model);
        Task UpdateObj(AssetSubCategoryT model);

        Task<int> GetLastCode();
    }
}
