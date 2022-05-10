using System.ComponentModel.DataAnnotations;

namespace ApplicationMvc.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; } 
        [Required]
        public string Name { get; set; }
        [Required]
        public string SecondName { get; set; }
        [Required]
        
        public string Description { get; set; }
        [Required]
        [Range(15, 70,ErrorMessage ="Yaşınız 15 ile 70 arasında olmalıdır")]
        public int Age { get; set; }
        public DateTime CreatedDate { get; set; }= DateTime.Now;
    }
}
