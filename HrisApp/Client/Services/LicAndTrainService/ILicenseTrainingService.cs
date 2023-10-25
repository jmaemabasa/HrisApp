using HrisApp.Shared.Models.LiscenseAndTraining;
using System.ComponentModel;

namespace HrisApp.Client.Services.LicAndTrainService
{
    public interface ILicenseTrainingService
    {
        List<TrainingT> TrainingTs { get; set; }
        Task<List<TrainingT>> GetTraininglist(string verCode);
        Task<string> CreateTraining(TrainingT train);
        Task UpdateTraining(TrainingT train);

        List<LicenseT> LicenseTs { get; set; }
        Task<List<LicenseT>> GetLicenselist(string verifyCode);
        Task<string> CreateLicense(LicenseT _license);
        Task<List<LicenseT>> GetExistlicense(string _verifyCode, int id);
        Task UpdateLicense(LicenseT license);
    }
}
