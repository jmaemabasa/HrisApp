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


        private static int PendingCount;

        public static void SetPendingCount(int pendingcount)
        {
            PendingCount = pendingcount;
        }
        public static int GetPendingCount()
        {
            return PendingCount;
        }

        
    }
}
