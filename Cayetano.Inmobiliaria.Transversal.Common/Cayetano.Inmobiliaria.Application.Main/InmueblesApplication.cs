using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cayetano.Inmobiliaria.Application.Dto;
using Cayetano.Inmobiliaria.Application.Interface;
using Cayetano.Inmobiliaria.Domain.Entity;
using Cayetano.Inmobiliaria.Domain.Interface;
using Cayetano.Inmobiliaria.Transversal.Common;
using AutoMapper;

namespace Cayetano.Inmobiliaria.Application.Main
{
    public class InmueblesApplication:IInmueblesApplication
    {
        private readonly IInmueblesDomain _inmueblesDomain;
        private readonly IMapper _mapper;

        public InmueblesApplication(IInmueblesDomain inmueblesDomain, IMapper mapper)
        {
            _inmueblesDomain = inmueblesDomain;
            _mapper = mapper;
        }

 
        #region Métodos Asíncronos
        public async Task<Response<bool>> InsertAsync(InmueblesDto customerDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Inmuebles>(customerDto);
                response.Data = await _inmueblesDomain.InsertAsync(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<Response<bool>> UpdateAsync(InmueblesDto customerDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Inmuebles>(customerDto);
                response.Data = await _inmueblesDomain.UpdateAsync(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización Exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public async Task<Response<bool>> DeleteAsync(string customerId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _inmueblesDomain.DeleteAsync(customerId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public async Task<Response<InmueblesDto>> GetAsync(string customerId)
        {
            var response = new Response<InmueblesDto>();
            try
            {
                var customer = await _inmueblesDomain.GetAsync(customerId);
                response.Data = _mapper.Map<InmueblesDto>(customer);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public async Task<Response<IEnumerable<InmueblesDto>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<InmueblesDto>>();
            try
            {
                var customer = await _inmueblesDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<InmueblesDto>>(customer);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        #endregion
    }
}
