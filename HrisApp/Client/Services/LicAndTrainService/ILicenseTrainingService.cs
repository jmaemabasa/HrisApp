namespace HrisApp.Client.Services.LicAndTrainService
{
    public interface ILicenseTrainingService
    {
        List<Emp_TrainingT> TrainingTs { get; set; }
        Task<List<Emp_TrainingT>> GetTraininglist(string verCode);
        Task<string> CreateTraining(Emp_TrainingT train);
        Task UpdateTraining(Emp_TrainingT train);
        Task DeleteTraining(int id);


        List<Emp_LicenseT> LicenseTs { get; set; }
        Task<List<Emp_LicenseT>> GetLicenselist(string verifyCode);
        Task<string> CreateLicense(Emp_LicenseT _license);
        Task<List<Emp_LicenseT>> GetExistlicense(string _verifyCode, int id);
        Task UpdateLicense(Emp_LicenseT license);
        Task DeleteLicense(int id);

        List<Emp_ProfBackgroundT> Emp_ProfBackgroundTs { get; set; }
        Task<List<Emp_ProfBackgroundT>> GetProfBglist(string verCode);
        Task<string> CreateProfBg(Emp_ProfBackgroundT profbg);
        Task UpdateProfBg(Emp_ProfBackgroundT profbg);
        Task DeleteProfBg(int id);

    }
}
