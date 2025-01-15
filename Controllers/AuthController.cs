using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class AuthController : Controller
    {
        private static readonly List<UserModel> Users = new()
        {
            new UserModel { Username = "admin", Password = "123" },
            new UserModel {Username= "user", Password= "345"}
        };

        // GET: AuthController
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if(user != null)
            {
                HttpContext.Session.SetString("username", user.Username);
                return Redirect("/xxxbloglalisteSooD@arkxxx");
            }
            ViewBag.Message = "Nom d'utilisateur ou mot de passe incorrect";
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
