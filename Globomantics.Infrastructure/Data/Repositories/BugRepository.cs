using Globomantics.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Infrastructure.Data.Repositories
{
    public class BugRepository : TodoRepository<Bug>
    {
        public BugRepository(GlobomanticsDbContext context) : base(context) { }

        public override async Task AddAsync(Bug bug)
        {
            var existingBug = await Context.Bugs.FirstOrDefaultAsync(
                b => b.Id == bug.Id
            );

            var user = await Context.Users.FirstOrDefaultAsync(
                u => u.Id == bug.CreatedBy.Id
            );

            user ??= new() { Id = bug.CreatedBy.Id, Name = bug.CreatedBy.Name };

        }

        public override Task<Bug> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
