namespace HrisApp.Client.Services.Assets.AssVehicleImageSvc
{
    public interface IAssVehicleImageSvc
    {
        List<AssetVehicleImageT> AssetVehicleImageTs { get; }

        Task AttachFile(MultipartFormDataContent formdata, int category, int subcat, string jmcode, string remarks);

        Task AttachFilePanel(MultipartFormDataContent formdata, int category, int subcat, string jmcode, string remarks);

        Task<byte[]> GetImageData(string jmcode);

        Task<byte[]> GetImageDataAll(string filename);

        Task UpdateDBImage(AssetVehicleImageT img);

        Task<AssetVehicleImageT> GetSingleImage(int id);

        Task<List<AssetVehicleImageT>> GetObjList();

        Task GetAllImagesPerAss(string jmcode);

        Task DeleteAssetImg(string filename, string assetcode);
    }
}
