using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_Note_API.EntityFramwork.ToDoEntityFramework
{
    public class Archive_ToDo : IArchive_ToDo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int ToDo_Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Priority { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        public DateTime ToDo_Goal { get; set; }
        [Required]
        public DateTime Archived_Date { get; set; }
    }
}
