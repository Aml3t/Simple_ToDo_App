using Globomantics.Domain;
using Globomantics.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Windows.ViewModels
{
    public class BugViewModel : BaseTodoViewModel<Bug>
    {
        private readonly IRepository<Feature> repository;

        private string? description;
        private string? affectedVersion;
        private int affectedUsers;
        private DateTimeOffset dueDate;
        private Severity severity;






        public string? Description
        {
            get => description;

            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public BugViewModel(IRepository<Feature> repository) : base()
        {
            this.repository = repository;
        }

        public override Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
