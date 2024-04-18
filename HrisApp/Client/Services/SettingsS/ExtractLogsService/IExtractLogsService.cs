using HrisApp.Shared.Models.SettingsM;

namespace HrisApp.Client.Services.SettingsS.ExtractLogsService
{
    public interface IExtractLogsService
    {
        List<ExtractLogsModel> ExtractLogsModels { get; set; }

        Task<List<ExtractLogsModel>> GetObjList();

        Task<ExtractLogsModel> GetSingleObj(int id);

        Task GetObj();
        Task<int> GetExistExtract(string status);

        Task CreateObj(ExtractLogsModel model);

        Task UpdateObj(ExtractLogsModel model);
    }
}
