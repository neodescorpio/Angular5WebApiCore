using Angular5WebApiCore.Data;
using Angular5WebApiCore.Models.Domain.Locations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular5WebApiCore.Service.Locations
{
    public interface IStateService
    {
        State Get(string Name);
        IEnumerable<State> GetAll(string Name);
        IEnumerable<State> GetAllByCountryID(long countryID);

        Task<State> GetAsync(string Name);
        Task<IEnumerable<State>> GetAllAsync(string Name);
        Task<IEnumerable<State>> GetAllByCountryIDAsync(long countryID);
    }
    internal class StateService : IStateService
    {
        private readonly IUnitOfWork unitofWork;

        public StateService(IUnitOfWork unitofWork)
        {
            this.unitofWork = unitofWork;
        }

        public IEnumerable<State> GetByCountryID(long countryID)
        {
            var entity = unitofWork.States.GetAll(d => d.CountryID == countryID).ToList();
            return entity;
        }
        public State Get(string Name)
        {
            var entity = unitofWork.States.Get(d => d.Name.Equals(Name));
            return entity;
        }
        public IEnumerable<State> GetAll(string Name)
        {
            var list = unitofWork.States.GetAll(d => d.Name.Equals(Name)).ToList();
            return list;
        }
        public IEnumerable<State> GetAllByCountryID(long countryID)
        {
            var list = unitofWork.States.GetAll(d => d.CountryID.Equals(countryID)).ToList();
            return list;
        }

        public async Task<IEnumerable<State>> GetByCountryIDAsync(long countryID)
        {
            var list = await unitofWork.States.GetAll(d => d.CountryID == countryID).ToListAsync();
            return list;
        }
        public async Task<State> GetAsync(string Name)
        {
            var entity = await unitofWork.States.GetAsync(d => d.Name.Equals(Name));
            return entity;
        }
        public async Task<IEnumerable<State>> GetAllAsync(string Name)
        {
            var list = await unitofWork.States.GetAll(d => d.Name.Equals(Name)).ToListAsync();
            return list;
        }
        public async Task<IEnumerable<State>> GetAllByCountryIDAsync(long countryID)
        {
            var list = await unitofWork.States.GetAll(d => d.CountryID.Equals(countryID)).ToListAsync();
            return list;
        }
    }
}
