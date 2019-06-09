using SIS.MvcFramework.Attributes.Validation;

namespace Panda.App.ViewModels.Users
{
    public class LoginUserInputModel
    {
        private const string ErrorMessage = "Invalid username or password!";

        [RequiredSis(ErrorMessage)]
        public string Username { get; set; }

        [RequiredSis(ErrorMessage)]
        public string Password { get; set; }
    }
}
