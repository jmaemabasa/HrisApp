using HrisApp.Shared.Models.MasterData;

namespace HrisApp.Client.Services.MasterData.DivisionService
{
    public interface IDivisionService
    {
        List<DivisionT> DivisionTs { get; set; }

        Task<List<DivisionT>> GetDivisionList();

        Task<DivisionT> GetSingleDivision(int id);

        Task GetDivision();

        Task CreateDivision(string divisionName);

        Task UpdateDivision(DivisionT division);
    }
}
