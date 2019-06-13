namespace Musaca.App.ViewModels.Users
{
    using SIS.MvcFramework.Attributes.Validation;

    public class LoginInputModel
    {
        private const string ErrorMessage = "Invalid username or password!";
        private const string UsernameLengthErrorMessage = "Username should be between 5 and 20 symbols";

        [StringLengthSis(5, 20, UsernameLengthErrorMessage)]
        [RequiredSis(ErrorMessage)]
        public string Username { get; set; }

        [RequiredSis(ErrorMessage)]
        public string Password { get; set; }
    }
}
