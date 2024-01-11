using Microsoft.AspNetCore.Components;

namespace HrisApp.Client.Pages.Applicant
{
    public partial class Applicants : ComponentBase
    {
        public readonly string _infoFormat = "{first_item}-{last_item} of {all_items}";
        public string _searchString1 = "";

        public List<ApplicantT> _applicantList = new();
        public ApplicantT _selectedItem1 = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await Task.Delay(1);
                StateService.OnChange += OnStateChanged;
                await LoadList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        private async Task LoadList()
        {
            await AppService.GetApplicant();
            StateService.SetState("ApplicantList", AppService.ApplicantTs);
        }

        private void OnStateChanged()
        {
            // Handle state changes, e.g., update the areaList
            _applicantList = StateService.GetState<List<ApplicantT>>("ApplicantList");
            StateHasChanged();
        }



        #region FUNCTIONS
        public void ShowApplicant(int id) => _navigationManager.NavigateTo($"/applicant/show/{id}");


        //LOADING
        public bool _isVisible;
        public async void OpenOverlay()
        {
            _isVisible = false;
            await Task.Delay(2000);
            _isVisible = true;
            StateHasChanged();
        }
        #endregion

        #region TABLE VARIABLES
        public bool FilterFunc1(ApplicantT emp) => FilterFunc(emp, _searchString1);

        private static bool FilterFunc(ApplicantT emp, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if ((emp.App_FirstName + " " + emp.App_LastName).Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (emp.App_FirstName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (emp.App_MiddleName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (emp.App_LastName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            //if (emp.DateHired.ToString("MM/dd/yyyy").Contains(searchString, StringComparison.OrdinalIgnoreCase))
            //    return true;

            return false;
        }
        #endregion
    }
}
