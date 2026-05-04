using Microsoft.JSInterop;

namespace Maanfee.JsInterop
{
    public partial class Clipboard : JsService, IAsyncDisposable
    {
        public Clipboard(IJSRuntime JSRuntime) : base(JSRuntime, "Maanfee.JsInterop", "Clipboard.js")
        {
            //_ = Task.Run(async () => await EnsureModuleLoaded());
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

        /// <summary>
        /// نوشتن متن در کلیپ‌بورد
        /// </summary>
        public async Task<bool> WriteTextAsync(string text)
        {
            try
            {
                await EnsureModuleLoaded();
                return await _Module.InvokeAsync<bool>("writeText", text);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error writing to clipboard: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// خواندن متن از کلیپ‌بورد
        /// </summary>
        public async Task<string> ReadTextAsync()
        {
            try
            {
                await EnsureModuleLoaded();
                return await _Module.InvokeAsync<string>("readText");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error reading from clipboard: {ex.Message}");
                return string.Empty;
            }
        }

        /// <summary>
        /// بررسی دسترسی به کلیپ‌بورد
        /// </summary>
        public async Task<bool> IsSupportedAsync()
        {
            try
            {
                await EnsureModuleLoaded();
                return await _Module.InvokeAsync<bool>("isSupported");
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// نوشتن HTML در کلیپ‌بورد
        /// </summary>
        public async Task<bool> WriteHtmlAsync(string html)
        {
            try
            {
                await EnsureModuleLoaded();
                return await _Module.InvokeAsync<bool>("writeHtml", html);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error writing HTML to clipboard: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// پاک کردن کلیپ‌بورد
        /// </summary>
        public async Task<bool> ClearAsync()
        {
            try
            {
                await EnsureModuleLoaded();
                return await _Module.InvokeAsync<bool>("clear");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error clearing clipboard: {ex.Message}");
                return false;
            }
        }
    }
}
