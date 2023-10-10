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

        public Severity Severity
        {
            get => severity;
            
            set
            {
                severity = value;
                OnPropertyChanged(nameof(Severity));
            }
        }
        public DateTimeOffset DueDate
        {
            get => dueDate;
            set
            {
                dueDate = value;
                OnPropertyChanged(nameof(DueDate));
            }
        }
        public int AffectedUsers
        {
            get => affectedUsers;
            set
            {
                affectedUsers = value;
                OnPropertyChanged(nameof(AffectedUsers));
            }
        }
        public string? AffectedVersion
        {
            get => affectedVersion;

            set
            {
                affectedVersion = value;
                OnPropertyChanged(nameof(AffectedVersion));
            }
        }
        public string? Description
        {
            get => description;

            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public IEnumerable<Severity> SeverityLevels { get; } = new[]
        {
            Severity.Critical,
            Severity.Annoying,
            Severity.Major,
            Severity.Minor
        };

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
