using System;
using System.Web.Mvc;

namespace GreatPlainsGameFestival.Helpers
{
    public static class IsCurrentActionHelper
    {
        public static bool IsCurrentAction(this HtmlHelper<dynamic> helper, string actionName, string controllerName)
        {
            var currentControllerName = (string) helper.ViewContext.RouteData.Values["controller"];
            var currentActionName = (string) helper.ViewContext.RouteData.Values["action"];



            if (currentControllerName.Equals(controllerName, StringComparison.CurrentCultureIgnoreCase))
            {
                if(actionName==string.Empty)
                    return true;
                if(actionName.StartsWith("!") && !currentActionName.Equals(actionName.Substring(1), StringComparison.CurrentCultureIgnoreCase))
                    return true;
                if(currentActionName.Equals(actionName, StringComparison.CurrentCultureIgnoreCase))
                    return true;
            }
            return false;
        }
    }
}