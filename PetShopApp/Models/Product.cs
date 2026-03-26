using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopApp.Models
{
    [Table("Products", Schema = "public")]
    public class Product
    {
        [Key]
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Article")]
        [Required]
        [MaxLength(255)]
        [Index(IsUnique = true)]
        public string Article { get; set; }

        [Column("Name")]
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Column("CategoryName")]
        [MaxLength(255)]
        public string CategoryName { get; set; }

        [Column("Unit")]
        [MaxLength(255)]
        public string Unit { get; set; }

        [Column("Price")]
        public decimal? Price { get; set; }

        [Column("Stock")]
        public int Stock { get; set; }
    }
}
