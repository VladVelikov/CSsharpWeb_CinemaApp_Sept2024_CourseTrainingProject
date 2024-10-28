using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApp.Data.Configurations
{
    public class CinemaMovieConfiguration : IEntityTypeConfiguration<CinemaMovie>
    {
        public void Configure(EntityTypeBuilder<CinemaMovie> builder)
        {
            builder.HasKey(e => new { e.MovieId, e.CinemaId });

            builder
                .HasOne(m => m.Movie)
                .WithMany(cm => cm.CinemaMovies)
                .HasForeignKey(cm => cm.MovieId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(c => c.Cinema)
                .WithMany(cm => cm.CinemaMovies)
                .HasForeignKey(c => c.CinemaId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .Property(cm => cm.IsDeleted)
                .HasDefaultValue(false);

        }
    }
}
