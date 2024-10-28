using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Interfaces;
using CinemaApp.Services.Data.Interfaces;
using CinemaApp.Services.Mapping;
using CinemaApp.Web.ViewModels.Cinema;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Services.Data
{
    public class CinemaService : ICinemaService
    {
        private IRepository<Cinema, Guid> cinemaRepository;

        public CinemaService(IRepository<Cinema, Guid> _cinemaRepository)
        {
            this.cinemaRepository = _cinemaRepository;
        }


        public Task AddCinemaAsync(AddCinemaFormModel model)
        {
            throw new NotImplementedException();
        }

        public Task<CinemaDetailsViewModel> GetCinemaDetailsByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CinemaIndexViewModel>> IndexGetAllOrderedByLocationAsync()
        {
            IEnumerable<CinemaIndexViewModel> cinemas = await this.cinemaRepository.GetAllAttached()
               //.Select(c => new CinemaIndexViewModel()
               //{
               //    Id = c.CinemaId.ToString(),          /// zakomentirania kod zameniame s automapper 
               //    Name = c.Name,
               //    Location = c.Location
               //})
               .OrderBy(c => c.Name)
               .To<CinemaIndexViewModel>()    ///  <== automapper called here
               .ToListAsync();

            return cinemas; 
        }
    }
}
