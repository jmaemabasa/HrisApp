using HrisApp.Client.Pages.Dialog.AlertDialogs;
using System.Data;

namespace HrisApp.Client.GlobalService
{
#nullable disable

    public class GlobalConfigService
    {
        private readonly HttpClient httpClient;

        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly IDialogService DialogService;
        private readonly IJSRuntime jsRuntime;

        public GlobalConfigService(AuthenticationStateProvider authenticationStateProvider, HttpClient _httpClient, IDialogService _DialogService, IJSRuntime _jsRuntime)
        {
            _authenticationStateProvider = authenticationStateProvider;
            httpClient = _httpClient;
            DialogService = _DialogService;
            jsRuntime = _jsRuntime;
            OnLoadAuth();
            //OnName();
        }

        private string _username = string.Empty;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
            }
        }

        private string _userrole = string.Empty;

        public string Role
        {
            get => _userrole;
            set
            {
                _userrole = value;
            }
        }

        private string _fullname = string.Empty;

        public string Fullname
        {
            get => _fullname;
            set
            {
                _fullname = value;
            }
        }

        private string _verid = string.Empty;

        public string VerifyId
        {
            get => _verid;
            set
            {
                _verid = value;
            }
        }

        private string _id;

        public string User_Id
        {
            get => _id;
            set
            {
                _id = value;
            }
        }

        private string _usercode = string.Empty;

        public string User_Code
        {
            get => _usercode;
            set
            {
                _usercode = value;
            }
        }

        private string _usercodeid = string.Empty;

        public string User_CodeId
        {
            get => _usercodeid;
            set
            {
                _usercodeid = value;
            }
        }

        private string _userdepartment = string.Empty;

        public string User_Department
        {
            get => _userdepartment;
            set
            {
                _userdepartment = value;
            }
        }

        private async void OnLoadAuth()
        {
            var _authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            User_Id = _authState.User.Claims.FirstOrDefault(a => a.Type == ClaimTypes.Sid)?.Value;
            Username = _authState.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
            Role = _authState.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
            VerifyId = _authState.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.StreetAddress)?.Value;
            Fullname = _authState.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.GivenName)?.Value;
        }

        private async void OnName()
        {
            int conId = Convert.ToInt32(User_Id);
            var returnlist = await httpClient.GetFromJsonAsync<List<EmployeeT>>($"api/Employee/GetEmpName/{User_Id}");

            var returnmodel = returnlist.Where(e => e.Id == conId).FirstOrDefault();

            Fullname = $"{returnmodel.FirstName} {returnmodel.LastName}";
        }

        public string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return char.ToUpper(input[0]) + input[1..];
        }

        public void OpenErrorDialog(string mess)
        {
            var parameters = new DialogParameters<ErrorDialog>();
            parameters.Add(x => x.Mess, mess);

            var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.ExtraSmall };
            DialogService.Show<ErrorDialog>("", parameters, options);
        }

        public void OpenWarningDialog(string mess)
        {
            var parameters = new DialogParameters<WarningDialog>();
            parameters.Add(x => x.Mess, mess);

            var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.ExtraSmall };
            DialogService.Show<WarningDialog>("", parameters, options);
        }

        public async void OpenInNewTab(string url)
        {
            await jsRuntime.InvokeVoidAsync("openInNewTab", url);
        }

        public async void OpenPDFInNewTab(string url)
        {
            await jsRuntime.InvokeAsync<object>("open", url, "_blank");
        }
    }
}