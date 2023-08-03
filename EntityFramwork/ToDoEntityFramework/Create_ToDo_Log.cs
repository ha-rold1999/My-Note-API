using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_Note_API.EntityFramwork.ToDoEntityFramework
{
    public class Create_ToDo_Log<T> : ICreate_ToDo_Log<T> where T : class, IToDo, new()
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public T ToDo_Id { get; set; }
        [Required]
        public DateTime Date_Id { get; set; }
    }
}
