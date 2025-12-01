using Microsoft.JSInterop;
using System.Text.Json;

namespace Maanfee.JsInterop
{
    public partial class LocalStorage : JsService, IAsyncDisposable
    {
        public LocalStorage(IJSRuntime JSRuntime) : base(JSRuntime, "Maanfee.JsInterop", "Storage.js")
        {
        }

        public new async ValueTask DisposeAsync()
        {
            if (!IsDisposed)
            {
                if (_Module != null)
                {
                    await _Module.InvokeVoidAsync("dispose");
                    await _Module.DisposeAsync();
                }

                await base.DisposeAsync();
            }
        }

        // ********************************************

        public async Task ClearAsync()
        {
            await EnsureModuleLoaded();
            await _Module.InvokeVoidAsync("Clear");
        }

        public async Task<string> KeyAsync(int Index)
        {
            await EnsureModuleLoaded();
            return await _Module.InvokeAsync<string>("Key", Index);
        }

        public async Task<T> GetAsync<T>(string Key)
        {
            await EnsureModuleLoaded();
            var data = await _Module.InvokeAsync<string>("Get", Key);

            return data == null ? default(T) : JsonSerializer.Deserialize<T>(data);
        }

        public async Task<List<string>> KeysAsync()
        {
            await EnsureModuleLoaded();
            var data = await _Module.InvokeAsync<string>("Keys");

            return data == null ? new List<string>() : JsonSerializer.Deserialize<List<string>>(data);
        }

        public async Task<int?> LengthAsync()
        {
            await EnsureModuleLoaded();
            var data = await _Module.InvokeAsync<int?>("Length");

            return data == null ? default : data;
        }

        public async Task SetAsync<T>(string Key, T value)
        {
            await EnsureModuleLoaded();
            await _Module.InvokeVoidAsync("Set", Key, JsonSerializer.Serialize(value));
        }

        public async Task RemoveAsync(string Key)
        {
            await EnsureModuleLoaded();
            await _Module.InvokeVoidAsync("Remove", Key);
        }
    }
}
