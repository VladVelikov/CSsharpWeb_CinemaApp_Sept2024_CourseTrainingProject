using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Web.ViewModels.Watchlist;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Web.Controllers
{
    [Authorize] 
    public class WatchListController(CinemaDbContext context, UserManager<ApplicationUser> userManager) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string? userId = userManager.GetUserId(User)!;
            
            IEnumerable<WatchListViewModel> watchlist = await context
                .ApplicationUsersMovies
                .Include(um => um.Movie)
                .Where(x => x.ApplicationUserId.ToString().ToLower() == userId.ToLower())
                .Select(um => new WatchListViewModel()
                {
                    MovieId = um.MovieId.ToString(),
                    Title = um.Movie.Title,
                    Genre = um.Movie.Genre,
                    ReleaseDate = um.Movie.ReleaseDate.ToShortDateString(),
                    ImageUrl = um.Movie.ImageUrl
                })
                .ToListAsync();

            return View(watchlist);
        }

        [HttpPost]
        public async Task<IActionResult> AddToWatchlist(string movieId)
        {
            Guid movieGuid = Guid.Empty;
            if (!this.IsGuidValid(movieId, ref movieGuid))
            {
                return this.RedirectToAction("Index", "Movie");
            }

            Movie? movie = await context.Movies.FirstOrDefaultAsync(x => x.Id == movieGuid);
            if (movie == null)
            {
                return this.RedirectToAction("Index", "Movie");
            }

            Guid userGuid = Guid.Parse(userManager.GetUserId(User));
            
            bool addedAlready = context.ApplicationUsersMovies
                .Any(e => e.ApplicationUserId == userGuid && e.MovieId == movie.Id);
          
            if (!addedAlready)
            {
                ApplicationUserMovie userMovie = new ApplicationUserMovie() 
                {
                    MovieId = movie.Id,
                    ApplicationUserId = userGuid,
                };  
                await context.ApplicationUsersMovies.AddAsync(userMovie);
                await context.SaveChangesAsync();
            }
            return this.RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromWatchlist(string movieId)
        {
            Guid movieGuid = Guid.Empty;
            if (!this.IsGuidValid(movieId, ref movieGuid))
            {
                return this.RedirectToAction("Index", "Movie");
            }

            Movie? movie = await context.Movies.FirstOrDefaultAsync(x => x.Id == movieGuid);
            if (movie == null)
            {
                return this.RedirectToAction("Index", "Movie");
            }

            ApplicationUserMovie? userMovie = context.ApplicationUsersMovies
                .FirstOrDefault(x=>x.MovieId.ToString().ToLower() == movieId.ToLower() 
                && x.ApplicationUserId.ToString().ToLower() == userManager.GetUserId(User).ToLower());
            if (userMovie != null)
            {
                context.ApplicationUsersMovies.Remove(userMovie);
                await context.SaveChangesAsync();   
            }

            return this.RedirectToAction(nameof(Index));
        }
        
    }
}
