namespace HrisApp.Client.Global
{
    public class StateService
    {
#nullable disable
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
