using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Double.Context;
using Web_Double.Models;

namespace Web_Double.Controllers
{
    public class HomeController : Controller
    {
        DatabaseIO db = new DatabaseIO();
        public ActionResult Index()
        {
            List<Tshirt> list = db.GetTshirt();
            List<PoloShirt> poloShirts = db.GetPoloShirts();
            var viewModel = new DataModel
            {
                Tshirts = list,
                PoloShirts = poloShirts
            };
            return View(viewModel);
        }

        public ActionResult Details(string type, int id)
        {
            var viewModel = new ProductDetailViewModel();
            List<Shirt> shirts = db.GetShirts();
            //List<User> users = db.GetUser();
            int userId = Session["UserId"] != null ? (int)Session["UserId"] : 0;

            ViewBag.UserId = userId;
            if (type == "Tshirt")
            {
                viewModel.Product = db.GetAllTshirt().FirstOrDefault(p => p.id == id);
            }
            else if (type == "PoloShirt")
            {
                viewModel.Product = db.GetAllPoloshirt().FirstOrDefault(p => p.id == id);
            }
            else if (type == "Aokhoac")
            {
                viewModel.Product = db.GetAokhoacs().FirstOrDefault(p => p.id == id);
            }
            else if (type == "Somi")
            {
                viewModel.Product = db.GetSomis().FirstOrDefault(p => p.id == id);
            }
            else if (type == "Hoodee")
            {
                viewModel.Product = db.GetHoodees().FirstOrDefault(p => p.id == id);
            }
            else if (type == "Quan")
            {
                viewModel.Product = db.GetQuans().FirstOrDefault(p => p.id == id);
            }
            else if (type == "Phukien")
            {
                viewModel.Product = db.GetPhukiens().FirstOrDefault(p => p.id == id);
            }
            else
            {
                return HttpNotFound();
            }

            if (viewModel.Product == null)
            {
                return HttpNotFound();
            }

            return View(viewModel);
        }

        public ActionResult AllProduct()
        {
            List<Tshirt> list = db.GetAllTshirt();
            List<PoloShirt> poloShirts = db.GetAllPoloshirt();
            List<Aokhoac> aokhoacs = db.GetAokhoacs();
            List<Quan> quans = db.GetQuans();
            List<Hoodee> hoodees = db.GetHoodees();
            List<Phukien> phukiens = db.GetPhukiens();
            List<Somi> somis = db.GetSomis();
            var viewModel = new DataModel
            {
                Tshirts = list,
                PoloShirts = poloShirts,
                Aokhoacs = aokhoacs,
                Quans = quans,
                Hoodees = hoodees,
                Phukiens = phukiens,
                Somis = somis
            };
            return View(viewModel);
        }
        public ActionResult Cart()
        {
            int userId = Session["UserId"] != null ? (int)Session["UserId"] : 0;

            if(userId != 0)
            {
                ViewBag.UserId = userId;
            }
            else
            {
                return RedirectToAction("Login", "Account"); // Chuyển hướng đến trang đăng nhập
            }
            return View();
        }
    }

}