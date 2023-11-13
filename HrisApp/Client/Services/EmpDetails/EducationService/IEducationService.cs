namespace HrisApp.Client.Services.EmpDetails.EducationService
{
    public interface IEducationService
    {
        Task<List<Emp_PrimaryT>> GetExistPrimary(string verifyId, int id);
        Task<List<Emp_SecondaryT>> GetExistSecondary(string verifyId, int id);
        Task<List<Emp_SeniorHST>> GetExistSeniorHS(string verifyId, int id);
        Task<List<Emp_CollegeT>> GetExistCollege(string verifyId, int id);
        Task<List<Emp_MasteralT>> GetExistMasteral(string verifyId, int id);
        Task<List<Emp_DoctorateT>> GetExistDoctorate(string verifyId, int id);
        Task<List<Emp_OtherEducT>> GetExistOtherEduc(string verifyId, int id);

        List<Emp_PrimaryT> _primary { get; set; }
        Task<List<Emp_PrimaryT>> GetPrimarylist(string verCode);
        Task<string> CreatePrimary(Emp_PrimaryT primary);
        Task UpdatePrimary(Emp_PrimaryT _primaries);
        Task CreateNewupdate(Emp_PrimaryT _primaries);
        Task DeletePrimary(int id);


        List<Emp_SecondaryT> _secondary { get; set; }
        Task<List<Emp_SecondaryT>> GetSecondarylist(string verCode);
        Task<string> CreateSecondary(Emp_SecondaryT _secondaries);
        Task UpdateSecondary(Emp_SecondaryT _secondaries);
        Task DeleteSecondary(int id);


        List<Emp_SeniorHST> _seniors { get; set; }
        Task<List<Emp_SeniorHST>> GetSeniorHSlist(string verCode);
        Task<string> CreateSeniorHS(Emp_SeniorHST _shs);
        Task UpdateSeniorHS(Emp_SeniorHST _shs);
        Task DeleteSHS(int id);


        List<Emp_CollegeT> _college { get; set; }
        Task<List<Emp_CollegeT>> GetCollegelist(string verCode);
        Task<string> CreateCollege(Emp_CollegeT _colleges);
        Task UpdateCollege(Emp_CollegeT _colleges);
        Task DeleteCollege(int id);


        List<Emp_MasteralT> _masteral { get; set; }
        Task<List<Emp_MasteralT>> GetMasterallist(string verCode);
        Task<string> CreateMasteral(Emp_MasteralT _mas);
        Task UpdateMasteral(Emp_MasteralT _mas);
        Task DeleteMasteral(int id);


        List<Emp_DoctorateT> _doctorate { get; set; }
        Task<List<Emp_DoctorateT>> GetDoctoratelist(string verCode);
        Task<string> CreateDoctorate(Emp_DoctorateT _doc);
        Task UpdateDoctorate(Emp_DoctorateT _doc);
        Task DeleteDoctorate(int id);


        List<Emp_OtherEducT> _other { get; set; }
        Task<List<Emp_OtherEducT>> GetOtherEduclist(string verCode);
        Task<string> CreateOtherEduc(Emp_OtherEducT _others);
        Task UpdateOtherEduc(Emp_OtherEducT _others);
        Task DeleteOtherEduc(int id);

    }
}
