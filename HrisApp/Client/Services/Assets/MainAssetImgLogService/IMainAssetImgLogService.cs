namespace HrisApp.Client.Services.Assets.MainAssetImgLogService
{
    public interface IMainAssetImgLogService
    {
        Task AttachFile(MultipartFormDataContent formdata, int category, int subcat, string jmcode, string remarks);
        Task<List<MainAssetImgLogT>> GetAllImagesPerAss(string jmcode);
        Task AttachFilePanel(MultipartFormDataContent formdata, int category, int subcat, string jmcode, string remarks);
        Task<byte[]> GetImageDataByFileName(string filename);
        Task DeleteAssetImg(string filename, string assetcode);
    }
}
