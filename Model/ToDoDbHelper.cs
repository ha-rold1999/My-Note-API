using AutoMapper;
using Microsoft.EntityFrameworkCore;
using My_Note_API.CustomException;
using My_Note_API.EntityFramwork.ToDoEntityFramework;

namespace My_Note_API.Model
{
    public class ToDoDbHelper<T, T_Archive> : IToDoDbHelper<T, T_Archive> 
        where T : class, IToDo, new()
        where T_Archive : class, IArchive_ToDo, new()
    {
        private readonly TodoDatabaseContext _context;
        private readonly DbSet<T> _dbSet;
        private readonly DbSet<T_Archive> _dbArchiveSet;
        private readonly IMapper _mapper;

        public ToDoDbHelper(TodoDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            _dbArchiveSet = _context.Set<T_Archive>();
            _mapper = mapper;
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
            //ToDo: Create an exception when ToDo is not found
            T? toDo = _dbSet.Find(toDoId) ?? throw new ToDoNotFoundException();

            ArchiveToDo(toDo);

            _dbSet.Remove(toDo);
            _context.SaveChanges();
            return toDo;
        }

        private void ArchiveToDo(T toDo)
        {
            var archiveToDo = _mapper.Map<T_Archive>(toDo);

            _dbArchiveSet.Add(archiveToDo);
        }

        public List<T> GetAllToDo()
        {
            List<T> toDos = _dbSet.ToList();
            return toDos;
        }
    }
}
