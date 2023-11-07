using Microsoft.AspNetCore.Components.Forms;

namespace HrisApp.Client.Pages.Auth
{
    public partial class RegisterUser : ComponentBase
    {
        UserLoginDto reg = new UserLoginDto();
        private bool _processing = false;

        string message = string.Empty;
        MudBlazor.Severity _severity;
        string roleholder = string.Empty;

        private bool showAlert = false;

        private List<UserRoleT> UserRolesL = new List<UserRoleT>();

        protected override async Task OnInitializedAsync()
        {
            await UserRoleService.GetUserRole();
            UserRolesL = UserRoleService.UserRoleTs;
        }

            async Task HandleRegistration()
        {
            try
            {
                _processing = true;
                var result = await AuthService.Register(reg);

                showAlert = true;
                message = result.Message;

                if (result.Success)
                    _severity = Severity.Success;
                else
                    _severity = Severity.Error;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                message = ex.Message.ToString();
                _processing = false;

            }
        }

        public void CloseMe()
        {
            showAlert = false;
        }

        bool isShow;
        InputType PasswordInput = InputType.Password;
        string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
        InputType CPasswordInput = InputType.Password;
        string CPasswordInputIcon = Icons.Material.Filled.VisibilityOff;

        void ButtonTestclick()
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

        void CButtonTestclick()
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

    }
}
