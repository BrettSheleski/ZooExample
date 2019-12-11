using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Zoo.App.Mobile
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void Set<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
        {
            Set(ref field, value, null, propertyName);
        }

        protected void Set<T>(ref T field, T value, Action callback, [CallerMemberName]string propertyName = null)
        {
            if (!System.Collections.Generic.EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;

                OnPropertyChanged(propertyName);

                callback?.Invoke();
            }
        }
    }
}