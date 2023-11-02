using HrisApp.Client.Pages.Employee;

namespace HrisApp.Client.HelperToken
{
#nullable disable
    public class TokenSetGet
    {
        //Employee
        private static EmployeeT _Employeemodel;
        public static void Set_Employeemodel(EmployeeT _obj)
        {
            _Employeemodel = _obj;
        }

        public static EmployeeT Get_Employeemodel()
        {
            return _Employeemodel;
        }
    }
}
