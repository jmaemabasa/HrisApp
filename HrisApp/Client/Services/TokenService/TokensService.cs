namespace HrisApp.Client.Services.TokenService
{
    public class TokensService : ITokensService
    {
#nullable disable
        readonly ISnackbar _snackBar;
        public TokensService(ISnackbar snackbar)
        {
            _snackBar = snackbar;
        }
        public async Task ErrorMessage(string _message)
        {
            await Task.Delay(10);
            var _position = Defaults.Classes.Position.TopCenter;
            _snackBar.Clear();
            _snackBar.Configuration.PositionClass = _position;
            _snackBar.Add(_message, Severity.Error, config => { config.Icon = Icons.Filled.Description; });

        }
    }
}
