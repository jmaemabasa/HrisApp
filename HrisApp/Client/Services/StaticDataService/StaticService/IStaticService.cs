namespace HrisApp.Client.Services.StaticDataService.StaticService
{
    public interface IStaticService
    {
        List<StatusT> StatusTs { get; set; }
        List<EmploymentStatusT> EmploymentStatusTs { get; set; }
        List<EmerRelationshipT> EmerRelationshipTs { get; set; }
        List<GenderT> GenderTs { get; set; }
        List<CivilStatusT> CivilStatusTs { get; set; }
        List<ReligionT> ReligionTs { get; set; }
        List<InactiveStatusT> InactiveStatusTs { get; set; }
        List<RateTypeT> RateTypeTs { get; set; }
        List<CashBondT> CashBondTs { get; set; }
        List<RestDayT> RestDayTs { get; set; }

        Task GetStatusList();
        Task GetEmploymentStatusList();
        Task GetEmerRelationshipList();
        Task GetGenderList();
        Task GetCivilStatusList();
        Task GetReligionList();
        Task GetInactiveStatusList();
        Task GetRateType();
        Task GetCashbond();
        Task GetRestDay();
    }
}
