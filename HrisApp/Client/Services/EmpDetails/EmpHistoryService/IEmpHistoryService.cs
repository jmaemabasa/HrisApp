namespace HrisApp.Client.Services.EmpDetails.EmpHistoryService
{
    public interface IEmpHistoryService
    {
        List<Emp_PosHistoryT> Emp_PosHistoryTs { get; set; }
        Task<List<Emp_PosHistoryT>> GetEmpHistoryList(string verCode);
        Task<Emp_PosHistoryT> GetEmpLastHistory(string verCode);
        Task GetEmpHistory();
        Task<Emp_PosHistoryT> GetSingleEmpHistory(int id);
        Task<Emp_PosHistoryT> GetSingleLastEmpHistory(int id);
        Task<string> CreateEmpHistory(Emp_PosHistoryT history);
        Task UpdateEmpHistory(Emp_PosHistoryT history);
    }
}
