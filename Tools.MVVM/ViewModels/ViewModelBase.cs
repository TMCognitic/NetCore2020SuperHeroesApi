using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Tools.MVVM.Commands;

namespace Tools.MVVM.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModelBase()
        {
            Type viewModelType = GetType();
            IEnumerable<PropertyInfo> properties = viewModelType.GetProperties().Where(pi => pi.PropertyType == typeof(ICommand) || pi.PropertyType.GetInterfaces().Contains(typeof(ICommand)));

            foreach(PropertyInfo property in properties)
            {
                ICommand command = (ICommand)property.GetValue(this);
                PropertyChanged += (sender, args) => command.RaiseCanExecuteChanged();
            }
        }

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return;

            field = value;
            RaisePropertyChanged(propertyName);
        }
    }
}
