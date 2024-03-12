namespace HrisApp.Client.Services.Assets.AssetImageService
{
    public interface IAssetImageService
    {
        List<AssetImageT> AssetImageTs { get; }

        Task AttachFile(MultipartFormDataContent formdata, int category, int subcat, string jmcode, string remarks);

        Task AttachFilePanel(MultipartFormDataContent formdata, int category, int subcat, string jmcode, string remarks);

        Task<byte[]> GetImageData(string jmcode);

        Task<byte[]> GetImageDataAll(string filename);

        Task UpdateDBImage(AssetImageT img);

        Task<AssetImageT> GetSingleImage(int id);

        Task<List<AssetImageT>> GetObjList();

        Task GetAllImagesPerAss(string jmcode);

        Task DeleteAssetImg(string filename, string assetcode);
    }
}