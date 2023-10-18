using Globomantics.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Infrastructure.Data.Repositories
{
    public class BugRepository : TodoRepository<Bug>
    {
        public override Task AddAsync(Bug item)
        {
            throw new NotImplementedException();
        }

        public override Task<Bug> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
