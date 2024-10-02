using Cayetano.Inmobiliaria.Application.Dto;
using Cayetano.Inmobiliaria.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cayetano.Inmobiliaria.Application.Interface
{
    public interface IUsersApplication
    {
        Response<UsersDto> Authenticate(string username, string password);

    }
}
