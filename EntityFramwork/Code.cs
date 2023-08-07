using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_Note_API.EntityFramwork
{
    [Table("code")]
    public class Code : INote
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
        [Column("items")]
        [Required]
        public string[] items { get; set; }
        [Required]
        [Column("url")]
        public string url { get; set; }
    }
}
