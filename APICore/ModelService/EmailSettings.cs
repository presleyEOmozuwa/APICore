using System;
namespace APICore.ModelService
{
    public class EmailSettings
    {
        public string FromEmail { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
