namespace HrisApp.Client.Services.ApplicantDetails.AppEducService
{
    public interface IAppEducService
    {
        Task<List<App_PrimaryT>> GetExistPrimary(string verifyId, int id);
        Task<List<App_SecondaryT>> GetExistSecondary(string verifyId, int id);
        Task<List<App_SeniorHST>> GetExistSeniorHS(string verifyId, int id);
        Task<List<App_CollegeT>> GetExistCollege(string verifyId, int id);
        Task<List<App_MasteralT>> GetExistMasteral(string verifyId, int id);
        Task<List<App_DoctorateT>> GetExistDoctorate(string verifyId, int id);
        Task<List<App_OtherEducT>> GetExistOtherEduc(string verifyId, int id);

        List<App_PrimaryT> _primary { get; set; }
        Task<List<App_PrimaryT>> GetPrimarylist(string verCode);
        Task<string> CreatePrimary(App_PrimaryT primary);
        Task UpdatePrimary(App_PrimaryT _primaries);
        Task CreateNewupdate(App_PrimaryT _primaries);
        Task DeletePrimary(int id);


        List<App_SecondaryT> _secondary { get; set; }
        Task<List<App_SecondaryT>> GetSecondarylist(string verCode);
        Task<string> CreateSecondary(App_SecondaryT _secondaries);
        Task UpdateSecondary(App_SecondaryT _secondaries);
        Task DeleteSecondary(int id);


        List<App_SeniorHST> _seniors { get; set; }
        Task<List<App_SeniorHST>> GetSeniorHSlist(string verCode);
        Task<string> CreateSeniorHS(App_SeniorHST _shs);
        Task UpdateSeniorHS(App_SeniorHST _shs);
        Task DeleteSHS(int id);


        List<App_CollegeT> _college { get; set; }
        Task<List<App_CollegeT>> GetCollegelist(string verCode);
        Task<string> CreateCollege(App_CollegeT _colleges);
        Task UpdateCollege(App_CollegeT _colleges);
        Task DeleteCollege(int id);


        List<App_MasteralT> _masteral { get; set; }
        Task<List<App_MasteralT>> GetMasterallist(string verCode);
        Task<string> CreateMasteral(App_MasteralT _mas);
        Task UpdateMasteral(App_MasteralT _mas);
        Task DeleteMasteral(int id);


        List<App_DoctorateT> _doctorate { get; set; }
        Task<List<App_DoctorateT>> GetDoctoratelist(string verCode);
        Task<string> CreateDoctorate(App_DoctorateT _doc);
        Task UpdateDoctorate(App_DoctorateT _doc);
        Task DeleteDoctorate(int id);


        List<App_OtherEducT> _other { get; set; }
        Task<List<App_OtherEducT>> GetOtherEduclist(string verCode);
        Task<string> CreateOtherEduc(App_OtherEducT _others);
        Task UpdateOtherEduc(App_OtherEducT _others);
        Task DeleteOtherEduc(int id);
    }
}
