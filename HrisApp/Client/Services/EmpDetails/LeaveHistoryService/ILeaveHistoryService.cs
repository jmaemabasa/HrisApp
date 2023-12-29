namespace HrisApp.Client.Services.EmpDetails.LeaveHistoryService
{
    public interface ILeaveHistoryService
    {
        List<Emp_LeaveHistoryT> Emp_LeaveHistoryTs { get; set; }
        Task<List<Emp_LeaveHistoryT>> GetLeaveHistoryList();
        Task GetLeaveHistory();
        Task<Emp_LeaveHistoryT> GetSingleLeaveHistory(int id);
        Task<Emp_LeaveHistoryT> GetSingleLeaveHistoryByVerId(string verid);
        Task CreateLeaveHistory(string verid, string leavetype, DateTime? from, DateTime? to, int noofdays, string purpose);
        Task UpdateLeaveHistory(Emp_LeaveHistoryT obj);
    }
}
