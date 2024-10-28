﻿namespace CinemaApp.Data.Models
{
    public class Movie
    {
        public Movie() 
        {
            this.Id = Guid.NewGuid();
        }  
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;
        
        public string Genre { get; set; } = null!;

        public DateTime ReleaseDate { get; set; }   

        public string Director { get; set; } = null!;

        public int Duration { get; set; }

        public string Description { get; set; } = null!;  
        
        public string? ImageUrl { get; set; }
        
        public virtual ICollection<CinemaMovie> CinemaMovies { get; set; } 
               = new HashSet<CinemaMovie>();   

        public virtual ICollection<ApplicationUserMovie> MovieApplicationUsers { get; set; } 
               = new HashSet<ApplicationUserMovie>();    

    }

    public enum Genres 
    {
        Horror,
        ScyFy,
        History,
        Action
    }
}
