using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_Note_API.EntityFramwork.ToDoEntityFramework
{
    [Table("archive_todo")]
    public class Archive_ToDo : IArchive_ToDo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("todo_id")]
        public int ToDo_Id { get; set; }
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
        [Column("todo_goal")]
        public DateTime ToDo_Goal { get; set; }
        [Required]
        [Column("archive_date")]
        public DateTime Archived_Date { get; set; }
    }
}
