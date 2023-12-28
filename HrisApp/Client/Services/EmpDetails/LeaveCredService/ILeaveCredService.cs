namespace HrisApp.Client.Services.EmpDetails.LeaveCredService
{
    public interface ILeaveCredService
    {
        List<Emp_LeaveCreditT> Emp_LeaveCreditTs { get; set; }
        Task<List<Emp_LeaveCreditT>> GetLeaveCredList();
        Task GetLeaveCred();
        Task<Emp_LeaveCreditT> GetSingleLeaveCred(int id);
        Task<Emp_LeaveCreditT> GetSingleLeaveCredByVerId(string verid);
        Task CreateLeaveCred(string verid, int el, int ml, int pl, int sl, int vl, int ol);
        Task UpdateLeaveCred(Emp_LeaveCreditT obj);
    }
}
