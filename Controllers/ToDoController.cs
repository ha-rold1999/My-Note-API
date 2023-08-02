using Microsoft.AspNetCore.Mvc;
using My_Note_API.EntityFramwork.ToDoEntityFramework;
using My_Note_API.Model;

namespace My_Note_API.Controllers
{
    public class ToDoController : Controller, IToDoController<ToDo>
    {
        private readonly IToDoDbHelper<ToDo> _dbHelper;

        public ToDoController(IToDoDbHelper<ToDo> dbHelper)
        {
            _dbHelper = dbHelper;
        }

        [HttpGet]
        [Route("api/[controller]/GetAllToDos")]
        public IActionResult GetAllToDos()
        {
            try
            {
                IEnumerable<ToDo> toDos = _dbHelper.GetAllToDo();
                return Ok(toDos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Bad API request: {ex}");
            }
        }

        [HttpPost]
        [Route("api/[controller]/AddToDo")]
        public IActionResult AddToDo([FromBody] ToDo toDo)
        {
            try
            {
                _dbHelper.AddToDo(toDo);
                return Ok();
            }
            catch (Exception ex) { return BadRequest($"Something went wrong {ex}"); }

        }
    }
}
