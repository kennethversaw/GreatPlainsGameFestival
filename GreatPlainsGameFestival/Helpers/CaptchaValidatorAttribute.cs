using System.Web.Mvc;
using Microsoft.Web.Helpers;

namespace GreatPlainsGameFestival.Helpers
{
    public class CaptchaValidatorAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool isValid = ReCaptcha.Validate(privateKey: "6LeJ0sASAAAAAMs9p7y2-3HtYkHIC3_IpGkVIXMq");

            filterContext.ActionParameters["captchaValid"] = isValid;

            base.OnActionExecuting(filterContext);
        }
    }
}