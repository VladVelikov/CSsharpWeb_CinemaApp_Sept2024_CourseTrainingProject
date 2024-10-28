using System.ComponentModel.DataAnnotations;
using static CinemaApp.Common.EntityValidationConstants.Cinema;

namespace CinemaApp.Web.ViewModels.Cinema
{
    public class CinemaCheckBoxItemInputModel
    {
        [Required]
        public string Id { get; set; } = null!;

        [Required]
        [MaxLength(CinemaNameMaxLength)]
        [MinLength(CinemaNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(LOcationMaxLength)]
        public string Location { get; set; } = null!;   


        public bool IsSelected {  get; set; }    

    }
}
