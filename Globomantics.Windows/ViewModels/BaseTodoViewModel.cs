using CommunityToolkit.Mvvm.ComponentModel;
using Globomantics.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Globomantics.Windows.ViewModels
{
    public abstract class BaseTodoViewModel<T> : ObservableObject, ITodoViewModel where T : Todo
    {
        private T? model;
        private string? title;
        private bool IsCompleted;
        private Todo? parent;

        public T? Model
        {
            get => model;

            set
            {
                model = value;
                OnPropertyChanged(nameof(Model));
            }
        }


        #region From ITodoViewModel and through it, the IViewModel
        public IEnumerable<Todo>? AvailableParentTasks { get; set; }

        public ICommand DeleteCommand { get; }
        public ICommand SaveCommand { get; set; }
        public Action<string>? ShowAlert { get; set; }
        public Action<string>? ShowError { get; set; }
        public Func<IEnumerable<string>>? ShowOpenFileDialog { get; set; }
        public Func<string>? ShowSaveFileDialog { get; set; }
        public Func<string, bool>? AskForConfirmation { get; set; }
        #endregion

        public abstract Task SaveAsync();

        public void UpdateModel(Todo model)
        {
            throw new NotImplementedException();
        }
    }
}
