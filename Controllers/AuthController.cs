using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class AuthController : Controller
    {
       
        private static readonly List<UserModel> Users = new()
        {
            new UserModel { Username = "admin", Password = "adm" },
            new UserModel { Username = "user", Password = "use" }
        };

        // GET: AuthController
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ViewBag.Message = "Veuillez remplir tous les champs.";
                return View();
            }
            var user = Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                HttpContext.Session.SetString("username", user.Username);
                return RedirectToAction("Index", "TodoItems");
                //return RedirectToRoute("/Index");
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
