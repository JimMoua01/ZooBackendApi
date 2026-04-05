using Microsoft.EntityFrameworkCore;
using ZooApi.Data;
using ZooApi.Models;

namespace ZooApi.Services
{
    public class ZooService
    {
        private readonly DataContext _dataContext;

        public ZooService(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public async Task<List<Animal>> GetAnimals()
        {
            return await _dataContext.Animals.ToListAsync();
        }


        public async Task<Animal> GetAnimalById(int id)
        {
            return await _dataContext.Animals.FindAsync(id);
        }

        public async Task<Animal> AddAnimal(Animal animal)
        {
            _dataContext.Animals.Add(animal);
            await _dataContext.SaveChangesAsync();
            return animal;
        }

        public async Task<Animal> UpdateAnimal(Animal animal)
        {
            _dataContext.Animals.Update(animal);
            await _dataContext.SaveChangesAsync();
            return animal;
        }

        public async Task<List<Visitor>> GetVisitors()
        {
            return await _dataContext.Visitors.ToListAsync();
        }

        public async Task<Visitor> AddVisitor(Visitor visitor)
        {
            _dataContext.Visitors.Add(visitor);
            await _dataContext.SaveChangesAsync();
            return visitor;
        }

        public async Task UpdateVisitorCount(Visitor visitor)
        {
            _dataContext.Visitors.Update(visitor);
            await _dataContext.SaveChangesAsync();

        }

        public async Task<List<ZooStatus>> GetZooStatus()
        {
            return await _dataContext.ZooStatuses.ToListAsync();
        }

        public async Task AddZooStatus(ZooStatus newStatus)
        {
            _dataContext.ZooStatuses.Add(newStatus);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateZooStatus(ZooStatus newStatus)
        {
            _dataContext.ZooStatuses.Update(newStatus);
            await _dataContext.SaveChangesAsync();
        }
    }
}
