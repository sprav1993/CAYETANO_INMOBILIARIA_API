using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cayetano.Inmobiliaria.Application.Dto;
using Cayetano.Inmobiliaria.Transversal.Common;
namespace Cayetano.Inmobiliaria.Application.Interface
{
    public interface IInmueblesApplication
    {
        #region Métodos Asíncronos
        Task<Response<bool>> InsertAsync(InmueblesDto inmuebleDto);
        Task<Response<bool>> UpdateAsync(InmueblesDto inmuebleDto);
        Task<Response<bool>> DeleteAsync(string customerId);
        Task<Response<InmueblesDto>> GetAsync(string inmuebleId);
        Task<Response<IEnumerable<InmueblesDto>>> GetAllAsync();
        #endregion
    }
}
