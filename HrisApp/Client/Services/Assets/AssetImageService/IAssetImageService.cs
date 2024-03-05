namespace HrisApp.Client.Services.Assets.AssetImageService
{
    public interface IAssetImageService
    {
        List<AssetImageT> AssetImageTs { get; }

        Task AttachFile(MultipartFormDataContent formdata, string assetcode, int category, int subcat, string jmcode);

        Task AttachFilePanel(MultipartFormDataContent formdata, string assetcode, int category, int subcat, string jmcode);

        Task<byte[]> GetImageData(string jmcode);

        Task<byte[]> GetImageDataAll(string assetcode);

        Task UpdateDBImage(AssetImageT img);

        Task<AssetImageT> GetSingleImage(int id);

        Task<List<AssetImageT>> GetObjList();

        Task GetAllImagesPerAss(string jmcode);

        Task DeleteAssetImg(string filename, string assetcode);
    }
}