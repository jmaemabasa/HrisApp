namespace HrisApp.Client.Services.MasterData.VendorService
{
    public interface IVendorService
    {
        List<VendorT> VendorTs { get; set; }
        Task<List<VendorT>> GetObjList();
        Task<VendorT> GetSingleObj(int id);
        Task GetObj();
        Task CreateObj(VendorT model);
        Task UpdateObj(VendorT model);
        Task<string> DeleteObj(int id);

        Task<int> IsExistCode(string code);
    }
}
