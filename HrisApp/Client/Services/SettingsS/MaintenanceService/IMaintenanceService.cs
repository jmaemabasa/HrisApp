namespace HrisApp.Client.Services.SettingsS.MaintenanceService
{
    public interface IMaintenanceService
    {
        List<MaintenanceT> MaintenanceTs { get; set; }

        Task<List<MaintenanceT>> GetObjList();

        Task<MaintenanceT> GetSingleObj(int id);

        Task GetObj();

        Task CreateObj(MaintenanceT model);

        Task UpdateObj(MaintenanceT model);
        Task<bool> GetIsMaintain();

    }
}
