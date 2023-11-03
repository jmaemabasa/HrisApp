using Blazored.Toast.Services;

namespace HrisApp.Client.Services.TokenService
{
    public class TokensService : ITokensService
    {
#nullable disable
        readonly IToastService _toastService;
        public TokensService(IToastService toast)
        {
            _toastService = toast;
        }
        public async Task ErrorMessage(string _message)
        {
            await Task.Delay(10);
            _toastService.ClearAll();
            _toastService.ShowError(_message);

        }
    }
}
