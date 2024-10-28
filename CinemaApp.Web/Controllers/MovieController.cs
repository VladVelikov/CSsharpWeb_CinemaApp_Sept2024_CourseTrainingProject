using CinemaApp.Common;
using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Web.ViewModels.Cinema;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static CinemaApp.Common.EntityValidationConstants.Movie;

namespace CinemaApp.Web.Controllers
{
    public class MovieController(CinemaDbContext context) : BaseController
    {
        //private readonly CinemaDbContext context;

        //public MovieController(CinemaDbContext context)
        //{
        //    this.context = context; 
        //}

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Movie> allMovies = await context.Movies.ToListAsync();
            return View(allMovies);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]    /// movi controlera ve4e priema AddMoviInputModela koito e validiran i sa dopisani spanovete ?!?!?
        public async Task<IActionResult> Create(AddMovieInputModel inputModel)
        {
            // TODO:  Add form model + validation
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);  // ako ne e verno vru6ta su6tata forma sus gre6kite ha ahha + model errors
            }

            bool isReleaseDateValid = DateTime.TryParseExact(inputModel.ReleaseDate, ReleaseDateFormat,
                CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime ReleaseDate);
            if (!isReleaseDateValid)
            {
                this.ModelState.AddModelError(nameof(inputModel.ReleaseDate), $"Release date must be in the following format: {ReleaseDateFormat}");
                return this.View(inputModel);
            }

            Movie movie = new Movie()
            {
                Title = inputModel.Title,
                Genre = inputModel.Genre,
                ReleaseDate = ReleaseDate,
                Director = inputModel.Director, 
                Duration = inputModel.Duration,
                Description = inputModel.Description,
                ImageUrl = inputModel.ImageUrl
            };

            await context.Movies.AddAsync(movie);
            await context.SaveChangesAsync();
            return this.RedirectToAction(nameof(Index));  
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            bool isValid = Guid.TryParse(id, out Guid movieId);

            if (isValid)
            {
                Movie? myMovie = await context.Movies.FirstOrDefaultAsync(x => x.Id == movieId);
                if (myMovie != null)
                {
                    return this.View(myMovie);
                }
                return this.RedirectToAction(nameof(Index));
            }
            return this.RedirectToAction(nameof(Index));

        }


        [HttpGet]
        public async Task<IActionResult> AddToProgram(string? id)
        {
            Guid moviGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref moviGuid);
            if (!isGuidValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            Movie? movie = await context
                .Movies
                .FirstOrDefaultAsync(m=>m.Id == moviGuid);

            if (movie == null)
            {
                return RedirectToAction(nameof(Index)); 
            }

            AddMovieToCinemaInputModel addMovieToCinemaInputModel = new AddMovieToCinemaInputModel()
            {
                Id = id!,
                MovieTitle = movie.Title,
                Cinemas = await context.Cinemas
                .Include(c => c.CinemaMovies)
                .ThenInclude(cm => cm.Movie)
                .Select(c => new CinemaCheckBoxItemInputModel()
                {
                    Id = c.CinemaId.ToString(),
                    Name = c.Name,
                    Location = c.Location,  
                    IsSelected = c.CinemaMovies
                                       .Any(cm => cm.MovieId == moviGuid && cm.IsDeleted == false)

                })
                .ToArrayAsync()
            };

            return this.View(addMovieToCinemaInputModel);   

        }

        [HttpPost]
        public async Task<IActionResult> AddToProgram(AddMovieToCinemaInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            Guid movieGuid = Guid.Empty;
            bool isValid = this.IsGuidValid(model.Id, ref movieGuid);
            if (!isValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            Movie? movie = await context.Movies.FirstOrDefaultAsync(c => c.Id == movieGuid);

            if (movie == null)
            {
                return this.RedirectToAction(nameof(Index));
            }

           

            foreach (CinemaCheckBoxItemInputModel cinemaInputModel 
                in model.Cinemas)
            {
                if (cinemaInputModel.IsSelected)
                {
                    Guid cinemaGuid = Guid.Empty;
                    bool isCinemaGuidValid = this.IsGuidValid(model.Id, ref cinemaGuid);
                    if (!isCinemaGuidValid)
                    {
                        this.ModelState.AddModelError(string.Empty, "Invalid data entered somahow!");
                        //this.RedirectToAction(nameof(Index));

                        return View(model); // da vurne modela s gre6kata
                    }

                    Cinema? cinema = await context.Cinemas.FirstOrDefaultAsync(c => c.CinemaId.ToString() == cinemaInputModel.Id);
                    if (cinema == null)
                    {
                        this.ModelState.AddModelError(string.Empty, "Invalid data entered somahow!");
                        //this.RedirectToAction(nameof(Index));

                        return View(model); // da vurne modela s gre6kata
                    }

                    CinemaMovie? currentRecord = await context.CinemasMovies
                     .FirstOrDefaultAsync(e => e.MovieId.ToString() == model.Id && e.CinemaId.ToString() == cinemaInputModel.Id);
                    if (currentRecord != null)
                    {
                        currentRecord.IsDeleted = false;
                    }
                    else
                    {
                        currentRecord = new CinemaMovie()
                        {
                            MovieId = Guid.Parse(model.Id),
                            CinemaId = Guid.Parse(cinemaInputModel.Id),
                            IsDeleted = false
                        };
                        await context.CinemasMovies.AddAsync(currentRecord);
                    }



                }
                else 
                {
                    CinemaMovie? cinemaMovieToDelete = await context.CinemasMovies.FirstOrDefaultAsync(cm => 
                                                         cm.CinemaId.ToString() == cinemaInputModel.Id && cm.MovieId.ToString() == model.Id);
                    if (cinemaMovieToDelete != null)
                    {
                        cinemaMovieToDelete.IsDeleted = true;
                        await context.SaveChangesAsync();
                    }
                }
            }

            await context.SaveChangesAsync();
            return this.RedirectToAction(nameof(Index), "Cinema");
        }
    }
}
