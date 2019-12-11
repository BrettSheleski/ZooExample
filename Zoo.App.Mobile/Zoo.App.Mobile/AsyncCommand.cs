using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Zoo.App.Mobile
{
    public class AsyncCommand : ICommand, INotifyPropertyChanged
    {
        public AsyncCommand(Func<Task> func)
        {
            this.Func = func;
        }

        public Func<Task> Func { get; }
        public bool Enabled
        {
            get => _enabled; set
            {
                if (_enabled != value)
                {
                    _enabled = value;
                    OnPropertyChanged();
                    OnCanExecuteChanged();
                }
            }
        }

        public event EventHandler CanExecuteChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool _enabled = true;

        bool ICommand.CanExecute(object parameter)
        {
            return Enabled;
        }

        async void ICommand.Execute(object parameter)
        {
            await Func();
        }
    }
}