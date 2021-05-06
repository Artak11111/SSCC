using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ControlCenter.Client.Models
{
    public class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Fields

        private readonly Dictionary<string, List<string>> propertyDependencies = new Dictionary<string, List<string>>();

        #endregion Fields

        #region Constructor

        public BindableBase()
        {
            PropertyChanged += UpdateDependencies;
        }

        #endregion Constructor

        #region Methods

        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool Set<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value)) return false;

            storage = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        protected void AddPropertyDependencies(string target, params string[] from)
        {
            foreach (var property in from)
            {
                if (propertyDependencies.ContainsKey(property))
                {
                    if (propertyDependencies[property].Contains(target)) return;

                    propertyDependencies[property].Add(target);
                }
                else
                {
                    propertyDependencies.Add(property, new List<string> { target });
                }
            }
        }

        private void UpdateDependencies(object sender, PropertyChangedEventArgs e)
        {
            if (!propertyDependencies.Any(p => p.Key == e.PropertyName)) return;

            foreach (var property in propertyDependencies[e.PropertyName])
            {
                OnPropertyChanged(property);
            }
        }

        #endregion Methods
    }
}
