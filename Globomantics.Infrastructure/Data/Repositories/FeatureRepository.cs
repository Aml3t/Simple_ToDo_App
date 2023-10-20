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

            user ??= new() { Id = feature.CreatedBy.Id, Name = feature.CreatedBy.Name };

            if (existingFeature is not null)
            {
                await UpdateAsync(feature, existingFeature, user);
            }
            else
            {
                await CreateAsync(feature, existingFeature, user);
            }
        }

        private async Task UpdateAsync(Feature feature,
            Data.Models.Feature featureToUpdate,
            Data.Models.User user)
        {
            await SetParentAsync(featureToUpdate, feature);


        }

        private Task CreateAsync(Feature feature, Models.Feature? existingFeature, Models.User user)
        {
            throw new NotImplementedException();
        }

        public override Task<Feature> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
