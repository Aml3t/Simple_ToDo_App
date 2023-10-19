using Globomantics.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Infrastructure.Data.Repositories
{
    public class FeatureRepository : TodoRepository<Feature>
    {
        public FeatureRepository(GlobomanticsDbContext context) : base(context)
        {

        }

        public override Task AddAsync(Feature item)
        {
            throw new NotImplementedException();
        }

        public override Task<Feature> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
