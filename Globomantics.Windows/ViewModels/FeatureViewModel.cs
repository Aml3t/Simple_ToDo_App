﻿using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Globomantics.Domain;
using Globomantics.Infrastructure.Data.Repositories;
using Globomantics.Windows.Messages;
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

        public string Description
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
        public override async Task SaveAsync()
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
                Model = Model with
                {
                    Title = Title,
                    Description = Description,
                    Parent = Parent,
                    IsCompleted = IsCompleted
                };
            }

            try
            {
                await repository.AddAsync(Model);
                await repository.SaveChangesAsync();
                WeakReferenceMessenger.Default.Send<TodoSavedMessage>(new(Model));
            }
            catch (Exception ex)
            {
                ShowError?.Invoke("Could not save to the database");
            }
        }

        public override void UpdateModel(Todo model)
        {
            if (model is not Feature feature) return;

            base.UpdateModel(feature);

            Description = feature.Description;

        }

    }
}
