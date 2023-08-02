using Microsoft.AspNetCore.Mvc;
using My_Note_API.EntityFramwork;

namespace My_Note_API.Controllers
{
    public interface IToDoController<T>
    {
        IActionResult AddToDo([FromBody] T toDo);
        IActionResult GetAllToDos();
    }
}