using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cayetano.Inmobiliaria.Application.Dto;
using Cayetano.Inmobiliaria.Application.Interface;

namespace Cayetano.Inmobiliaria.Services.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InmuebleController : ControllerBase
    {
        private readonly IInmueblesApplication _inmueblesApplication;
        public InmuebleController(IInmueblesApplication inmueblesApplication)
        {
            _inmueblesApplication = inmueblesApplication;
        }

        #region Métodos Asincronos
        [Authorize]
        [HttpPost("async")]
        public async Task<IActionResult> InsertAsync([FromBody] InmueblesDto inmueblesDto)
        {
            if (inmueblesDto == null)
            {
                return BadRequest();
            }
            var response = await _inmueblesApplication.InsertAsync(inmueblesDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        [Authorize]
        [HttpPut("async")]
        public async Task<IActionResult> UpdateAsync([FromBody] InmueblesDto inmueblesDto)
        {
            if (inmueblesDto == null)
            {
                return BadRequest();
            }
            var response = await _inmueblesApplication.UpdateAsync(inmueblesDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [Authorize]
        [HttpDelete("async/{InmuebleId}")]

        //[HttpDelete("{InmuebleId}")]
        public async Task<IActionResult> DeleteAsync(string inmuebleId)
        {
            if (string.IsNullOrEmpty(inmuebleId))
            {
                return BadRequest();
            }
            var response = await _inmueblesApplication.DeleteAsync(inmuebleId);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [Authorize]
        [HttpGet("async/{InmuebleId}")]
        //[HttpGet("{InmuebleId}")]
        public async Task<IActionResult> GetAsync(string inmuebleId)
        {
            if (string.IsNullOrEmpty(inmuebleId))
            {
                return BadRequest();
            }
            var response = await _inmueblesApplication.GetAsync(inmuebleId);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [Authorize]
        [HttpGet("async")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _inmueblesApplication.GetAllAsync();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        #endregion
    }
}
