using HrisApp.Shared.Models.Education;
using static MudBlazor.Icons;

namespace HrisApp.Client.Services.EmpDetails.EducationService
{
    public interface IEducationService
    {
        Task<List<PrimaryT>> GetExistPrimary(string verifyId, int id);
        Task<List<SecondaryT>> GetExistSecondary(string verifyId, int id);
        Task<List<SeniorHST>> GetExistSeniorHS(string verifyId, int id);
        Task<List<CollegeT>> GetExistCollege(string verifyId, int id);
        Task<List<MasteralT>> GetExistMasteral(string verifyId, int id);
        Task<List<DoctorateT>> GetExistDoctorate(string verifyId, int id);
        Task<List<OtherEducT>> GetExistOtherEduc(string verifyId, int id);

        List<PrimaryT> _primary { get; set; }
        Task<List<PrimaryT>> GetPrimarylist(string verCode);
        Task<string> CreatePrimary(PrimaryT primary);
        Task UpdatePrimary(PrimaryT _primaries);
        Task CreateNewupdate(PrimaryT _primaries);

        List<SecondaryT> _secondary { get; set; }
        Task<List<SecondaryT>> GetSecondarylist(string verCode);
        Task<string> CreateSecondary(SecondaryT _secondaries);
        Task UpdateSecondary(SecondaryT _secondaries);

        List<SeniorHST> _seniors { get; set; }
        Task<List<SeniorHST>> GetSeniorHSlist(string verCode);
        Task<string> CreateSeniorHS(SeniorHST _shs);
        Task UpdateSeniorHS(SeniorHST _shs);

        List<CollegeT> _college { get; set; }
        Task<List<CollegeT>> GetCollegelist(string verCode);
        Task<string> CreateCollege(CollegeT _colleges);
        Task UpdateCollege(CollegeT _colleges);

        List<MasteralT> _masteral { get; set; }
        Task<List<MasteralT>> GetMasterallist(string verCode);
        Task<string> CreateMasteral(MasteralT _mas);
        Task UpdateMasteral(MasteralT _mas);

        List<DoctorateT> _doctorate { get; set; }
        Task<List<DoctorateT>> GetDoctoratelist(string verCode);
        Task<string> CreateDoctorate(DoctorateT _doc);
        Task UpdateDoctorate(DoctorateT _doc);

        List<OtherEducT> _other { get; set; }
        Task<List<OtherEducT>> GetOtherEduclist(string verCode);
        Task<string> CreateOtherEduc(OtherEducT _others);
        Task UpdateOtherEduc(OtherEducT _others);
    }
}
