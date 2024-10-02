using Cayetano.Inmobiliaria.Domain.Entity;
using Cayetano.Inmobiliaria.Domain.Interface;
using Cayetano.Inmobiliaria.Infrastructure.Interface;

namespace Cayetano.Inmobiliaria.Domain.Core
{
    public class UsersDomain : IUsersDomain
    {
        private readonly IUsersRepository _usersRepository;
        public UsersDomain(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public Users Authenticate(string userName, string password)
        {
            return _usersRepository.Authenticate(userName, password);
        }
    }
}
