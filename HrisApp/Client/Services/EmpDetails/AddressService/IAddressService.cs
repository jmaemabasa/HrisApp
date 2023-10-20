namespace HrisApp.Client.Services.EmpDetails.AddressService
{
    public interface IAddressService
    {
        List<AddressT> AddressT { get; set; }

        Task<string> CreateAddress(AddressT address);
        Task GetAddress();
        Task<AddressT> GetSingleAddress(int id);
        Task UpdateAddress(AddressT address);
    }
}
