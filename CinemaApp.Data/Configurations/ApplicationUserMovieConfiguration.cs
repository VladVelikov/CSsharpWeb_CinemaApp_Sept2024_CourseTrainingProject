using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Data.Configurations
{
    public class ApplicationUserMovieConfiguration : IEntityTypeConfiguration<ApplicationUserMovie>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserMovie> builder)
        {
            builder
                .HasKey(e => new { e.ApplicationUserId, e.MovieId });
            builder
                .HasOne(um => um.Movie)
                .WithMany(aum => aum.MovieApplicationUsers)
                .HasForeignKey(aum => aum.MovieId);
            builder
                .HasOne(ur => ur.ApplicationUser)
                .WithMany(aum=>aum.ApplicationUsersMovies)
                .HasForeignKey(aum=> aum.ApplicationUserId);    
                
        }
    }
}
