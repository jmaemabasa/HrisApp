namespace HrisApp.Client.Services.MasterData.DepartmentService
{
    public interface IDepartmentService
    {
        List<DepartmentT> DepartmentTs { get; set; }

        Task<List<DepartmentT>> GetDeptByDivision(int divisionId);
        Task<List<DepartmentT>> GetDepartmentList();

        Task CreateDepartment(string deptName, int listDropdownId);
        Task GetDepartment();
        Task UpdateDepartment(DepartmentT dept);
    }
}
