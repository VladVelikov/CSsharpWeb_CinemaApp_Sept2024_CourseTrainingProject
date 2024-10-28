using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Web.ViewModels.Cinema;
using CinemaApp.Web.ViewModels.Movie;
using CinemaApp.Services.Data.Interfaces;

namespace CinemaApp.Web.Controllers
{
    public class CinemaController : Controller
    {
        private readonly CinemaDbContext dbContext;
        private readonly ICinemaService cinemaService;

        public CinemaController(CinemaDbContext dbContext, ICinemaService _cinemaService)
        {
            this.dbContext = dbContext;
            this.cinemaService = _cinemaService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //IEnumerable<CinemaIndexViewModel> cinemas = await this.dbContext.Cinemas
            //    .Select(c=> new CinemaIndexViewModel() {
            //        Id = c.CinemaId.ToString(),
            //        Name = c.Name,
            //        Location = c.Location
            //    })
            //    .OrderBy(c=>c.Name)
            //    .ToListAsync();

            IEnumerable<CinemaIndexViewModel> cinemas =
                await this.cinemaService.IndexGetAllOrderedByLocationAsync();
            
            return View(cinemas);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddCinemaFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Cinema cinema = new Cinema() { 
                Name = model.Name,
                Location = model.Location
            };   
            await this.dbContext.AddAsync(cinema);
            this.dbContext.SaveChanges();

            return this.RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> Details(string? id)
        {
            // non existing parameter in the URL
            if (String.IsNullOrWhiteSpace(id))
            {
                return this.RedirectToAction(nameof(Index));
            }

            // not a guid in th URL
            bool isGuid = Guid.TryParse(id, out Guid cinemaGuid);
            if (!isGuid)
            {
                return this.RedirectToAction(nameof(Index));
            }


            Cinema? cinema = await this.dbContext
                .Cinemas
                .Include(c => c.CinemaMovies)
                .ThenInclude(cm => cm.Movie)
                .FirstOrDefaultAsync(x => x.CinemaId == cinemaGuid);

            // if non existing guid in the URL
            if (cinema == null)
            {
                return this.RedirectToAction(nameof(Index));
            }

            CinemaDetailsViewModel cinemaDetailsViewModel = new CinemaDetailsViewModel()
            {
                Name = cinema.Name,
                Location = cinema.Location,
                Movies = cinema.CinemaMovies
                .Where(cm=>cm.IsDeleted == false)
                .Select(cm => new CinemaMovieViewModel() 
                {
                    Title = cm.Movie.Title,
                    Duration = cm.Movie.Duration   
                })
                .ToList()
            };

            return this.View(cinemaDetailsViewModel); 
        }

    }
}
