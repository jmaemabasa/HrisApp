namespace HrisApp.Client.Services.EmpDetails.EmpEvaluationService
{
    public interface IForEvalService
    {
        List<Emp_EvaluationT> Emp_EvaluationTs { get; set; }
        Task<List<Emp_EvaluationT>> GetForEvallist(string verCode);
        Task GetForEval();
        Task<Emp_EvaluationT> GetSingleEval(int id);
        Task<string> CreateForEval(Emp_EvaluationT eval);
        Task UpdateForEval(Emp_EvaluationT eval);
    }
}
