using CinemaApp.Common;
using System.ComponentModel.DataAnnotations;
using static CinemaApp.Common.EntityValidationConstants.Movie;


namespace CinemaApp.Web.ViewModels.Movie
{
    public class AddMovieInputModel
    {
        public AddMovieInputModel() 
        {
            this.ReleaseDate = DateTime.UtcNow.ToString(ReleaseDateFormat);
        } 

        [Required(ErrorMessage = "Title max length should be observed!!")]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MinLength(GenreMinLength)]
        [MaxLength(GenreMaxLength)]
        public string Genre { get; set; } = null!;


        [Required]
        public string ReleaseDate { get; set; } = null!;

        [Range(DurationMinValue,DurationMaxValue)]
        public int Duration { get; set; }

        [Required]
        [MinLength(DirectorNameMinLength)]
        [MaxLength(DirectorNameMaxLength)]  
        public string Director { get; set; } = null!;

        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [MinLength(MovieImageUrlMinLength)]
        [MaxLength(MovieImageUrlMaxLength)]
        public string? ImageUrl { get; set; }

    }
}
