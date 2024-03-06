using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HrisApp.Client.ViewModel
{
#nullable disable

    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string _property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_property));
        }

        protected void SetValue<T>(ref T _backingFiled, T value, [CallerMemberName] string _propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(_backingFiled, value)) return;
            _backingFiled = value;
            OnPropertyChanged(_propertyName);
        }

        public event Action OnChange;

        private readonly Dictionary<string, object> _stateDictionary = new();

        public T GetState<T>(string key)
        {
            if (_stateDictionary.TryGetValue(key, out var value))
            {
                return (T)value;
            }

            return default;
        }

        public void SetState<T>(string key, T value)
        {
            _stateDictionary[key] = value;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}