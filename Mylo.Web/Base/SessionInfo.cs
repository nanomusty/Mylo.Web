using Blazored.LocalStorage;
using Mylo.Web.Enumerations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Mylo.Web.Base
{
    public class SessionInfo
    {
        private readonly ILocalStorageService _localStorage;
        private const string AuthTokenKey = "authToken"; // Token'ı kaydettiğimiz anahtar

        // Constructor ile ILocalStorageService'i enjekte edin
        public SessionInfo(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        // Kullanıcı bilgileri için normal (non-static) özellikler
        public string UserEmail { get; private set; } = string.Empty;
        public Guid UserId { get; private set; } = Guid.Empty;
        public UserType UserType { get; private set; } = UserType.None; // Varsayılan değer
        public PriceTier PriceTier { get; private set; } = PriceTier.None; // Varsayılan değer
        public Guid OrganisationId { get; private set; } = Guid.Empty;
        public string Language { get; private set; } = "en"; // Varsayılan değer

        // Kullanıcının oturum açıp açmadığını kontrol etmek için
        public async Task<bool> IsAuthenticatedAsync()
        {
            if (string.IsNullOrEmpty(UserEmail) || UserId == Guid.Empty)
                return false;

            var token = await _localStorage.GetItemAsync<string>(AuthTokenKey);
            if (string.IsNullOrEmpty(token))
                return false;

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var valid = jwtToken.ValidTo > DateTime.UtcNow;
            return valid;
        }


        /// <summary>
        /// JWT token'ı parse eder ve SessionInfo özelliklerini doldurur.
        /// </summary>
        /// <param name="token">JWT string'i</param>
        public async Task SetSessionFromToken(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                await ClearSession();
                return;
            }

            // "Bearer " varsa atla
            if (token.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                token = token.Substring(7).Trim();
            }

            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                // ÖZEL claim isimlerini kullan!
                UserEmail = jwtToken.Claims.FirstOrDefault(c => c.Type == "UserEmail")?.Value ?? string.Empty;
                UserId = Guid.TryParse(jwtToken.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value, out var id) ? id : Guid.Empty;
                UserType = ParseUserType(jwtToken.Claims.FirstOrDefault(c => c.Type == "UserType")?.Value);
                PriceTier = ParsePriceTier(jwtToken.Claims.FirstOrDefault(c => c.Type == "PriceTier")?.Value);
                OrganisationId = Guid.TryParse(jwtToken.Claims.FirstOrDefault(c => c.Type == "OrganisationId")?.Value, out var orgId) ? orgId : Guid.Empty;
                Language = jwtToken.Claims.FirstOrDefault(c => c.Type == "Language")?.Value ?? "en";

                // LocalStorage kaydet
                await _localStorage.SetItemAsync(AuthTokenKey, token);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Token parse hatası: " + ex.Message);
                await ClearSession();
            }
        }

        /// <summary>
        /// SessionInfo'yu temizler ve localStorage'dan token'ı siler.
        /// </summary>
        public async Task ClearSession()
        {
            UserEmail = string.Empty;
            UserId = Guid.Empty;
            UserType = UserType.None;
            PriceTier = PriceTier.None;
            OrganisationId = Guid.Empty;
            Language = "en";

            await _localStorage.RemoveItemAsync(AuthTokenKey);
        }

        /// <summary>
        /// Uygulama başladığında veya sayfalar yenilendiğinde localStorage'dan token'ı yükler.
        /// </summary>
        public async Task LoadSessionFromLocalStorage()
        {
            var token = await _localStorage.GetItemAsync<string>(AuthTokenKey);
            await SetSessionFromToken(token);
        }

        // Yardımcı metotlar: Claim değerlerini enum'lara dönüştürmek için
        private UserType ParseUserType(string? claimValue)
        {
            if (Enum.TryParse(claimValue, true, out UserType userType))
            {
                return userType;
            }
            return UserType.None; // Varsayılan veya bilinmeyen tip
        }

        private PriceTier ParsePriceTier(string? claimValue)
        {
            if (Enum.TryParse(claimValue, true, out PriceTier priceTier))
            {
                return priceTier;
            }
            return PriceTier.None; // Varsayılan veya bilinmeyen tip
        }
    }
}
