using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_Note_API.EntityFramwork.ToDoEntityFramework
{
    [Table("create_todo_log")]
    public class Create_ToDo_Log<T> : ICreate_ToDo_Log<T> where T : class, IToDo, new()
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("todo_id")]
        public T ToDo_Id { get; set; }
        [Required]
        [Column("date_id")]
        public DateTime Date_Id { get; set; }
    }
}
