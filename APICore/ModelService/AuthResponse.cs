using System;
namespace APICore.ModelService
{
    public class AuthResponse
    {
        public string Token { get; set; }
        public bool IsAuthSuccessful { get; set; }
    }
}
