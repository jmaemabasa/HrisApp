namespace HrisApp.Client.Services.Assets.AssetImageService
{
    public interface IAssetImageService
    {
        List<AssetImageT> AssetImageTs { get; }

        Task AttachFile(MultipartFormDataContent formdata, int category, int subcat, string jmcode, string remarks);
        Task AttachFileCopyTo(MultipartFormDataContent formdata, int category, int subcat, string jmcode, string remarks);

        Task AttachFilePanel(MultipartFormDataContent formdata, int category, int subcat, string jmcode, string remarks);

        Task<byte[]> GetImageData(string jmcode);

        Task<byte[]> GetImageDataByFileName(string filename);
        Task<byte[]> GetImageDataById(int id);

        Task UpdateDBImage(AssetImageT img);

        Task<AssetImageT> GetSingleImage(int id);
        Task<AssetImageT> GetSingleImageByCode(string code);

        Task<List<AssetImageT>> GetObjList();
        Task<List<AssetImageT>> GetObjListByCode(string code);

        Task GetAllImagesPerAss(string jmcode);

        Task DeleteAssetImg(string filename, string assetcode);
    }
}