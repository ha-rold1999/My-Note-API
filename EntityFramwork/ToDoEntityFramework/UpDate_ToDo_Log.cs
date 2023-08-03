using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_Note_API.EntityFramwork.ToDoEntityFramework
{
    public class UpDate_ToDo_Log<T> : IUpDate_ToDo_Log<T>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public T ToDo { get; set; }
        [Required]
        public string Log { get; set; }
        [Required]
        public DateTime Update_Date { get; set; }
    }
}
