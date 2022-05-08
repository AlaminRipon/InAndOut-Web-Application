using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Item Name")]
        public string Name { get; set; }
        public decimal Cost { get; set; }
    }
}
