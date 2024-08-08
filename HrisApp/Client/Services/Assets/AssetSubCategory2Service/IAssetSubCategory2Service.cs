namespace HrisApp.Client.Services.Assets.AssetSubCategory2Service
{
    public interface IAssetSubCategory2Service
    {
        List<AssetSubCategory2T> AssetSubCategoryTs { get; set; }
        Task<List<AssetSubCategory2T>> GetObjList();
        Task<AssetSubCategory2T> GetSingleObj(int id);
        Task GetObj();
        Task CreateObj(AssetSubCategory2T model);
        Task UpdateObj(AssetSubCategory2T model);

        Task<int> GetLastCode();
    }
}
