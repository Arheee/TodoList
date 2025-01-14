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
    
        public ActionResult Index()
        {
            var todos = _context.Todos.ToList();

            return View(todos);
        }

        [HttpGet] //formulaire
        public ActionResult Form()
        {
            return View();
        }

        [HttpPost] //ajouter une tache 
        public ActionResult Form(TodoItemModel oform)
        {
            return View(oform);
        }

      
        //Supp une tache
        public ActionResult Delete(int id)
        {
            return View();
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
