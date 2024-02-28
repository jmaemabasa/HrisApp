namespace HrisApp.Client.Services.Assets.AssetTypeService
{
    public interface IAssetTypeService
    {
        List<AssetTypesT> AssetTypesTs { get; set; }
        Task<List<AssetTypesT>> GetObjList();
        Task<AssetTypesT> GetSingleObj(int id);
        Task GetObj();
        Task CreateObj(AssetTypesT model);
        Task UpdateObj(AssetTypesT model);

        Task<int> GetLastCode();
    }
}
