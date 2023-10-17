using Microsoft.AspNetCore.Components.Forms;

namespace HrisApp.Client.Pages.Auth
{
    public partial class RegisterUser : ComponentBase
    {
        UserLoginDto reg = new UserLoginDto();

        bool success;
        string message = string.Empty;
        MudBlazor.Severity _severity;

        private bool showAlert = false;

        async Task HandleRegistration()
        {
            try
            {
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
            }
        }

        public void CloseMe()
        {
            showAlert = false;
        }
        private void OnValidSubmit(EditContext context)
        {
            success = true;
            StateHasChanged();
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
