namespace HrisApp.Client.Services.Assets.AssetAccessImageService
{
    public interface IAssetAccessImageService
    {
        List<AssetAccessImageT> AssetAccessImageTs { get; }

        Task AttachFile(MultipartFormDataContent formdata, int category, int subcat, string jmcode, string remarks);

        Task AttachFileCopyTo(MultipartFormDataContent formdata, int category, int subcat, string jmcode, string remarks);
        Task AttachFilePanel(MultipartFormDataContent formdata, int category, int subcat, string jmcode, string remarks);

        Task<byte[]> GetImageData(string jmcode);

        Task<byte[]> GetImageDataByFileName(string filename);

        Task<byte[]> GetImageDataById(int id);

        Task UpdateDBImage(AssetAccessImageT img);

        Task<AssetAccessImageT> GetSingleImage(int id);

        Task<List<AssetAccessImageT>> GetObjList();
        Task<List<AssetAccessImageT>> GetObjListByCode(string code);

        Task GetAllImagesPerAss(string jmcode);

        Task DeleteAssetImg(string filename, string assetcode);
    }
}