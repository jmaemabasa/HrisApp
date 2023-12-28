namespace HrisApp.Client.Services.LeaveService
{
    public interface ILeaveService
    {
        List<LeaveTypesT> LeaveTypesTs { get; set; }
        Task<List<LeaveTypesT>> GetLeaveList();
        Task GetLeave();
        Task<LeaveTypesT> GetSingleLeave(int id);
        Task CreateLeave(string name, int unit, string desc);
        Task UpdateLeave(LeaveTypesT obj);
    }
}
