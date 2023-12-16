using System.Data;

namespace HrisApp.Client.ViewModel
{
    public class DTOEmployeeData
    {
        public DataTable GetEmployeeData(List<EmployeeT> list)
        {
            List<EmployeeT> emp = list;
            DataTable dt = new DataTable();
            dt.Columns.Add("FirstName");
            dt.Columns.Add("LastName");
            dt.Columns.Add("MiddleName");
            dt.Columns.Add("Extension");
            dt.Columns.Add("Height");
            dt.Columns.Add("Weight");
            dt.Columns.Add("Birthdate");
            dt.Columns.Add("Nationality");
            dt.Columns.Add("Gender");
            dt.Columns.Add("CivilStatus");
            dt.Columns.Add("Religion");
            DataRow row1;
            foreach (var item in emp)
            {
                row1 = dt.NewRow();
                row1["EmpName"] = item.FirstName;
                row1["LastName"] = item.LastName;
                row1["MiddleName"] = item.MiddleName;
                row1["Extension"] = item.Extension;
                row1["Height"] = item.Height;
                row1["Weight"] = item.Weight;
                row1["Birthdate"] = item.Birthdate;
                row1["Gender"] = item.Gender?.Name;
                row1["CivilStatus"] = item.CivilStatus?.Name;
                row1["Religion"] = item.Religion?.Name;
                dt.Rows.Add(row1);
            }
            return dt;
        }
    }
}
