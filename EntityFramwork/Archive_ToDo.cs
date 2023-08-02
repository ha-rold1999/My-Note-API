using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_Note_API.EntityFramwork
{
    public class Archive_ToDo : IArchive_ToDo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int ToDo_Id { get; set; }
        [Required]
        public string Todo_Title { get; set; }
        [Required]
        public string ToDo_Description { get; set; }
        [Required]
        public int ToDo_Priority { get; set; }
        [Required]
        public int ToDo_Status { get; set; }
        [Required]
        public DateTime ToDo_Goal { get; set; }
        [Required]
        public DateTime Archived_Date { get; set; }
    }
}
