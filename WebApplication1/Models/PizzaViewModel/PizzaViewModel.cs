using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetPizza.Models.PizzaViewModel
{
    public class PizzaViewModel
    {
        public int PizzaID { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z-0-4]{1}[\ a-z]{1,34}$", ErrorMessage = "N'a pas le bon Format" )]
        [Display(Name = "Nom de la pizza")]
        public string Title { get; set; }

        [RegularExpression(@"^[A-Z]{1}[\-\ \.\,éèàa-zA-Z]+", ErrorMessage = "N'a pas le bon Format")]
        public string Description { get; set; }


        public string Image { get; set; }

        public IFormFile UploadImage { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:C2}")]
        [Display(Name = "Prix")]
        public decimal PriceHT { get; set; }

        
        public decimal PriceTTC() => PriceHT * 1.2m;
    }
}
