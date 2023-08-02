using My_Note_API.EntityFramwork.ToDoEntityFramework;

namespace My_Note_API.Model
{
    public interface IToDoDbHelper<T> where T : class, IToDo, new()
    {
        T AddToDo(T todo);
        T? UpdateTodo(T todo);
        T? DeleteToDo(int todotoDoId);
        List<T> GetAllToDo();
    }
}