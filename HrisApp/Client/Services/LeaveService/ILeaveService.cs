namespace HrisApp.Client.Services.LeaveService
{
    public interface ILeaveService
    {
        List<LeaveTypesT> LeaveTypesTs { get; set; }
        Task<List<LeaveTypesT>> GetLeaveList();
        Task GetLeave();
    }
}
