using RestAPI.Models.Entity;

namespace RestAPI.Repository.IRepository
{
    public class IProyectoRepository : IRepository<ProyectoEntity>
    {
        public void ClearCache()
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateAsync(ProyectoEntity category)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ProyectoEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProyectoEntity> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(ProyectoEntity category)
        {
            throw new NotImplementedException();
        }
    }
}
