using System.Diagnostics.Eventing.Reader;
using Microsoft.EntityFrameworkCore;

namespace TodoList.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TodoContext(serviceProvider.GetRequiredService<DbContextOptions<TodoContext>>()))
            {
                if (context.Todos.Any())
                {
                    return;
                }
                context.Todos.AddRange(
                    new TodoItemModel
                    {
                        Title = "faire les courses",
                        Description = "Description",
                        IsCompleted = true
                    },
                    new TodoItemModel 
                    { 
                        Title = "Apprendre ASP.NET Core",
                        Description = "Description",
                        IsCompleted = true 
                    }

                    );
                context.SaveChanges();
            }

        }
    }
}
