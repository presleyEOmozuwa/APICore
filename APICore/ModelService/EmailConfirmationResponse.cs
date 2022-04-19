using System;
namespace APICore.ModelService
{
    public class EmailConfirmationResponse
    {
        public string Message { get; set; }
        public bool IsEmailConfirmed { get; set; }
    }
}
