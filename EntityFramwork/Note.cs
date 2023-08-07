using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_Note_API.EntityFramwork
{
    [Table("note")]
    public class Note : INote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("title")]
        public string Title { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("items")]
        public string[] items { get; set; }
        [Required]
        [Column("url")]
        public string url { get; set; }
    }
}
