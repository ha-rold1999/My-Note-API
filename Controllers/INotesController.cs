using Microsoft.AspNetCore.Mvc;
using My_Note_API.EntityFramwork;

namespace My_Note_API.Controllers
{
    public interface INotesController<T>
    {
        IActionResult AddNote([FromBody] T note);
        IActionResult DeleteNote(int id);
        IActionResult GetAllNotes();
        IActionResult UpdateNote([FromBody] T note);
    }
}