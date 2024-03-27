namespace HrisApp.Client.Services.Assets.Consumables.ConsumablesService
{
    public interface IConsumablesService
    {
        List<ConsumablesT> ConsumablesTs { get; set; }

        Task<List<ConsumablesT>> GetObjList();

        Task<ConsumablesT> GetSingleObj(int id);
        Task<ConsumablesT> GetSingleObjByCode(string code);

        Task GetObj();

        Task CreateObj(ConsumablesT model);

        Task UpdateObj(ConsumablesT model);

        Task<int> GetLastCode(int type, int cat, int subcat);
    }
}
