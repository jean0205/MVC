using System;
using System.Web.Mvc;
using MVC.Models;
using System.Linq;


namespace MVC.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string user, string password)
        {
            try
            {
                using (WebMVCEntities db = new WebMVCEntities())
                {
                    var lst = from d in db.Users
                              where d.NisNumber == user && d.Password == password && d.Cstate.Id==1
                              select d;
                    if (lst.Any())
                    {
                        Session["User"] = lst.First();
                        return Content("1");
                    }
                    else
                    {
                        return Content("Usuario Invalido");
                    }
                }
              
            }
            catch (Exception ex)
            {

                return Content("Error"+ ex.Message);
            }

        }
    }
}