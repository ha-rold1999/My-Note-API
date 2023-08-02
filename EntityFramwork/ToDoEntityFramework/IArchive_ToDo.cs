namespace My_Note_API.EntityFramwork.ToDoEntityFramework
{
    public interface IArchive_ToDo
    {
        DateTime Archived_Date { get; set; }
        int Id { get; set; }
        string ToDo_Description { get; set; }
        DateTime ToDo_Goal { get; set; }
        int ToDo_Id { get; set; }
        int ToDo_Priority { get; set; }
        int ToDo_Status { get; set; }
        string Todo_Title { get; set; }
    }
}