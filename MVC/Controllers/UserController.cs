using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using MVC.Models.TableViewModel;

namespace MVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserTableViewModel> lst = null; 
            using (WebMVCEntities db= new WebMVCEntities())
            {
               lst= (from d in db.Users
                where d.State == 1
                orderby d.NisNumber
                select new UserTableViewModel
                {
                    id = d.Id,
                    userName = d.NisNumber,
                    edad = d.Edad
                }).ToList();

            }

            return View(lst);
        }
    }
}