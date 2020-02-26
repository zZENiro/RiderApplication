using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace RiderApplication.ViewModels
{
    public abstract class ModelView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetValue<T>(ref T target, T value, [CallerMemberName] string PropName = null)
        {
            if (object.Equals(target, value))
                return false;

            target = value;
            OnPropertyChanged(PropName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string PropName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropName));
    }
}
