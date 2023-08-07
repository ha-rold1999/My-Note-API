using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_Note_API.EntityFramwork.ToDoEntityFramework
{
    [Table("todo")]
    public class ToDo : IToDo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("title")]
        public string Title { get; set; }
        [Required]
        [Column("description")]
        public string Description { get; set; }
        [Required]
        [Column("priority")]
        public int Priority { get; set; }
        [Required]
        [Column("status")]
        public int Status { get; set; }
        [Required]
        [Column("goal")]
        public DateTime Goal { get; set; }
    }
}
