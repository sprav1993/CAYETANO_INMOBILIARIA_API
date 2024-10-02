using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cayetano.Inmobiliaria.Application.Dto
{
    public class InmueblesDto
    {
        public int InmuebleId { get; set; }
        public string TipoInmueble { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public int CantidadHabitaciones { get; set; }
        public int CantidadBaños { get; set; }
        public decimal MetrosCuadrados { get; set; }
        public decimal Precio { get; set; }
        public bool TieneGaraje { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaConstruccion { get; set; }
        public bool Disponible { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now; // Default to current date
    }

}
