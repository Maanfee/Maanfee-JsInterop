using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using System.Net.NetworkInformation;

namespace Maanfee.JsInterop
{
    public class Print : JsService, IAsyncDisposable
    {
        public Print(IJSRuntime JSRuntime) : base(JSRuntime, "Maanfee.JsInterop", "Print.js")
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

        public async ValueTask PrintAsync(string Id)
        {
            await EnsureModuleLoaded();
            await _Module.InvokeVoidAsync("print", Id);
        }

        //public async ValueTask PrintElementAsync(string elementId, PrintOptions options = null)
        //{
        //    await EnsureModuleLoaded();
        //    await _Module.InvokeVoidAsync("printElement", elementId, options);
        //}

        //public async ValueTask PrintDirectAsync(string elementId, PrintOptions options = null)
        //{
        //    await EnsureModuleLoaded();
        //    await _Module.InvokeVoidAsync("printDirect", elementId, options);
        //}

        //public async ValueTask GeneratePDFAsync(string elementId, PrintOptions options = null)
        //{
        //    await EnsureModuleLoaded();
        //    await _Module.InvokeVoidAsync("generatePDF", elementId, options);
        //}

        //public async ValueTask PreviewAsync(string elementId, PrintOptions options = null)
        //{
        //    await EnsureModuleLoaded();
        //    await _Module.InvokeVoidAsync("preview", elementId, options);
        //}

        //public async ValueTask QuickPrintAsync(string elementId, PageSize pageSize = PageSize.A4,
        //  Orientation orientation = Orientation.Portrait)
        //{
        //    await EnsureModuleLoaded();
        //    await _Module.InvokeVoidAsync("quickPrint", elementId, pageSize.ToString().ToLower(),
        //        orientation.ToString().ToLower());
        //}

        //public async ValueTask PrintHtmlAsync(string htmlContent, PrintOptions options = null)
        //{
        //    await EnsureModuleLoaded();
        //    await _Module.InvokeVoidAsync("printHtml", htmlContent, options);
        //}

        //public async ValueTask<bool> IsPrinterAvailableAsync()
        //{
        //    await EnsureModuleLoaded();
        //    return await _Module.InvokeAsync<bool>("isPrinterAvailable");
        //}

        //public async ValueTask<string[]> GetAvailablePrintersAsync()
        //{
        //    await EnsureModuleLoaded();
        //    return await _Module.InvokeAsync<string[]>("getAvailablePrinters");
        //}
    }

    //public class PrintOptions
    //{
    //    public PageSize PageSize { get; set; } = PageSize.A4;
    //    public Orientation Orientation { get; set; } = Orientation.Portrait;
    //    public int Copies { get; set; } = 1;
    //    public PrintMargin Margin { get; set; } = new PrintMargin();
    //    public string Unit { get; set; } = "mm";
    //    public bool PreserveStyles { get; set; } = true;
    //    public bool IncludeCSS { get; set; } = true;
    //    public string[] IgnoreElements { get; set; } = new string[] { ".no-print" };
    //    public PrintHeader Footer { get; set; }
    //    public PrintHeader Header { get; set; }
    //    public WatermarkOptions Watermark { get; set; }
    //    public string Title { get; set; } = "Document";
    //    public string FileName { get; set; } = "document.pdf";
    //    public bool AutoClose { get; set; } = true;
    //    public bool AutoSave { get; set; } = true;
    //    public PageBreakOptions PageBreak { get; set; } = new PageBreakOptions();
    //}

    //public class PrintMargin
    //{
    //    public int Top { get; set; } = 15;
    //    public int Right { get; set; } = 15;
    //    public int Bottom { get; set; } = 15;
    //    public int Left { get; set; } = 15;

    //    public override string ToString()
    //    {
    //        return $"{Top}{Unit} {Right}{Unit} {Bottom}{Unit} {Left}{Unit}";
    //    }

    //    private const string Unit = "mm";
    //}

    //public class PrintHeader
    //{
    //    public string Content { get; set; }
    //    public string Style { get; set; } = "font-size: 12px; text-align: center;";
    //    public bool ShowPageNumbers { get; set; } = true;
    //}

    //public class WatermarkOptions
    //{
    //    public string Text { get; set; }
    //    public string Color { get; set; } = "rgba(0,0,0,0.1)";
    //    public int FontSize { get; set; } = 48;
    //    public int Angle { get; set; } = -45;
    //    public string Position { get; set; } = "center";
    //}

    //public class PageBreakOptions
    //{
    //    public bool Auto { get; set; } = true;
    //    public string[] Avoid { get; set; } = new string[] { "h1", "h2", "tr", "img" };
    //}

    //public enum PageSize
    //{
    //    A0, A1, A2, A3, A4, A5, A6, A7, A8,
    //    Letter, Legal, Tabloid
    //}

    //public enum Orientation
    //{
    //    Portrait,
    //    Landscape
    //}
}
