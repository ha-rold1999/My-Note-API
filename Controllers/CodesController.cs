using Microsoft.AspNetCore.Mvc;
using My_Note_API.EntityFramwork;
using My_Note_API.Model;
using My_Note_API.Response;

namespace My_Note_API.Controllers
{
    public class CodesController : Controller, INotesController<Code>
    {
        private readonly IDbHelper<Code> _dbHelper;

        public CodesController(IDbHelper<Code> dbHelper)
        {
            _dbHelper = dbHelper;
        }

        [HttpGet]
        [Route("api/[controller]/GetAllNotes")]
        public IActionResult GetAllNotes() 
        {
            ResponseEnum type = ResponseEnum.Success;
            try
            {
                IEnumerable<Code> codes = _dbHelper.GetAllNote();
                if (!codes.Any())
                {
                    type = ResponseEnum.NotFound;
                }
                return Ok(ResponseHandler.GetResult(type, codes));
            }
            catch (Exception ex)
            { 
                return BadRequest(ResponseHandler.GetExceptionMessage(ex));
            }
        }

        [HttpPost]
        [Route("api/[controller]/AddNote")]
        public IActionResult AddNote([FromBody]Code code)
        {
            try
            {
                ResponseEnum type = ResponseEnum.Success;
                Code? n = _dbHelper.AddNote(code);
                if (n != null)
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

        [HttpPut]
        [Route("api/[controller]/UpdateNote")]
        public IActionResult UpdateNote([FromBody]Code code)
        {
            try
            {
                ResponseEnum type = ResponseEnum.Success;
                Code? n = _dbHelper.AddNote(code);
                if (n != null)
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

        [HttpDelete]
        [Route("api/[controller]/DeleteNote/{id}")]
        public IActionResult DeleteNote(int id)
        {
            try
            {
                ResponseEnum type = ResponseEnum.Success;
                Code? note = _dbHelper.DeleteNote(id);
                if (note != null)
                {
                    return Ok(ResponseHandler.GetResult(type, note));
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
