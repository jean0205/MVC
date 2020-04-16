using MVC.Controllers;
using MVC.Models;
using System.Web;
using System.Web.Mvc;

namespace MVC.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var oUser = (User)HttpContext.Current.Session["User"];

            if (oUser == null)
            {

                if (filterContext.Controller is AccessController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Access/Index");
                }


            }
            else
            {
                if (filterContext.Controller is AccessController == true)
                {

                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }

            }

            base.OnActionExecuting(filterContext);
            }
        }
    }