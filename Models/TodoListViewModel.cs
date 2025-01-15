namespace TodoList.Models
{
    internal class TodoListViewModel
    {
        public List<TodoItemModel> Todos { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
    }
}