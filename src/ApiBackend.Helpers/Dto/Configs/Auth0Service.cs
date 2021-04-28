namespace ApiBackend.Helpers.Dto.Configs
{
    public class Auth0Service
    {
        public string AuthDomain { get; set; }
        public string Domain { get; set; }
        public string Connection { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Audience { get; set; }
        public string GrantType { get; set; }
    }
}