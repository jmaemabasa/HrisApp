namespace HrisApp.Client.Services.Assets.Consumables.ConsumableImgService
{
    public interface IConsumableImgService
    {
        List<ConsumableImageT> ConsumableImageTs { get; }

        Task AttachFile(MultipartFormDataContent formdata, int category, int subcat, string jmcode, string remarks);

        Task AttachFilePanel(MultipartFormDataContent formdata, int category, int subcat, string jmcode, string remarks);

        Task<byte[]> GetImageData(string jmcode);

        Task<byte[]> GetImageDataAll(string filename);

        Task UpdateDBImage(ConsumableImageT img);

        Task<ConsumableImageT> GetSingleImage(int id);

        Task<List<ConsumableImageT>> GetObjList();

        Task GetAllImagesPerAss(string jmcode);

        Task DeleteAssetImg(string filename, string assetcode);
    }
}
