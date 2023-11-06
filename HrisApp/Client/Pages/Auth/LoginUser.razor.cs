﻿using HrisApp.Client.Global;
using HrisApp.Shared.Models.Dummy;
using Microsoft.AspNetCore.Components.Forms;

namespace HrisApp.Client.Pages.Auth
{
    public partial class LoginUser : ComponentBase
    {
        private readonly UserMasterT _log = new UserMasterT();

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
        private bool _processing = false;

        async Task ProcessSomething()
        {
            _processing = true;
            await Task.Delay(2000);
            _processing = false;
        }
        private async Task HandleLogin()
        {
            try
            {
                _processing = true;
                var result = await AuthService.Login(_log);
                if (result.Success)
                {
                    _message = string.Empty;

                    await LocalStorage.SetItemAsync("token", result.Data);
                    await AuthenticationStateProvider.GetAuthenticationStateAsync();

                    AuditLogsDummy auditLogsDummy = new AuditLogsDummy()
                    {
                        UserId = Convert.ToInt32(GlobalConfigService.User_Id),
                        Action = "Login",
                        TableName = "Login",
                        AdditionalInfo = "Login",
                        RecordID = 0,
                        Date = DateTime.Now
                    };

                    await _dummyGlobal.createAudit(auditLogsDummy);
                    //_toastService.ShowSuccess(auditLogsDummy.AdditionalInfo);

                    _toastService.ShowSuccess("Successfully Login.");
                    await Task.Delay(1500);

                    NavigationManager.NavigateTo("/dashboard");
                    _toastService.ShowSuccess("Successfully Login.");
                    //_toastService.ShowSuccess(auditLogsDummy.AdditionalInfo);


                }
                else
                {
                    _processing = false;
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
