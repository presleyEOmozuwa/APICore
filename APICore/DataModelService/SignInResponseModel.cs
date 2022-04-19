using System;
namespace APICore.DataModelService
{
    public class SignInResponseModel
    {
        public bool IsAuthenticated { get; set; }
        public bool IsSubscriber { get; set; }
        public bool IsExternalLogger { get; set; }
        public DateTime ExpDate { get; set; }
        public string Message { get; set; }
    }
}
