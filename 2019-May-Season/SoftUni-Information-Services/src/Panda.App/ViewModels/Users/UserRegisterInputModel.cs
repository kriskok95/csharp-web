using SIS.MvcFramework.Attributes.Validation;

namespace Panda.App.ViewModels.Users
{
    public class UserRegisterInputModel
    {
        private const string InvalidUsernameLengthMessage = "Username must be between 5 and 20 symbols!";

        private const string InvalidPasswordLengthMessage = "Invalid password length!";

        private const string InvalidEmilMessage = "Please enter a valid email Address!";

        [RequiredSis]
        [StringLengthSis(5, 20, InvalidUsernameLengthMessage)]
        public string Username { get; set; }

        [RequiredSis]
        [EmailSis(InvalidEmilMessage)]
        public string Email { get; set; }

        [RequiredSis]
        [PasswordSis(InvalidPasswordLengthMessage)]
        public string Password { get; set; }

        [RequiredSis]
        [PasswordSis(InvalidPasswordLengthMessage)]
        public string ConfirmPassword { get; set; }
    }
}
