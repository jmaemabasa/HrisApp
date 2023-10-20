using HrisApp.Shared.Models.Images;

namespace HrisApp.Client.Services.ImageService
{
    public interface IImageService
    {
        List<EmpPictureT> EmpPictureTs { get; }
        Task AttachFile(MultipartFormDataContent formdata, string EmployeeId, int division, int department, string lastname, string verify);
        Task<byte[]> GetImageData(string verifyCode);
        Task<List<DocumentT>> GetDocuImagelist(string verCode);
        Task<List<byte[]>> GetPDFData(string verifyCode, string EmployeeNo);

        Task GetNewPDF(string verifyId, string employeId);

        //Task<List<byte[]>> GetPDFDataList(List<string> verifyCodes);

        //Task<List<DocumentImage>> GetPDFData(string verifyCode, string EmployeeNo);

        List<DocumentT> DocumentTs { get; set; }
        Task AttachedFile(MultipartFormDataContent formdata, string EmployeeId, int division, int department, string lastname, string verify);

        public Task<string> GetAttfileName(string _employeeId, string _verifyCode);
        public Task<byte[]> Getdocumentfileview(string _employeeId, string _verifyCode);

    }
}
