using Angular5WebApiCore.Data;
using Angular5WebApiCore.Models.Domain.Locations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular5WebApiCore.Service.Locations
{
    public interface ICityService 
    {
        City Get(string Name);
        IEnumerable<City> GetAll(string Name);
        IEnumerable<City> GetCitiesByStateID(long stateID);

        Task<City> GetAsync(string Name);
        Task<IEnumerable<City>> GetAllAsync(string Name);
        Task<IEnumerable<City>> GetCitiesByStateIDAsync(long stateID);
    }
    internal class CityService : ICityService
    {
        private readonly IUnitOfWork unitofWork;

        public CityService(IUnitOfWork unitofWork)
        {
            this.unitofWork = unitofWork;
        }

        public IEnumerable<City> GetCitiesByStateID(long stateID)
        {
            return unitofWork.Cities.GetAll(d => d.StateID == stateID).ToList();
        }
        public City Get(string Name)
        {
            return unitofWork.Cities.Get(d => d.Name.Equals(Name));
        }
        public IEnumerable<City> GetAll(string Name)
        {
            return unitofWork.Cities.GetAll(d => d.Name.Equals(Name)).ToList();
        }

        public async Task<City> GetAsync(string Name)
        {
            return await unitofWork.Cities.GetAsync(d => d.Name.Equals(Name));
        }
        public async Task<IEnumerable<City>> GetAllAsync(string Name)
        {
            return await unitofWork.Cities.GetAll(d => d.Name.Equals(Name)).ToListAsync();
        }
        public async Task<IEnumerable<City>> GetCitiesByStateIDAsync(long stateID)
        {
            return await unitofWork.Cities.GetAll(d => d.StateID == stateID).ToListAsync();
        }
    }
}
