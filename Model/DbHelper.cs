using Microsoft.EntityFrameworkCore;
using My_Note_API.EntityFramwork;

namespace My_Note_API.Model
{
    public class DbHelper<T> : IDbHelper<T> where T : class, INote, new()
    {
        private DatabaseContext _databaseContext;
        private readonly DbSet<T> _dbSet;
        public DbHelper(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _dbSet = _databaseContext.Set<T>();
        }

        public List<T> GetAllNote()
        {
            var notes = _dbSet.ToList();
            return notes;
        }

        public T AddNote(T note)
        {
            T? n;
            n = _dbSet.Find(note.Id);
            if (n != null)
            {
                n.Title = note.Title;
                n.Description = note.Description;
                n.items = note.items;
                n.url = note.url;
            }
            else
            {
                n = UpdateNote(note);
            }
            _databaseContext.SaveChanges();
            return n;
        }

        private T UpdateNote(T note)
        {
            T newNote = new T()
            {
                Title = note.Title,
                Description = note.Description,
                items = note.items,
                url = note.url
            };
            _dbSet.Add(newNote);
            return newNote;

        }

        public T? DeleteNote(int id)
        {
            T? note = _dbSet.Find(id);
            if (note != null)
            {
                _dbSet.Remove(note);
                _databaseContext.SaveChanges();
            }

            return note;
        }
    }
}
