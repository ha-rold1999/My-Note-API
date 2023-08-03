namespace My_Note_API.EntityFramwork.ToDoEntityFramework
{
    public interface IArchive_ToDo
    {
        DateTime Archived_Date { get; set; }
        int Id { get; set; }
        string Description { get; set; }
        DateTime ToDo_Goal { get; set; }
        int ToDo_Id { get; set; }
        int Priority { get; set; }
        int Status { get; set; }
        string Title { get; set; }
    }
}