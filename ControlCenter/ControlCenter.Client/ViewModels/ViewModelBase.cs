using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ControlCenter.Client.Annotations;

namespace ControlCenter.Client.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool Set<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value)) return false;

            storage = value;
            OnPropertyChanged(propertyName);

            return true;
        }
        
        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}