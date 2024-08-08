namespace HrisApp.Client.Services.Assets.AccessImgLogService
{
    public interface IAccessImgLogService
    {
        Task AttachFile(MultipartFormDataContent formdata, int category, int subcat, string jmcode, string remarks);
        Task<List<AccessImgLogT>> GetAllImagesPerAss(string jmcode);
        Task AttachFilePanel(MultipartFormDataContent formdata, int category, int subcat, string jmcode, string remarks);
        Task<byte[]> GetImageDataByFileName(string filename);
        Task DeleteAssetImg(string filename, string assetcode);
    }
}
