using SIS.HTTP.Responses;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes.Http;

namespace Panda.App.Controllers
{
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
