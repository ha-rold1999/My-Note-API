using System.Net;

namespace My_Note_API.CustomException
{
    public class ToDoNotFoundException : Exception
    {
        private const string DEFAULT_EXCEPTION = "ToDo not found";
        public ToDoNotFoundException(): base (DEFAULT_EXCEPTION)
        {}
        public ToDoNotFoundException(string message): base (message)
        {}
        public ToDoNotFoundException(Exception innerException) : base(DEFAULT_EXCEPTION, innerException)
        {}
        public ToDoNotFoundException(string message, Exception innerException):base(message, innerException)
        {}
    }
}
