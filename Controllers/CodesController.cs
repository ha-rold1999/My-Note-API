using Microsoft.AspNetCore.Mvc;
using My_Note_API.EntityFramwork;
using My_Note_API.Model;
using My_Note_API.Response;

namespace My_Note_API.Controllers
{
    public class CodesController : Controller
    {
        private readonly DbHelper<Code> _dbHelper;

        public CodesController(DatabaseContext context)
        {
            using (_dbHelper = new DbHelper<Code>(context))
            { }
                
        }

        [HttpGet]
        [Route("api/[controller]/GetAllCodes")]
        public IActionResult GetAllCodes() 
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
        [Route("api/[controller]/AddCode")]
        public IActionResult AddCode([FromBody]Code code)
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
        [Route("api/[controller]/UpdateCode")]
        public IActionResult UpdateCode([FromBody]Code code)
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
        [Route("api/[controller]/DeleteCode/{id}")]
        public IActionResult DeleteCode(int id)
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
