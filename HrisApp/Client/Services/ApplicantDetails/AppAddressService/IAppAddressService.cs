namespace HrisApp.Client.Services.ApplicantDetails.AppAddressService
{
    public interface IAppAddressService
    {
        List<App_AddressT> AddressT { get; set; }

        Task<string> CreateAddress(App_AddressT address);
        Task GetAddress();
        Task<App_AddressT> GetSingleAddress(int id);
        Task UpdateAddress(App_AddressT address);
        Task DeleteAddress(int id);
    }
}
