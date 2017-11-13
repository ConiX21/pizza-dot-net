using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetPizza.Models.ClientViewModel
{
    public class ClientViewModel
    {
        public int ClientID { get; set; }

        [Display(Name = "Nom")]
        public string Lastname { get; set; }

        [Display(Name = "Prénom")]
        public string Firstname { get; set; }

        [Display(Name = "Adresse")]
        public string Address { get; set; }

        [Display(Name = "Code postal")]
        public string ZipCode { get; set; }

        [Display(Name = "Ville")]
        public string City { get; set; }

        [Display(Name = "Numéro de téléphone")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Sexe")]
        public int Gender { get; set; } //O homme 1 femme

        public string GenderClass()
        {
            return Gender == 0 ? "boy" : "girl";
        }
    }
}
