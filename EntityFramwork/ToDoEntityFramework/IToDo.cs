namespace My_Note_API.EntityFramwork.ToDoEntityFramework
{
    public interface IToDo
    {
        string Description { get; set; }
        DateTime Goal { get; set; }
        int Id { get; set; }
        int Priority { get; set; }
        int Status { get; set; }
        string Title { get; set; }
    }
}