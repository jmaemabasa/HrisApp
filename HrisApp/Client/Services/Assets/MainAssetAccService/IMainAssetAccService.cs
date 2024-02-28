namespace HrisApp.Client.Services.Assets.MainAssetAccService
{
    public interface IMainAssetAccService
    {
        List<MainAssetAccessoriesT> MainAssetAccessoriesTs { get; set; }

        Task<List<MainAssetAccessoriesT>> GetObjList();

        Task<MainAssetAccessoriesT> GetSingleObj(int id);

        Task GetObj();

        Task CreateObj(MainAssetAccessoriesT model);

        Task UpdateObj(MainAssetAccessoriesT model);
    }
}