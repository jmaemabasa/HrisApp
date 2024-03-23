namespace HrisApp.Client.Pages.Dialog.Auth
{
    public partial class LoginDialog : ComponentBase
    {
        private readonly UserMasterT _log = new();

        //bool _success;
        private string _message = string.Empty;

        private MudBlazor.Severity _severity;
        private bool _showAlert = false;

        private string _returnUrl = string.Empty;

        //SUPER ADMIN
        private const string Adminusername = "Administrator";
        //private const string Adminusername = "11";

        private const string Adminpassword = "1t@dm1n2022";
        //private const string Adminpassword = "11";

        private string MYURL { get; set; } = string.Empty;
        private string OLDURL { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //var currentUrl = window.location.href;

                await LocalStorage.RemoveItemAsync("token");
                await AuthStateProvider.GetAuthenticationStateAsync();

                var uri = NavigationManager.ToAbsoluteUri(NavigationManager.Uri);
                OLDURL = uri.ToString();

                var splitstring = uri.ToString().Split('/');
                var id = splitstring.Last();
                MYURL = id;
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

        private async Task HandleLogin()
        {
            try
            {
                _processing = true;

                if (_log.Password == Adminpassword && _log.Username == Adminusername)
                {
                    NavigationManager.NavigateTo("/usermasterlist");
                }
                else
                {
                    var result = await AuthService.Login(_log);
                    if (result.Success)
                    {
                        _message = string.Empty;

                        await LocalStorage.SetItemAsync("token", result.Data);
                        await AuthStateProvider.GetAuthenticationStateAsync();

                        await Task.Delay(500);

                        //var iduser = GlobalConfigService.Fullname;
                        var iduser = Convert.ToInt32(result.Message);
                        await AuditlogService.CreateLog(iduser, "LOGGED IN", "Site", DateTime.Now);

                        int totalPlantilla = await PositionService.GetTotalPlantilla();
                        await PositionService.CreateTotalPlantilla(totalPlantilla, DateTime.Now);

                        //NavigationManager.NavigateTo($"/main-asset/details/{MYURL}");
                        NavigationManager.NavigateTo($"{OLDURL}",true);

                        _toastService.ShowSuccess("Successfully Login.");
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                _showAlert = true;
                _severity = Severity.Error;
                _message = ex.Message.ToString();
            }
        }

        private bool _isShow;
        private InputType _passwordInput = InputType.Password;
        private string _passwordInputIcon = Icons.Material.Filled.VisibilityOff;

        private void ButtonTestclick()
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
    }
}