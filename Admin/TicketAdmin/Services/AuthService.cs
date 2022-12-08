using Blazored.LocalStorage;
using TicketFanAdmin.Models.Identity;
using TicketFanAdmin.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace TicketFanAdmin.Services
{
    internal class AuthService : IAuthService
    {
        private readonly HttpClient _client;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;
        private readonly NavigationManager _navigationManager;

        public AuthService(HttpClient httpClient,
                           AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage,
                           NavigationManager navigationManager)
        {
            _client = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
            _navigationManager = navigationManager;
        }

        public async Task<LoginResult> Login(LoginModel loginModel)
        {
            var response = await _client.PostAsJsonAsync("api/Authenticate/Login", loginModel);
            var loginResult = JsonConvert.DeserializeObject<LoginResult>(await response.Content.ReadAsStringAsync());
            if (!response.IsSuccessStatusCode)
            {
                return loginResult;
            }
            await _localStorage.SetItemAsync("authToken", loginResult!.Token);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResult!.Token);

            ((AuthStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginModel.Email);
            return loginResult;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((AuthStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _client.DefaultRequestHeaders.Authorization = null;
        }

        public async Task CheckForExpiry()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            if (user.Identity!.IsAuthenticated)
            {
                var exp = user.Claims.Where(a => a.Type == "exp").Select(c => c.Value).SingleOrDefault();
                var time = int.Parse(exp!);
                var expiredTime = DateTimeOffset.FromUnixTimeSeconds(time).DateTime;
                if (expiredTime < DateTime.UtcNow)
                {
                    await Logout();
                    _navigationManager.NavigateTo("/Login");
                }
            }
        }
    }
    public class LoginResult
    {
        public bool Successful { get; set; }
        public string Error { get; set; }
        public string Token { get; set; }
    }
    public class RegisterResult
    {
        public bool Successful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
