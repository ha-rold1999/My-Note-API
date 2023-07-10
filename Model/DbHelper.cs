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

        public List<Code> GetAllCode() 
        {
            var codes = _databaseContext.Codes.ToList();
            return codes;
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

        public Code? AddCode(Code code)
        {
            if (code != null)
            {
                Code? n = new Code();
                n = _databaseContext.Codes.Where(data => data.Id == code.Id).FirstOrDefault();
                if (n != null)
                {
                    n.Title = code.Title;
                    n.Description = code.Description;
                    n.codes = code.codes;
                    n.url = code.url;
                }
                else
                {
                    n = new Code()
                    {
                        Title = code.Title,
                        Description = code.Description,
                        codes = code.codes,
                        url = code.url
                    };
                    _databaseContext.Codes.Add(n);
                }
                _databaseContext.SaveChanges();
                return n;
            }
            return null;
        }

        public Note? DeleteNote(int id) 
        {
            Note? note = _databaseContext.Notes.Where(data => data.Id == id).FirstOrDefault();
            if (note != null)
            {
                _databaseContext.Notes.Remove(note);
                _databaseContext.SaveChanges();
            }

            return note;
        }
        public Code? DeleteCode(int id)
        {
            Code? code = _databaseContext.Codes.Where(data => data.Id == id).FirstOrDefault();
            if (code != null)
            {
                _databaseContext.Codes.Remove(code);
                _databaseContext.SaveChanges();
            }

            return code;
        }

    }
}
