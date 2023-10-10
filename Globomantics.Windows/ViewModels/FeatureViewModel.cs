using CommunityToolkit.Mvvm.Input;
using Globomantics.Domain;
using Globomantics.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Windows.ViewModels
{
    public class FeatureViewModel : BaseTodoViewModel<Feature>
    {
        private readonly IRepository<Feature> repository;

        private string? description;

        public string? Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public FeatureViewModel(IRepository<Feature> repository) : base()
        {
            this.repository = repository;

            SaveCommand = new RelayCommand(async () => await SaveAsync());

        }
        public override Task SaveAsync()
        {
            if (string.IsNullOrEmpty(Title))
            {
                ShowError?.Invoke($"{Title} can not be empty");
                return;
            }

            if (Model is null)
            {
                Model = new Feature(Title, Description, "UI?", 1,
                    App.CurrentUser, App.CurrentUser)
                {
                    DueDate = DateTimeOffset.Now.AddDays(10),
                    Parent = Parent,
                    IsCompleted = IsCompleted
                };
            }
            else
            {
                Model.
            }

        }

    }
}
