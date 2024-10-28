using System.ComponentModel.DataAnnotations;
using static CinemaApp.Common.EntityValidationConstants.Cinema;

namespace CinemaApp.Data.Models
{
    public class Cinema
    {
        public Cinema() 
        {
            this.CinemaId = Guid.NewGuid(); 
            CinemaMovies = new HashSet<CinemaMovie>(); 
        } 

        [Key]
        public Guid CinemaId { get; set; }

        [Required]
        [MinLength(CinemaNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(LocationMinLength)]
        public string Location { get; set; } = null!;

        public virtual ICollection<CinemaMovie> CinemaMovies { get; set; }  

    }

    
}
