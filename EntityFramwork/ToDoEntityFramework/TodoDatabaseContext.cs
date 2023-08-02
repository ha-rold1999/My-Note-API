﻿using Microsoft.EntityFrameworkCore;

namespace My_Note_API.EntityFramwork.ToDoEntityFramework
{
    public class TodoDatabaseContext : DbContext
    {
        public TodoDatabaseContext(DbContextOptions<TodoDatabaseContext> options): base(options)
        {}
        DbSet<ToDo> ToDos { get; set; }
        DbSet<Archive_ToDo> Archive_ToDos { get; set; }
    }
}