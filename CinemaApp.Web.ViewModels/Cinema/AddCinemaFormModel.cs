using CinemaApp.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Web.ViewModels.Cinema
{
    public class AddCinemaFormModel
    {
        [Required]
        [MinLength(EntityValidationConstants.Cinema.CinemaNameMinLength)]
        [MaxLength(EntityValidationConstants.Cinema.CinemaNameMaxLength)]
        public string Name { get; set; } = null!;


        [Required]
        [MinLength(EntityValidationConstants.Cinema.LocationMinLength)]
        [MaxLength(EntityValidationConstants.Cinema.LOcationMaxLength)]
        public string Location { get; set; } = null!;   
    }
}
