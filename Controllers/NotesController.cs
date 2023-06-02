using Microsoft.AspNetCore.Mvc;
using My_Note_API.EntityFramwork;
using My_Note_API.Model;
using My_Note_API.Response;

namespace My_Note_API.Controllers
{
    public class NotesController : Controller
    {
        private readonly DbHelper dbHelper;
        public NotesController(DatabaseContext context)
        {
            dbHelper = new DbHelper(context);
        }

        [HttpGet]
        [Route("api/[controller]/GetAllNotes")]
        public IActionResult GetAllNotes()
        {
            ResponseEnum type = ResponseEnum.Success;
            try 
            {
                IEnumerable<Note> notes = dbHelper.GetAllNote();
                if(!notes.Any()) 
                {
                    type = ResponseEnum.NotFound;
                }
                return Ok(ResponseHandler.GetResult(type, notes));
            }
            catch (Exception ex) 
            {
                return BadRequest(ResponseHandler.GetExceptionMessage(ex)); 
            }
        }

        [HttpPost]
        [Route("api/[controller]/AddNote")]
        public IActionResult AddNote([FromBody]Note note) 
        {
            try
            {
                ResponseEnum type = ResponseEnum.Success;
                Note? n = dbHelper.AddNote(note);
                if(n != null) 
                {
                    return Ok(ResponseHandler.GetResult(type, n));
                }
                else
                {
                    type = ResponseEnum.NotFound;
                    return BadRequest(ResponseHandler.GetResult(type, null));
                }
            }
            catch (Exception ex) 
            {
                return BadRequest(ResponseHandler.GetExceptionMessage(ex));
            }
        }
    }
}
