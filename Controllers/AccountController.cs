using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web_Double.Models;
using Web_Double.Services;

namespace WEB_ONE.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        private readonly Services _userService;

        public AccountController()
        {
            // Giả sử connectionString được lấy từ web.config
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Model1"].ConnectionString;
            _userService = new Services(connectionString);
        }

        // GET: Account/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterUserAsync(model.Username, model.Email, model.Password);
                if (result)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("Username", "Tên người dùng đã tồn tại.");
                    ModelState.AddModelError("Email", "Email người dùng đã tồn tại.");
                }
            }
            return View(model);
        }

        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = await _userService.LoginUserAsync(model.Username, model.Password);
                if (userId.HasValue)
                {
                    // Lưu userId vào session
                    Session["UserId"] = userId.Value;

                    // Đăng nhập thành công, chuyển hướng đến trang chính
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
                }
            }
            return View(model);
        }
    }
}