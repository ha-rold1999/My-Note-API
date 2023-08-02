using Microsoft.EntityFrameworkCore;
using My_Note_API.EntityFramwork;

namespace My_Note_API.Model
{
    public class ToDoDbHelper<T> : IToDoDbHelper<T> where T : class, IToDo, new()
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<T> _dbSet;

        public ToDoDbHelper(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public T AddToDo(T todo)
        {
            T newToDo = new T()
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                Priority = todo.Priority,
                Status = todo.Status,
                Goal = todo.Goal
            };
            _dbSet.Add(newToDo);
            _context.SaveChanges();
            return newToDo;
        }

        public T? UpdateTodo(T todo)
        {
            T? updateTodo = _dbSet.Find(todo.Id);

            if (updateTodo == null) return null;

            updateTodo.Title = todo.Title;
            updateTodo.Description = todo.Description;
            updateTodo.Priority = todo.Priority;
            updateTodo.Status = todo.Status;
            updateTodo.Goal = todo.Goal;

            _context.SaveChanges();
            return updateTodo;
        }

        public T? DeleteToDo(int toDoId)
        {
            T? toDo = _dbSet.Find(toDoId);

            if (toDo == null) return null;

            _dbSet.Remove(toDo);
            _context.SaveChanges();
            return toDo;
        }

        public List<T> GetAllToDo()
        {
            List<T> toDos = _dbSet.ToList();
            return toDos;
        }
    }
}
