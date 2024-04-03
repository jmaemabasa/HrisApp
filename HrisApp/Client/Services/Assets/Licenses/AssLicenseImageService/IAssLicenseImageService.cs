namespace HrisApp.Client.Services.Assets.Licenses.AssLicenseImageService
{
    public interface IAssLicenseImageService
    {
        List<AssLicenseImageT> AssLicenseImageTs { get; }

        Task AttachFile(MultipartFormDataContent formdata, int category, int subcat, string jmcode, string remarks);

        Task AttachFilePanel(MultipartFormDataContent formdata, int category, int subcat, string jmcode, string remarks);

        Task<byte[]> GetImageData(string jmcode);

        Task<byte[]> GetImageDataAll(string filename);

        Task UpdateDBImage(AssLicenseImageT img);

        Task<AssLicenseImageT> GetSingleImage(int id);

        Task<List<AssLicenseImageT>> GetObjList();

        Task GetAllImagesPerAss(string jmcode);

        Task DeleteAssetImg(string filename, string assetcode);
    }
}
