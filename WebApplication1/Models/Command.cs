using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DotNetPizza.Models;

namespace DotNetPizza.Models
{
    public class Command
    {
        public Command()
        {
            DetailCommand = new HashSet<DetailCommand>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommandID { get; set; }
        public DateTime CommandDate { get; set; }
        [NotMapped]
        public Client Client { get; set; }
        public decimal Total { get; set; }
        public virtual ICollection<DetailCommand> DetailCommand { get; set; }
    }
}
