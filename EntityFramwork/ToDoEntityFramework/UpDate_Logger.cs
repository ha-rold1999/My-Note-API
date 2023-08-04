using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_Note_API.EntityFramwork.ToDoEntityFramework
{
    public class UpDate_Logger<T> : IUpDate_ToDo_Log<T>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public T ToDo { get; set; }
        [Required]
        public string Log { get; set; }
        [Required]
        public DateTime Update_Date { get; set; }
    }
}
