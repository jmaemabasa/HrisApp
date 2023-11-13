namespace HrisApp.Client.Services.ApplicantDetails.ApplicantService
{
    public interface IApplicantService
    {
        List<ApplicantT> ApplicantTs { get; set; }
        Task<List<ApplicantT>> GetApplicantList();
        Task GetApplicant();
        Task<ApplicantT> GetSingleApplicant(int id);
        Task<string> CreateApplicant(ApplicantT applicant);
        Task UpdateApplicant(ApplicantT applicant);
    }
}
