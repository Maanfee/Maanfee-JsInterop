using Microsoft.JSInterop;

namespace Maanfee.JsInterop
{
    public class FileDownload : JsService, IAsyncDisposable
    {
        public FileDownload(IJSRuntime JSRuntime) : base(JSRuntime, "Maanfee.JsInterop", "FileDownload.js")
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

        public async Task DownloadFileFromStream(string FileName, DotNetStreamReference Stream)
        {
            await EnsureModuleLoaded();
            await _Module.InvokeVoidAsync("DownloadFileFromStream", FileName, Stream);
        }

        public async Task DownloadFileFromUrl(string fileName, string url)
        {
            await EnsureModuleLoaded();
            await _Module.InvokeVoidAsync("DownloadFileFromUrl", fileName, url);
        }

    }
}
