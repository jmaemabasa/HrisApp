using Microsoft.AspNetCore.Components.Forms;

namespace HrisApp.Client.Pages.Auth
{
    public partial class LoginUser : ComponentBase
    {
        private UserMasterT log = new UserMasterT();

        bool success;
        string message = string.Empty;
        MudBlazor.Severity _severity;
        private bool showAlert = false;

        private string returnUrl = string.Empty;

        protected override void OnInitialized()
        {
            try
            {
                var uri = NavigationManager.ToAbsoluteUri(NavigationManager.Uri);
                if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("returnUrl", out var url))
                {
                    returnUrl = url;
                }
            }
            catch (Exception ex)
            {
                showAlert = true;
                _severity = Severity.Error;
                message = ex.Message.ToString();
                Console.WriteLine(ex.Message.ToString());
            }

        }
        public void CloseMe()
        {
            showAlert = false;
        }

        private async Task HandleLogin()
        {
            try
            {
                var result = await AuthService.Login(log);
                if (result.Success)
                {
                    message = string.Empty;

                    await LocalStorage.SetItemAsync("token", result.Data);
                    await AuthenticationStateProvider.GetAuthenticationStateAsync();

                    _toastService.ShowSuccess("Successfully Login.");
                    await Task.Delay(1500);

                    NavigationManager.NavigateTo("/index");
                    _toastService.ShowSuccess("Successfully Login.");

                }
                else
                {
                    showAlert = true;
                    _severity = Severity.Error;
                    message = result.Message;
                    _toastService.ShowError(result.Message);


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                showAlert = true;
                _severity = Severity.Error;
                message = ex.Message.ToString();
            }
        }

        bool isShow;
        InputType PasswordInput = InputType.Password;
        string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;

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
        private void OnValidSubmit(EditContext context)
        {
            success = true;
            StateHasChanged();
        }
    }
}
