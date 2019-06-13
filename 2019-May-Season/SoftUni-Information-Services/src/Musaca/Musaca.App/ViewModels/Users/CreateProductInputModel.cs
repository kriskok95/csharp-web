using SIS.MvcFramework.Attributes.Validation;

namespace Musaca.App.ViewModels.Users
{
    public class CreateProductInputModel
    {
        [RequiredSis]
        public string Name { get; set; }

        [RequiredSis]
        public decimal Price { get; set; }
    }
}
