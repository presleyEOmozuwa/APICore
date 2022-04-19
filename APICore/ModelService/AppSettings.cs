using System;
namespace APICore.ModelService
{
    public class AppSettings
    {
        public string Key { get; set; }
        public string TokenExpiry { get; set; }
        public string ClientId { get; set; }
        public string Issuer { get; set; }
        public bool AllowSiteTokenRefresh { get; set; }
    }
}
