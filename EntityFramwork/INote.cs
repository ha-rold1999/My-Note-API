namespace My_Note_API.EntityFramwork
{
    public interface INote
    {
        string Description { get; set; }
        int Id { get; set; }
        string[] items { get; set; }
        string Title { get; set; }
        string url { get; set; }
    }
}