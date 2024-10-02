using Dapper;
using Cayetano.Inmobiliaria.Domain.Entity;
using Cayetano.Inmobiliaria.Infrastructure.Interface;
using Cayetano.Inmobiliaria.Transversal.Common;
using System.Data;

namespace Cayetano.Inmobiliaria.Infrastructure.Repository
{
    public class InmueblesRepository : IInmueblesRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public InmueblesRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        #region Métodos Asíncronos
        public async Task<bool> InsertAsync(Inmuebles inmuebles)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "sp_Inmueble_Insert";
                var parameters = new DynamicParameters();
                parameters.Add("TipoInmueble", inmuebles.TipoInmueble);
                parameters.Add("Direccion", inmuebles.Direccion);
                parameters.Add("Ciudad", inmuebles.Ciudad);
                parameters.Add("CantidadHabitaciones", inmuebles.CantidadHabitaciones);
                parameters.Add("CantidadBaños", inmuebles.CantidadBaños);
                parameters.Add("MetrosCuadrados", inmuebles.MetrosCuadrados);
                parameters.Add("Precio", inmuebles.Precio);
                parameters.Add("TieneGaraje", inmuebles.TieneGaraje);
                parameters.Add("Descripcion", inmuebles.Descripcion);
                parameters.Add("FechaConstruccion", inmuebles.FechaConstruccion);
                parameters.Add("Disponible", inmuebles.Disponible);
                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        public async Task<bool> UpdateAsync(Inmuebles inmuebles)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "sp_Inmueble_Update";
                var parameters = new DynamicParameters();
                parameters.Add("InmuebleId", inmuebles.InmuebleId);
                parameters.Add("TipoInmueble", inmuebles.TipoInmueble);
                parameters.Add("Direccion", inmuebles.Direccion);
                parameters.Add("Ciudad", inmuebles.Ciudad);
                parameters.Add("CantidadHabitaciones", inmuebles.CantidadHabitaciones);
                parameters.Add("CantidadBaños", inmuebles.CantidadBaños);
                parameters.Add("MetrosCuadrados", inmuebles.MetrosCuadrados);
                parameters.Add("Precio", inmuebles.Precio);
                parameters.Add("TieneGaraje", inmuebles.TieneGaraje);
                parameters.Add("Descripcion", inmuebles.Descripcion);
                parameters.Add("FechaConstruccion", inmuebles.FechaConstruccion);
                parameters.Add("Disponible", inmuebles.Disponible);
                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        public async Task<bool> DeleteAsync(string inmuebleId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "sp_Inmueble_Delete";
                var parameters = new DynamicParameters();
                parameters.Add("InmuebleId", inmuebleId);
                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        public async Task<Inmuebles> GetAsync(string inmuebleId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "sp_Inmueble_GetById";
                var parameters = new DynamicParameters();
                parameters.Add("InmuebleId", inmuebleId);
                var inmueble = await connection.QuerySingleAsync<Inmuebles>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return inmueble;
            }
        }
        public async Task<IEnumerable<Inmuebles>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "sp_Inmueble_GetAll";
                var inmueble = await connection.QueryAsync<Inmuebles>(query, commandType: CommandType.StoredProcedure);
                return inmueble;
            }
        }

        #endregion
    }
}
