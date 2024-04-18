namespace HrisApp.Client.Pages.User.Settings
{
    public partial class UserSetting : ComponentBase
    {
        [CascadingParameter] private MudDialogInstance? MudDialog { get; set; }

        private UpdateUsernameDTO obj = new();

        private ChangePassDTO cpass = new();

        public bool Cmb_IsUsername { get; set; } = false;
        public bool Cmb_IsPassword { get; set; } = true;

        private string _message = string.Empty;
        private Severity _severity;
        private bool _showAlert = false;

        private void Cancel() => MudDialog?.Cancel();

        public void CloseMe() => _showAlert = false;

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(1);
            _showAlert = false;
            obj = await AuthService.GetSingleObjByEmpId(Convert.ToInt32(GlobalConfigService.User_Id));
        }

        #region Update username

        private async Task UpdateUsername()
        {
            obj.EmployeeId = Convert.ToInt32(GlobalConfigService.User_Id);
            var isUserExists = await AuthService.IsUsernameExist(obj.Username);
            if (isUserExists)
            {
                _showAlert = true;
                _message = "Username already exists.";
                _severity = Severity.Error;
            }
            else
            {
                obj.IsUsernameUpdated = 1;
                await AuthService.UpdateUsername(obj);
                _showAlert = false;

                var id = Convert.ToInt32(GlobalConfigService.User_Id);
                await AuditlogService.CreateLog(id, "UPDATE", "Username", DateTime.Now);


                GlobalConfigService.OpenLoginAgainDialog("Please login again.");
            }
        }

        #endregion Update username

        #region Change PAssowrd

        private async Task ChangePassword()
        {
            try
            {
                var id = Convert.ToInt32(GlobalConfigService.User_Id);
                var res = await AuthService.UpdatePassword(id, cpass.Password, cpass.CurrentPassword);

                if (res.Message.Equals("Successful"))
                {
                    await AuditlogService.CreateLog(id, "UPDATE", "Password", DateTime.Now);
                    _showAlert = true;
                    _message = "Successfully changed";
                    _severity = Severity.Success;

                    _showAlert = false;
                    cpass = new();
                }
                else if (res.Message.Equals("incorrect currentpass"))
                {
                    _showAlert = true;
                    _message = "Current password is incorrect";
                    _severity = Severity.Error;
                }
            }
            catch (Exception ex)
            {
                _toastService.ShowError(ex.Message);
                return;
            }
        }

        public void ClickedPassword()
        {
            Cmb_IsPassword = true;
            Cmb_IsUsername = false;
        }

        public void ClickedUsername()
        {
            Cmb_IsUsername = true;
            Cmb_IsPassword = false;
        }

        private bool isShow;
        private InputType PasswordInput = InputType.Password;
        private string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
        private InputType CPasswordInput = InputType.Password;
        private string CPasswordInputIcon = Icons.Material.Filled.VisibilityOff;

        private void ButtonTestclick()
        {
            if (isShow)
            {
                isShow = false;
                PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
                PasswordInput = InputType.Password;
            }
            else
            {
                isShow = true;
                PasswordInputIcon = Icons.Material.Filled.Visibility;
                PasswordInput = InputType.Text;
            }
        }

        private void CButtonTestclick()
        {
            if (isShow)
            {
                isShow = false;
                CPasswordInputIcon = Icons.Material.Filled.VisibilityOff;
                CPasswordInput = InputType.Password;
            }
            else
            {
                isShow = true;
                CPasswordInputIcon = Icons.Material.Filled.Visibility;
                CPasswordInput = InputType.Text;
            }
        }

        #endregion Change PAssowrd
    }
}