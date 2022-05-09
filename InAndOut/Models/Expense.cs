using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Expense")]
        [Required]  
        public string Name { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage ="Amount must be greater than 0")]
        public decimal Cost { get; set; }
    }
}
