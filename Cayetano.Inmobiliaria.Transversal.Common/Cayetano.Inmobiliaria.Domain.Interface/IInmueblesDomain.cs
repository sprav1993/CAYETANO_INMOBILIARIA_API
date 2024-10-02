using Cayetano.Inmobiliaria.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cayetano.Inmobiliaria.Domain.Interface
{
    public interface IInmueblesDomain
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
