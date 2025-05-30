using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace Mylo.Web.Base
{
    public class BasePage
    {
        [Inject] public IJSRuntime IJSRuntime { get; set; }
        [Inject] public ISnackbar Snackbar { get; set; }
        [Inject] public IDialogService DialogService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }

        [Inject] public IHttpClientFactory httpClientFactory { get; set; }

        [Inject] public ILocalStorageService localStorage { get; set; }

        public BasePage(NavigationManager navigationManager, IJSRuntime jSRuntime,
            ISnackbar snackbar, IDialogService iDialogService, IHttpClientFactory httpClientFactory, ILocalStorageService localStorageService)
        {
            NavigationManager = navigationManager;
            IJSRuntime = jSRuntime;
            Snackbar = snackbar;
            DialogService = iDialogService;
            this.httpClientFactory = httpClientFactory;
            localStorage = localStorageService;
        }

        public void RegisterPage()
        {
            NavigationManager.NavigateTo("/Account/Register");
        }

        public async Task<T> PostApiAsync<T>(string url, object data)
        {
            var httpClient = httpClientFactory.CreateClient("Wasm");
            var response = await httpClient.PostAsJsonAsync(url, data);

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return default;
                }
                var responseData = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(responseData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            else
            {
                Console.WriteLine("Hata oluştu.");
                return default;
            }
        }

        public async Task<T> GetAllApiAsync<T>(string url)
        {
            var httpClient = httpClientFactory.CreateClient("Wasm");

            var token = await localStorage.GetItemAsync<string>("authToken"); // localStorage’dan al
            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(responseData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            else
            {
                Console.WriteLine("Hata oluştu.");
                return default;
            }
        }

        public async Task<T> GetApiAsync<T>(string url)
        {
            var httpClient = httpClientFactory.CreateClient("Wasm");

            var token = await localStorage.GetItemAsync<string>("authToken"); // localStorage’dan al
            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(responseData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            else
            {
                Console.WriteLine("Hata oluştu.");
                return default;
            }
        }

        public async Task<T> DeleteApiAsync<T>(string url, object data)
        {
            var httpClient = httpClientFactory.CreateClient("Wasm");

            var token = await localStorage.GetItemAsync<string>("authToken"); // localStorage’dan al
            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            var response = await httpClient.PostAsJsonAsync(url, data);

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return default;
                }
                var responseData = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(responseData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            else
            {
                Console.WriteLine("Hata oluştu.");
                return default;
            }
        }

        public async Task<T> InsertApiAsync<T>(string url, object data)
        {
            var httpClient = httpClientFactory.CreateClient("Wasm");

            var token = await localStorage.GetItemAsync<string>("authToken"); // localStorage’dan al
            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            var response = await httpClient.PostAsJsonAsync(url, data);

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return default;
                }
                var responseData = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(responseData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            else
            {
                Console.WriteLine("Hata oluştu.");
                return default;
            }
        }
    }
}
