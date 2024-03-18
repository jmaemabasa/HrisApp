namespace HrisApp.Client.Services.Assets.AssetVehicleService
{
    public interface IAssetVehicleService
    {
        List<AssetVehiclesT> AssetVehiclesTs { get; set; }

        Task<List<AssetVehiclesT>> GetObjList();

        Task<AssetVehiclesT> GetSingleObj(int id);

        Task GetObj();

        Task CreateObj(AssetVehiclesT model);

        Task UpdateObj(AssetVehiclesT model);

        Task<int> GetLastCode(int type, int cat, int subcat);

        Task<HttpResponseMessage> QRPrint(string AssetCode);

        Task<string> QRGenerate(string AssetCode);
    }
}