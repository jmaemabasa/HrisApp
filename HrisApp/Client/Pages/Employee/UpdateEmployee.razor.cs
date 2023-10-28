using HrisApp.Shared.Models.Employee;

namespace HrisApp.Client.Pages.Employee
{
    public partial class UpdateEmployee : ComponentBase
    {
        [Parameter]
        public int? id { get; set; }


        #region FUNCTIONS / BUTTONS
        private string CalculateAge(DateTime? selectedDate)
        {
            if (selectedDate.HasValue)
            {
                DateTime currentDate = DateTime.Today;
                int age = currentDate.Year - selectedDate.Value.Year;

                if (selectedDate.Value > currentDate.AddYears(-age))
                    age--;

                return age.ToString();
            }

            return string.Empty;
        }

     

        void backbtn()
        {
            NavigationManager.NavigateTo("/employee");
        }
        #endregion
    }
}
