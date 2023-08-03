using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using My_Note_API.CustomException;
using My_Note_API.EntityFramwork.ToDoEntityFramework;
using System.ComponentModel.DataAnnotations;

namespace My_Note_API.Model
{
    public class ToDoDbHelper<T, T_Archive, T_Create_Log, T_Update_Log> : IToDoDbHelper<T, T_Archive> 
        where T : class, IToDo, new()
        where T_Archive : class, IArchive_ToDo, new()
        where T_Create_Log : class, ICreate_ToDo_Log<T>, new()
        where T_Update_Log : class, IUpDate_ToDo_Log<T>, new()
    {
        private readonly TodoDatabaseContext _context;
        private readonly DbSet<T> _dbSet;
        private readonly DbSet<T_Archive> _dbArchiveSet;
        private readonly DbSet<T_Create_Log> _createLog;
        private readonly DbSet<T_Update_Log> _updateLog;
        private readonly IMapper _mapper;

        public ToDoDbHelper(TodoDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            _dbArchiveSet = _context.Set<T_Archive>();
            _createLog = _context.Set<T_Create_Log>();
            _updateLog = _context.Set<T_Update_Log>();
            _mapper = mapper;
        }
        public T AddToDo(T todo)
        {
            isValid(todo);

            _dbSet.Add(todo);
            _context.SaveChanges();

            LogCreatedToDo(todo);

            return todo;
        }

        public T? UpdateTodo(T todo)
        {
            isValid(todo);

            T updateTodo = isExist(todo.Id);

            _mapper.Map(todo, updateTodo);

            LogUpdatedTodo(updateTodo);

            _context.SaveChanges();
            return updateTodo;
        }

        public T? DeleteToDo(int toDoId)
        {
            T? toDo = isExist(toDoId);

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

        private T isExist(int id)
        { 
            return _dbSet.Find(id) ?? throw new ToDoNotFoundException();
        }

        private void isValid(T todo)
        {
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(todo, new ValidationContext(todo), validationResults, validateAllProperties: true);

            if (!isValid) throw new ValidationException();
        }

        private void LogCreatedToDo(T todo)
        {
            T_Create_Log log = new T_Create_Log()
            {
                ToDo_Id = todo,
                Date_Id = DateTime.UtcNow,
            };
            _createLog.Add(log);
            _context.SaveChanges();
        }

        private void LogUpdatedTodo(T updateTodo)
        {
            _context.Attach(updateTodo);
            var entry = _context.Entry(updateTodo);
            string changeSummary = string.Join(", ", entry.Properties
                .Where(p => p.IsModified)
                .Select(p => $"Changed: {p.Metadata.Name} - Old Value: {p.OriginalValue} - New Value: {p.CurrentValue}"));

            T_Update_Log update = new T_Update_Log()
            {
                ToDo = updateTodo,
                Log = changeSummary,
                Update_Date = DateTime.UtcNow
            };
            _updateLog.Add(update);
        }
    }
}
