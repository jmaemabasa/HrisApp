﻿using System.Data;

namespace HrisApp.Client
{
#nullable disable
    public class GlobalConfigService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        public GlobalConfigService(AuthenticationStateProvider authenticationStateProvider)
        {
            _authenticationStateProvider = authenticationStateProvider;
            OnLoadAuth();
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
            User_Id = _authState.User.Claims.FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value;
            Username = _authState.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
            Role = _authState.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
            Fullname = _authState.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.GivenName)?.Value;
            //Fullname = _authState.User.Claims.FirstOrDefault(z => z.Type == ClaimTypes.NameIdentifier)?.Value;
            //User_Code = _authState.User.Claims.FirstOrDefault(b => b.Type == ClaimTypes.Sid)?.Value;
            //User_CodeId = _authState.User.Claims.FirstOrDefault(b => b.Type == ClaimTypes.Rsa)?.Value;
            //User_Department = _authState.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimaryGroupSid)?.Value;
        }
    }
}