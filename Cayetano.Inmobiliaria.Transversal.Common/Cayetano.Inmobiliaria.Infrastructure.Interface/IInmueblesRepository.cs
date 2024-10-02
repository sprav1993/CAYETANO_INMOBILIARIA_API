
using Cayetano.Inmobiliaria.Domain.Entity;
namespace Cayetano.Inmobiliaria.Infrastructure.Interface
{
    public interface IInmueblesRepository
    {

        #region Métodos Asíncronos
        Task<bool> InsertAsync(Inmuebles inmueble);
        Task<bool> UpdateAsync(Inmuebles inmueble);
        Task<bool> DeleteAsync(string inmuebleId);
        Task<Inmuebles> GetAsync(string inmuebleId);
        Task<IEnumerable<Inmuebles>> GetAllAsync();
        #endregion
    }
}
