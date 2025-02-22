﻿using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TodoList.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }

        public DbSet<TodoItemModel> Todos { get; set; }
    } 
}