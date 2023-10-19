using Globomantics.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Infrastructure.Data.Repositories
{
    public class FeatureRepository : TodoRepository<Feature>
    {
        public FeatureRepository(GlobomanticsDbContext context) : base(context) { }

        public override async Task AddAsync(Feature feature)
        {
            var existingFeature = await Context.Features.FirstOrDefaultAsync(
                b => b.Id == feature.Id);

            var user = await Context.Users.SingleOrDefaultAsync(
                u => u.Id == feature.Id);

        }

        public override Task<Feature> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
