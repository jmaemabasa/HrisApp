using HrisApp.Shared.Models.SettingsM;

namespace HrisApp.Client.Services.SettingsS.BioIPService
{
    public interface IBioIPService
    {
        List<BioIPModel> BioIPModels { get; set; }

        Task<List<BioIPModel>> GetObjList();
        Task<List<BioIPModel>> GetAllActivesObj();

        Task<BioIPModel> GetSingleObj(int id);

        Task GetObj();

        Task CreateObj(BioIPModel model);

        Task UpdateObj(BioIPModel model);
    }
}
