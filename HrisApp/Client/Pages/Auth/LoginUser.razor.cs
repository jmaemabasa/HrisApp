﻿using Microsoft.AspNetCore.Components.Forms;

namespace HrisApp.Client.Pages.Auth
{
    public partial class LoginUser : ComponentBase
    {
        private UserMasterT _log = new UserMasterT();

        //bool _success;
        string _message = string.Empty;
        MudBlazor.Severity _severity;
        private bool _showAlert = false;

        private string _returnUrl = string.Empty;

        protected override void OnInitialized()
        {
            try
            {
                var uri = NavigationManager.ToAbsoluteUri(NavigationManager.Uri);
                if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("returnUrl", out var url))
                {
                    _returnUrl = url;
                }
            }
            catch (Exception ex)
            {
                _showAlert = true;
                _severity = Severity.Error;
                _message = ex.Message.ToString();
                Console.WriteLine(ex.Message.ToString());
            }

        }
        public void CloseMe()
        {
            _showAlert = false;
        }

        private async Task HandleLogin()
        {
            try
            {
                var result = await AuthService.Login(_log);
                if (result.Success)
                {
                    _message = string.Empty;

                    await LocalStorage.SetItemAsync("token", result.Data);
                    await AuthenticationStateProvider.GetAuthenticationStateAsync();

                    _toastService.ShowSuccess("Successfully Login.");
                    await Task.Delay(1500);

                    NavigationManager.NavigateTo("/index");
                    _toastService.ShowSuccess("Successfully Login.");

                }
                else
                {
                    _showAlert = true;
                    _severity = Severity.Error;
                    _message = result.Message;
                    _toastService.ShowError(result.Message);


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                _showAlert = true;
                _severity = Severity.Error;
                _message = ex.Message.ToString();
            }
        }

        bool _isShow;
        InputType _passwordInput = InputType.Password;
        string _passwordInputIcon = Icons.Material.Filled.VisibilityOff;

        void ButtonTestclick()
        {
            if (_isShow)
            {
                _isShow = false;
                _passwordInputIcon = Icons.Material.Filled.VisibilityOff;
                _passwordInput = InputType.Password;
            }
            else
            {
                _isShow = true;
                _passwordInputIcon = Icons.Material.Filled.Visibility;
                _passwordInput = InputType.Text;
            }
        }
        //private void OnValidSubmit(EditContext context)
        //{
        //    _success = true;
        //    StateHasChanged();
        //}
    }
}
