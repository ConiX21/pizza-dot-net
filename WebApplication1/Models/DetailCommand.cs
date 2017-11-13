using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DotNetPizza.Models;

namespace DotNetPizza.Models
{
    public class DetailCommand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DetailCommandID { get; set; }
        public Pizza Pizza { get; set; }
        public Command Command { get; set; }

        [Required]
        public int Qty { get; set; }
        public int PizzaID { get; set; }

        public int CommandID { get; set; }
    }
}