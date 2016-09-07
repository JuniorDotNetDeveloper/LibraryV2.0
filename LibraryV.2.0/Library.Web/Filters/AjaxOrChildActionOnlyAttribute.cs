
namespace Library.Web.Filters
{
    using System;
    using System.Web.Mvc;

    public class AjaxOrChildActionOnlyAttribute : ActionFilterAttribute
    {
        #region Public members

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext == null)
                throw new ArgumentNullException("filterContext");
            if (!((filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest") ||
               (filterContext.IsChildAction)))
                //filterContext.Result = new HttpNotFoundResult();
                throw new AccessViolationException("Access denied!");
        }

        #endregion
    }
}