namespace HrisApp.Client.GlobalService
{
    public static class IJSRuntimeExtensionMethods
    {
        public static async ValueTask InitializeInactivityTimer<T>(this IJSRuntime js, DotNetObjectReference<T> dotNetObjectReference) where T : class
        {
            await js.InvokeVoidAsync("initializeInactivityTimer", dotNetObjectReference);
        }


        public static async ValueTask InitializeNotif<T>(this IJSRuntime js, DotNetObjectReference<T> dotNetObjectReference) where T : class
        {
            await js.InvokeVoidAsync("initializeNotif", dotNetObjectReference);
        }
    }
}
