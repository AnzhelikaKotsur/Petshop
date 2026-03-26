using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopApp.Models
{
    [Table("Users", Schema = "public")]
    public class User
    {
        [Key]
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Username")]
        [Required]
        [MaxLength(255)]
        public string Username { get; set; }

        [Column("PasswordHash")]
        [Required]
        [MaxLength(255)]
        public string PasswordHash { get; set; }

        [Column("Role")]
        [MaxLength(100)]
        public string Role { get; set; }

        [Column("FullName")]
        [MaxLength(500)]
        public string FullName { get; set; }
    }
}
