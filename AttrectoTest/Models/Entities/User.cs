using System.ComponentModel.DataAnnotations;

namespace AttrectoTest.Models.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }
        [Required]
        [MaxLength(64)]
        public byte[] Password { get; set; }
    }
}
