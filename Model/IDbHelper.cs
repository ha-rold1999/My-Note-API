using My_Note_API.EntityFramwork;

namespace My_Note_API.Model
{
    public interface IDbHelper<T> where T : class, INote, new()
    {
        T? AddNote(T note);
        T? DeleteNote(int id);
        List<T> GetAllNote();
    }
}