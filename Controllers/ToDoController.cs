using Microsoft.AspNetCore.Mvc;
using My_Note_API.CustomException;
using My_Note_API.EntityFramwork.ToDoEntityFramework;
using My_Note_API.Model;
using System.ComponentModel.DataAnnotations;

namespace My_Note_API.Controllers
{
    public class ToDoController : Controller, IToDoController<ToDo>
    {
        private readonly IToDoDbHelper<ToDo, Archive_ToDo> _dbHelper;

        public ToDoController(IToDoDbHelper<ToDo, Archive_ToDo> dbHelper)
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
                return Ok(toDo);
            }
            catch (Exception ex) { return BadRequest($"Something went wrong {ex}"); }
        }

        [HttpDelete]
        [Route("api/[controller]/DeleteToDo/{id}")]
        public IActionResult DeleteToDo(int id)
        {
            try
            {
                _dbHelper.DeleteToDo(id);
                return Ok();
            }
            catch(ToDoNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("api/[controller]/UpdateToDo")]
        public IActionResult UpdateToDo([FromBody] ToDo toDo)
        {
            try
            {
                _dbHelper.UpdateTodo(toDo);
                return Ok();
            }
            catch (ToDoNotFoundException)
            {
                return NotFound();
            }
            catch (ValidationException)
            {
                return BadRequest();
            }
        }
    }
}
