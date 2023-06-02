namespace My_Note_API.Response
{
    public class ResponseHandler
    {
        public static Response GetResult(ResponseEnum type, object? obj) 
        {
            Response response = new Response() { Data = obj};
            if (type == ResponseEnum.Success) 
            {
                response.Code = 200;
                response.Message = "Data Retrieved";
            }
            else 
            {
                response.Code = 404;
                response.Message = "Data Not Found";
            }
            return response;
        }

        public static Response GetExceptionMessage(Exception ex) 
        {
            Response response = new Response();
            response.Code = 400;
            response.Message = ex.Message;

            return response;
        }
    }
}
