using Newtonsoft.Json;

namespace ConHIS.API.Models
{
    public partial class Login
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("access_token")]
        public string Token { get; set; }
    }


}
