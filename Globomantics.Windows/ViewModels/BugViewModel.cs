using CommunityToolkit.Mvvm.Input;
using Globomantics.Domain;
using Globomantics.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
        public ObservableCollection<byte[]> Screenshots { get; set; } = new ();
        public ICommand AttachScreenshotCommand { get; set; }

        public BugViewModel(IRepository<Feature> repository) : base()
        {
            this.repository = repository;

            SaveCommand = new RelayCommand(async () => await SaveAsync());

            AttachScreenshotCommand = new RelayCommand(() =>
            {
                var filenames = ShowOpenFileDialog?.Invoke();

                if (filenames is null || !filenames.Any())
                {
                    return;
                }

                foreach (var filename in filenames)
                {
                    Screenshots.Add(File.ReadAllBytes(filename));
                }
            }
            );
        }

        public override Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
