using Microsoft.JSInterop;
using System.Text.Json;

namespace Maanfee.JsInterop
{
    public partial class Dom : JsService, IAsyncDisposable
    {
        public Dom(IJSRuntime JSRuntime) : base(JSRuntime, "Maanfee.JsInterop", "Dom.js")
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

        private string selector { get; set; }

        private string selectors { get; set; }

        // ========== DOM Selection ==========
        public async Task<Dom> QuerySelector(string Selector)
        {
            selector = Selector;
            selectors = null;
            return this;
        }

        public async Task<Dom> QuerySelectorAll(string Selectors)
        {
            selectors = Selectors;
            selector = null;
            return this;
        }

        // ========== Content Manipulation ==========

        #region - Test -

        public async Task<T> TextAsync<T>()
        {
            var data = await _Module.InvokeAsync<string>("Text", selector, selectors, null);

            if (!string.IsNullOrEmpty(data))
            {
                var list = JsonSerializer.Deserialize<List<string>>(data);

                if (typeof(T) == typeof(string))
                    return (T)(object)(list.FirstOrDefault() ?? string.Empty);
                else if (typeof(T) == typeof(IList<string>))
                    return (T)(object)list;
            }

            return default(T);
        }

        public async Task<Dom> TextAsync(string Text)
        {
            await _Module.InvokeAsync<string>("Text", selector, selectors, Text);
            return this;
        }

        #endregion

        #region - HTML -

        public async Task<T> HTMLAsync<T>()
        {
            var data = await _Module.InvokeAsync<string>("HTML", selector, selectors, null);

            if (!string.IsNullOrEmpty(data))
            {
                var list = JsonSerializer.Deserialize<List<string>>(data);

                if (typeof(T) == typeof(string))
                    return (T)(object)(list.FirstOrDefault() ?? string.Empty);
                else if (typeof(T) == typeof(IList<string>))
                    return (T)(object)list;
            }

            return default(T);
        }

        public async Task<Dom> HTMLAsync(string Text)
        {
            await _Module.InvokeAsync<string>("HTML", selector, selectors, Text);
            return this;
        }

        #endregion

        #region - Val -

        public async Task<T> ValAsync<T>()
        {
            var data = await _Module.InvokeAsync<string>("Val", selector, selectors, null);

            if (!string.IsNullOrEmpty(data))
            {
                var list = JsonSerializer.Deserialize<List<string>>(data);

                if (typeof(T) == typeof(string))
                    return (T)(object)(list.FirstOrDefault() ?? string.Empty);
                else if (typeof(T) == typeof(IList<string>))
                    return (T)(object)list;
            }

            return default(T);
        }

        public async Task<Dom> ValAsync(string Val)
        {
            await _Module.InvokeAsync<string>("Val", selector, selectors, Val);
            return this;
        }

        #endregion

        #region - Attr -

        // except hasAttribute(name) | removeAttribute(name) 

        public async Task<T> AttrAsync<T>(string AttributeName)
        {
            var data = await _Module.InvokeAsync<string>("Attr", selector, selectors, AttributeName, null);

            if (!string.IsNullOrEmpty(data))
            {
                var list = JsonSerializer.Deserialize<List<string>>(data);

                if (typeof(T) == typeof(string))
                    return (T)(object)(list.FirstOrDefault() ?? string.Empty);
                else if (typeof(T) == typeof(IList<string>))
                    return (T)(object)list;
            }

            return default(T);
        }

        public async Task<Dom> AttrAsync(string AttributeName, string AttributeValue)
        {
            await _Module.InvokeAsync<string>("Attr", selector, selectors, AttributeName, AttributeValue);
            return this;
        }

        #endregion

        // ==========================================

        #region - Events -

        public async Task<Dom> ClickAsync()
        {
            await _Module.InvokeAsync<Task>("OnClick", selector, selectors);
            return this;
        }

        #endregion

        #region -  -



        #endregion

    }
}
