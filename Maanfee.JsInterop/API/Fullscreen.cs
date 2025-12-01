using Microsoft.JSInterop;

namespace Maanfee.JsInterop
{
    public partial class Fullscreen : JsService, IAsyncDisposable
    {
        public Fullscreen(IJSRuntime JSRuntime) : base(JSRuntime, "Maanfee.JsInterop", "Fullscreen.js")
        {
            _dotNetHelper = DotNetObjectReference.Create(this);
        }

        public new async ValueTask DisposeAsync()
        {
            if (!IsDisposed)
            {
                if (_Module != null)
                {
                    await RemoveFullscreenChangeListenerAsync();

                    await _Module.InvokeVoidAsync("dispose");
                    await _Module.DisposeAsync();
                }

                await base.DisposeAsync();
            }
        }

        // ********************************************

        private bool _listenerInitialized = false;
        private DotNetObjectReference<Fullscreen> _dotNetHelper;

        private async Task InitializeListenerAsync()
        {
            if (!_listenerInitialized)
            {
                await _Module.InvokeVoidAsync("addFullscreenChangeListener", _dotNetHelper);
                _listenerInitialized = true;
            }
        }

        public async ValueTask<bool> RequestFullscreenAsync(string elementId = null)
        {
            await InitializeListenerAsync();

            try
            {
                if (string.IsNullOrEmpty(elementId))
                {
                    await _Module.InvokeVoidAsync("requestFullscreen");
                }
                else
                {
                    await _Module.InvokeVoidAsync("requestFullscreen", elementId);
                }
                return true;
            }
            catch //(Exception ex)
            {
                //throw new Exception(ex.Message);
                return false;
            }
        }

        public async ValueTask<bool> ExitFullscreenAsync()
        {
            await InitializeListenerAsync();

            try
            {
                await _Module.InvokeVoidAsync("exitFullscreen");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async ValueTask<bool> ToggleFullscreenAsync(string elementId = null)
        {
            await InitializeListenerAsync();
            try
            {
                if (string.IsNullOrEmpty(elementId))
                {
                    await _Module.InvokeVoidAsync("toggleFullscreen");
                }
                else
                {
                    await _Module.InvokeVoidAsync("toggleFullscreen", elementId);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async ValueTask<bool> IsFullscreenAsync()
        {
            await InitializeListenerAsync();
            try
            {
                return await _Module.InvokeAsync<bool>("isFullscreen");
            }
            catch
            {
                return false;
            }
        }

        public async ValueTask<string> GetFullscreenElementAsync()
        {
            await InitializeListenerAsync();
            try
            {
                return await _Module.InvokeAsync<string>("getFullscreenElement");
            }
            catch
            {
                return null;
            }
        }

        // Events
        private async Task RemoveFullscreenChangeListenerAsync()
        {
            if (_listenerInitialized && _Module != null)
            {
                await _Module.InvokeVoidAsync("removeFullscreenChangeListener");
                _listenerInitialized = false;
            }
        }

        [JSInvokable]
        public async Task OnFullscreenChange(bool isFullscreen)
        {
            await InitializeListenerAsync();
            FullscreenChanged?.Invoke(this, isFullscreen);
        }

        public event EventHandler<bool> FullscreenChanged;
    }
}
