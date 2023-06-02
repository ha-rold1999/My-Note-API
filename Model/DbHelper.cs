using My_Note_API.Controllers;
using My_Note_API.EntityFramwork;

namespace My_Note_API.Model
{
    public class DbHelper
    {
        private DatabaseContext _databaseContext;
        public DbHelper(DatabaseContext databaseContext) 
        { 
            _databaseContext = databaseContext; 
        }

        public List<Note> GetAllNote() 
        {
            var notes = _databaseContext.Notes.ToList();
            return notes;        
        }

        public Note? AddNote(Note note) 
        {
            if (note != null)
            {
                Note? n = new Note();
                n = _databaseContext.Notes.Where(data => data.Id==note.Id).FirstOrDefault();
                if (n != null)
                {
                    n.Title = note.Title;
                    n.Description = note.Description;
                    n.steps = note.steps;
                    n.url = note.url;
                }
                else
                {
                    n = new Note()
                    {
                        Title = note.Title,
                        Description = note.Description,
                        steps = note.steps,
                        url = note.url
                    };
                    _databaseContext.Notes.Add(n);
                }
                _databaseContext.SaveChanges();
                return n;
            }
            return null;
        }

    }
}
