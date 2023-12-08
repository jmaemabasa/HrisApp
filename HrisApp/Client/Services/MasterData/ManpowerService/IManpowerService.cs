namespace HrisApp.Client.Services.MasterData.ManpowerService
{
    public interface IManpowerService
    {
        List<PosMPInternalT> PosMPInternalTs { get; set; }

        Task<List<PosMPInternalT>> GetInternalList();

        Task<PosMPInternalT> GetSingleInternal(int id);

        Task GetInternal();

        Task CreateInternal(string name, string verid);

        Task UpdateInternal(PosMPInternalT obj);



        List<PosMPExternalT> PosMPExternalTs { get; set; }

        Task<List<PosMPExternalT>> GetExternalList();

        Task<PosMPExternalT> GetSingleExternal(int id);

        Task GetExternal();

        Task CreateExternal(string name, string verid);

        Task UpdateExternal(PosMPExternalT obj);
    }
}
