namespace HrisApp.Client.Services.Assets.Consumables.ConsTransactionService
{
    public interface IConsTransactionService
    {
        List<Cons_TransactionT> Cons_TransactionTs { get; set; }

        Task<List<Cons_TransactionT>> GetObjList();

        Task<Cons_TransactionT> GetSingleObj(int id);
        Task<Cons_TransactionT> GetSingleObjByCode(string code);

        Task GetObj();

        Task CreateObj(Cons_TransactionT model);

        Task UpdateObj(Cons_TransactionT model);

        Task<int> GetLastCode();

        Task<List<EmployeeT>> GetTopIssuedEmployees(int consID);
    }
}
