using Angular5WebApiCore.Data;
using Angular5WebApiCore.Models.Domain.Locations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Angular5WebApiCore.Service.Locations
{
    public interface IAreaService 
    {
        Area Get(string Name);
        IEnumerable<Area> GetAll(string Name);
        IEnumerable<Area> GetAllByCity(long cityID);

        Task<Area> GetAsync(string Name);
        Task<IEnumerable<Area>> GetAllAsync(string Name);
        Task<IEnumerable<Area>> GetAllByCityAsync(long cityID);
    }
    internal class AreaService : IAreaService
    {
        private readonly IUnitOfWork unitofWork;

        public AreaService(IUnitOfWork unitofWork)
        {
            this.unitofWork = unitofWork;
        }

        public Area Get(string Name)
        {
            var entity = unitofWork.Areas.Get(d => d.Name.Equals(Name));
            return entity;
        }
        public IEnumerable<Area> GetAll(string Name)
        {
            var entities = unitofWork.Areas.GetAll(d => d.Name.Equals(Name));
            return entities;
        }
        public IEnumerable<Area> GetAllByCity(long cityID)
        {
            var entities = unitofWork.Areas.GetAll(d => d.CityID.Equals(cityID));
            return entities;
        }

        public async Task<Area> GetAsync(string Name)
        {
            var entity = await unitofWork.Areas.GetAsync(d => d.Name.Equals(Name));
            return entity;
        }
        public async Task<IEnumerable<Area>> GetAllAsync(string Name)
        {
            var entities = await unitofWork.Areas.GetAll(d => d.Name.Equals(Name)).ToListAsync();
            return entities;
        }
        public async Task<IEnumerable<Area>> GetAllByCityAsync(long cityID)
        {
            var entities = await unitofWork.Areas.GetAll(d => d.CityID.Equals(cityID)).ToListAsync();
            return entities;
        }
    }
}
