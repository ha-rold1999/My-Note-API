using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_Note_API.EntityFramwork.ToDoEntityFramework
{
    [Table("update_logger")]
    public class UpDate_Logger<T> : IUpDate_ToDo_Log<T>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("todo")]
        public T ToDo { get; set; }
        [Required]
        [Column("log")]
        public string Log { get; set; }
        [Required]
        [Column("update_date")]
        public DateTime Update_Date { get; set; }
    }
}
