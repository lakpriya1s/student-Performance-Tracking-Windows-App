namespace Student_Performance_Tracking_App
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    public class UserService
    {
        private readonly HttpClient _httpClient;
        private const string ApiBaseAddress = "https://studentperformanceapigateway.azurewebsites.net/api";

        public UserService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> RegisterAsync(string username, string email, string password)
        {
            var registerRequest = new
            {
                Username = username,
                Email = email,
                Password = password
            };

            var response = await _httpClient.PostAsJsonAsync($"{ApiBaseAddress}/register", registerRequest);

            if (response.IsSuccessStatusCode)
            {
                return "Registration successful";
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new ApplicationException($"An error occurred during registration. Details: {errorContent}");
            }
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            var loginRequest = new
            {
                Username = username,
                Password = password
            };

            var response = await _httpClient.PostAsJsonAsync($"{ApiBaseAddress}/login", loginRequest);

            if (response.IsSuccessStatusCode)
            {
                var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
                return loginResponse.Token;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new ApplicationException($"An error occurred during login. Details: {errorContent}");
            }
        }
    }

    public class LoginResponse
    {
        public string Token { get; set; }
    }
}
