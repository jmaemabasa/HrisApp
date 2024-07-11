namespace HrisApp.Client.Services.APiS.MasterDataApiS
{
    public interface IMasterDataApiService
    {
        Task UpdateFSSStatus(int empid, int status); 
        Task UpdateSalesmanStatus(int empid, int status);
        Task UpdateWmsUserStatus(int empid, int status);
        Task<byte[]> GetImage();
    }
}