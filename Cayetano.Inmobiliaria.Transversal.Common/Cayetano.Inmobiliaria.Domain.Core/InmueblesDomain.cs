using Cayetano.Inmobiliaria.Domain.Entity;
using Cayetano.Inmobiliaria.Domain.Interface;
using System.Threading.Tasks;
using System.Collections.Generic;
using Cayetano.Inmobiliaria.Infrastructure.Interface;

namespace Cayetano.Inmobiliaria.Domain.Core
{
    public class InmueblesDomain : IInmueblesDomain
    {
        private readonly IInmueblesRepository _inmueblesRepository;

        public InmueblesDomain(IInmueblesRepository inmueblesRepository)
        {
            _inmueblesRepository = inmueblesRepository;
        }
 
        #region Métodos Asíncronos

        public async Task<bool> InsertAsync(Inmuebles inmuebles)
        {
            return await _inmueblesRepository.InsertAsync(inmuebles);
        }
        public async Task<bool> UpdateAsync(Inmuebles inmuebles)
        {
            return await _inmueblesRepository.UpdateAsync(inmuebles);
        }
        public async Task<bool> DeleteAsync(string customerId)
        {
            return await _inmueblesRepository.DeleteAsync(customerId);
        }
        public async Task<Inmuebles> GetAsync(string customerId)
        {
            return await _inmueblesRepository.GetAsync(customerId);
        }
        public async Task<IEnumerable<Inmuebles>> GetAllAsync()
        {
            return await _inmueblesRepository.GetAllAsync();
        }
        #endregion
    }
}
