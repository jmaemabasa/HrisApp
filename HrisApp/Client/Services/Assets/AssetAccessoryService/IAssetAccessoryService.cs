namespace HrisApp.Client.Services.Assets.AssetAccessoryService
{
    public interface IAssetAccessoryService
    {
        List<AssetAccessoryT> AssetAccessoryTs { get; set; }

        Task<List<AssetAccessoryT>> GetObjList();

        Task<AssetAccessoryT> GetSingleObj(int id);

        Task GetObj();

        Task CreateObj(AssetAccessoryT model);

        Task UpdateObj(AssetAccessoryT model);

        Task<int> GetLastCode(int cat, int subcat);

        Task<HttpResponseMessage> QRPrint(string AssetCode);

        Task<string> QRGenerate(string AssetCode);
    }
}