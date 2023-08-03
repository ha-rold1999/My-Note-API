namespace My_Note_API.EntityFramwork.ToDoEntityFramework
{
    public interface IUpDate_ToDo_Log<T>
    {
        int Id { get; set; }
        T ToDo { get; set; }
        string Log { get; set; }
        DateTime Update_Date { get; set; }
    }
}