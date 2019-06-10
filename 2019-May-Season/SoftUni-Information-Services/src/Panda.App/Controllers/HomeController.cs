namespace Panda.App.Controllers
{
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes.Http;

    public class HomeController : Controller
    {
        [HttpGet(Url = "/")]
        public IHttpResponse SlashIndex()
        {
            return Index();
        }

        public IHttpResponse Index()
        {
            return this.View();
        }
    }
}
