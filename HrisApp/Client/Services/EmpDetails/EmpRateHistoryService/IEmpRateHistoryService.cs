namespace HrisApp.Client.Services.EmpDetails.EmpRateHistoryService
{
    public interface IEmpRateHistoryService
    {
        List<Emp_RateHistoryT> Emp_RateHistoryTs { get; set; }
        Task<List<Emp_RateHistoryT>> GetHistoryList(int empid);
        Task<Emp_RateHistoryT> GetLastHistory(int empid);
        Task<Emp_RateHistoryT> GetLastHistoryWithoutDateEnded(int empid);
        Task GetAllHistory();
        Task<Emp_RateHistoryT> GetSingleHistory(int id);
        Task<Emp_RateHistoryT> GetSingleLastHistory(int id);
        Task<string> CreateHistory(Emp_RateHistoryT history);
        Task UpdateHistory(Emp_RateHistoryT history);
        Task DeleteHistory(int id);
    }
}
