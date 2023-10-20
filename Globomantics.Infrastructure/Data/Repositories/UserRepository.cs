using Globomantics.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Infrastructure.Data.Repositories
{
    public class UserRepository : IRepository<User>
    {
        public Task AddAsync(User item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> AllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByAsync(string value)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
