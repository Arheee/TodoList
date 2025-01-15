using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models;

namespace TodoList.Controllers
{
    
    public class TodoItemController : Controller
    {
        private readonly TodoContext _context;
        public TodoItemController(TodoContext context)
        {
            _context = context;
        }

        [Route("xxxbloglalisteSooD@arkxxx")]
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var username = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username)) 
            { 
                return RedirectToAction("Login", "Auth"); 
            }

            var totalItems = _context.Todos.Count();
            //calcul le nombre total de pages avec Ceiling : arrondit un nombre a l'entier supp le plus proche
            var totalPages = (int)Math.Ceiling(totalItems/ (double)pageSize);

            var todos = _context.Todos
                      .Skip((page - 1) * pageSize) 
                      .Take(pageSize)  
                      .ToList();

            
            var oForm = new TodoListViewModel
            {
                Todos = todos,
                CurrentPage = page,
                TotalPages = totalPages,
                PageSize = pageSize
            };

            
            ViewBag.Username = username; 
            return View(oForm);
        }

        [HttpGet] //formulaire
        public ActionResult Form()
        {
            return View();
        }

        [HttpPost] //ajouter une tache 
        public ActionResult Form(TodoItemModel oform)
        {
            if (ModelState.IsValid)
            {
                _context.Todos.Add(oform);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oform);
        }

      
        //Supp une tache
        public ActionResult Delete(int id)
        {
            var todo = _context.Todos.Find(id);
            if (todo != null)
            {
                _context.Todos.Remove(todo);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        // Marquer une tâche comme terminée
        public IActionResult ToggleComplete(int id)
        {
            var todo = _context.Todos.Find(id);
            if (todo != null)
            {
                todo.IsCompleted = !todo.IsCompleted;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
