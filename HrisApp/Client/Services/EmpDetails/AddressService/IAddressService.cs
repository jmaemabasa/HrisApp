namespace HrisApp.Client.Services.EmpDetails.AddressService
{
    public interface IAddressService
    {
        List<Emp_AddressT> AddressT { get; set; }

        Task<string> CreateAddress(Emp_AddressT address);
        Task GetAddress();
        Task<Emp_AddressT> GetSingleAddress(int id);
        Task UpdateAddress(Emp_AddressT address);
    }
}
