using System;
using System.Configuration;
using System.Web.Mvc;

namespace ReCaptchaFake.Controllers
{
    public class CaptchaController : Controller
    {
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Verify(string privatekey, string remoteip, string challenge, string response)
        {
            // default to web.config setting
            string result = ConfigurationManager.AppSettings["CaptchaResult"];

            // allow override in user-entered response
            if (response.Equals("true", StringComparison.OrdinalIgnoreCase) || response.Equals("false", StringComparison.OrdinalIgnoreCase))
                result = response;

            return Content(result.ToLower() + "\n");
        }
    }
}
