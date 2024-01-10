namespace HrisApp.Client.Services.ApplicantDetails.AppLicTrainingService
{
    public interface IAppLicenseTrainingService
    {
        List<App_TrainingT> TrainingTs { get; set; }
        Task<List<App_TrainingT>> GetTraininglist(string verCode);
        Task<string> CreateTraining(App_TrainingT train);
        Task UpdateTraining(App_TrainingT train);
        Task DeleteTraining(int id);


        List<App_LicenseT> LicenseTs { get; set; }
        Task<List<App_LicenseT>> GetLicenselist(string verifyCode);
        Task<string> CreateLicense(App_LicenseT _license);
        Task<List<App_LicenseT>> GetExistlicense(string _verifyCode, int id);
        Task UpdateLicense(App_LicenseT license);
        Task DeleteLicense(int id);

        List<App_ProfBackgroundT> App_ProfBackgroundTs { get; set; }
        Task<List<App_ProfBackgroundT>> GetProfBglist(string verCode);
        Task<string> CreateProfBg(App_ProfBackgroundT profbg);
        Task UpdateProfBg(App_ProfBackgroundT profbg);
        Task DeleteProfBg(int id);

        List<App_OtherAwardsT> App_OtherAwardsTs { get; set; }
        Task<List<App_OtherAwardsT>> GetOtherAwardslist(string verCode);
        Task<string> CreateOtherAwards(App_OtherAwardsT profbg);
        Task UpdateOtherAwards(App_OtherAwardsT profbg);
        Task DeleteOtherAwards(int id);


        List<App_SelfDeclarationT> App_SelfDeclarationTs { get; set; }
        Task<string> CreateSelfDeclaration(App_SelfDeclarationT address);
        Task GetSelfDeclaration();
        Task<App_SelfDeclarationT> GetSingleSelfDeclaration(int id);
        Task UpdateSelfDeclaration(App_SelfDeclarationT address);
        Task DeleteSelfDeclaration(int id);
    }
}
