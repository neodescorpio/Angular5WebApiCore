using Angular5WebApiCore.Data;
using Angular5WebApiCore.Models.Domain.Locations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Angular5WebApiCore.Service.Locations
{
    public interface ICountryService
    {
        Country Get(string Name = null);
        IEnumerable<Country> GetAll(string Name = null);
        Task<Country> GetAsync(string Name = null);
        Task<IEnumerable<Country>> GetAllAsync(string Name = null);
    }
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork unitofWork;

        public CountryService(IUnitOfWork unitofWork)
        {
            this.unitofWork = unitofWork;
        }

        public Country Get(string Name = null)
        {
            var entity = unitofWork.Countries.Get(d => d.Name.ToLower().Equals(Name.Trim().ToLower()));

            return entity;
        }
        public IEnumerable<Country> GetAll(string Name = null)
        {
            var list = unitofWork.Countries.GetAll(d => d.Name.Equals(Name)).ToList();
            return list;
        }
        public async Task<Country> GetAsync(string Name = null)
        {
            var entity = await unitofWork.Countries.GetAsync(d => d.Name.Equals(Name));
            return entity;
        }

        public async Task<IEnumerable<Country>> GetAllAsync(string Name = null)
        {
            IEnumerable<Country> list;
            if (!Name.HasData())
                list = await unitofWork.Countries.GetAll().ToListAsync();
            else
                list = await unitofWork.Countries.GetAll(d => d.Name.Equals(Name)).ToListAsync();
            return list;
        }
    }
}
