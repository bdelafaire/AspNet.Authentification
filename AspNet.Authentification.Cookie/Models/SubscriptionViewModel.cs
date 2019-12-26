using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet.Authentification.Cookie.Models
{
    public class SubscriptionViewModel
    {
        [Required]
        [Display(Name = "Adresse email")]
        public string Email { get; set; }

        [Display(Name = "Nom de famille")]
        public string FistName { get; set; }

        [Display(Name = "Prénom")]
        public string LastName { get; set; }

        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Age")]
        public int Age { get; set; }

        [Display(Name = "Votre Rôle")]
        public string RoleSelected { get; set; }

        public List<SelectListItem> Roles { get; } = Role.Roles
            .Select(role => new SelectListItem { Value = role, Text = role })
            .ToList();
    }
}
