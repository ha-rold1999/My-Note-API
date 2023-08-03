namespace My_Note_API.EntityFramwork.ToDoEntityFramework
{
    public interface ICreate_ToDo_Log<T>
    {
        DateTime Date_Id { get; set; }
        int Id { get; set; }
        T ToDo_Id { get; set; }
    }
}