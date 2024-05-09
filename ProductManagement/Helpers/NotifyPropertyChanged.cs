using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProductManagement.Helpers;


public abstract class NotifyPropertyChanged : INotifyPropertyChanged
{
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? paramName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(paramName));
}

