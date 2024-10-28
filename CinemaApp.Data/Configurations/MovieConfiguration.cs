using CinemaApp.Common;
using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static CinemaApp.Common.EntityValidationConstants.Movie;
using static CinemaApp.Common.ApplicationConstants;

namespace CinemaApp.Data.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            // fluent API down here
            builder.HasKey(x => x.Id);
            builder.Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(TitleMaxLength);

            builder.Property(m => m.Genre)
                .IsRequired()
                .HasMaxLength(GenreMaxLength);

            builder.Property(m => m.ReleaseDate)
                .IsRequired();

            builder.Property(m => m.Director)
                .IsRequired()
                .HasMaxLength(DirectorNameMaxLength);
            builder.Property (m => m.Description)
                .IsRequired()   
                .HasMaxLength(DescriptionMaxLength);
            builder.Property(m => m.ImageUrl)
                   .IsRequired(false)
                   .HasMaxLength(MovieImageUrlMaxLength)
                   .HasDefaultValue(NoImageUrl);

            // here is how to seed the  DB with the fluent API
            builder.HasData(SeedMovies());

        }

        private List<Movie> SeedMovies()
        {
            List<Movie> movies = new List<Movie>()
            {
                new Movie()
                {
                    Title = "Joker",
                    Genre = "Horror",
                    ReleaseDate = DateTime.Now,
                    Director = "SomeDirector1",
                    Duration =120,
                    Description = "Thats a very stupid movie indeed!!!"
                },
                new Movie()
                {
                    Title = "FinalDestination",
                    Genre = "Horror",
                    ReleaseDate = new DateTime(2012-12-12),
                    Director = "Someone2",
                    Duration = 90,
                    Description = "Something about friends and death evading stuff"
                }

            }; 
            return movies;  
        }


    }
}
