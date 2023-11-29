namespace HrisApp.Client.Services.EmpDetails.EmpEvaluationService
{
    public interface IForEvalService
    {
        List<EmployeeEvaluationT> EmployeeEvaluationTs { get; set; }
        Task<List<EmployeeEvaluationT>> GetForEvallist(string verCode);
        Task GetForEval();
        Task<EmployeeEvaluationT> GetSingleEval(int id);
        Task<string> CreateForEval(EmployeeEvaluationT eval);
        Task UpdateForEval(EmployeeEvaluationT eval);
    }
}
