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

        #region - DOM Selector -

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

        #endregion

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

        #region - ClassList -

        public async Task<Dom> AddClassAsync(string className)
        {
            await _Module.InvokeAsync<string>("AddClass", selector, selectors, className);
            return this;
        }

        public async Task<Dom> RemoveClassAsync(string className)
        {
            await _Module.InvokeAsync<string>("RemoveClass", selector, selectors, className);
            return this;
        }

        public async Task<Dom> ToggleClassAsync(string className)
        {
            await _Module.InvokeAsync<string>("ToggleClass", selector, selectors, className);
            return this;
        }

        public async Task<bool> HasClassAsync(string className)
        {
            var result = await _Module.InvokeAsync<string>("HasClass", selector, selectors, className);
            return result == "true";
        }

        public async Task<IList<bool>> HasClassAllAsync(string className)
        {
            var data = await _Module.InvokeAsync<string>("HasClass", selector, selectors, className);
            if (string.IsNullOrEmpty(data))
                return new List<bool>();

            var list = JsonSerializer.Deserialize<List<string>>(data);
            return list.Select(x => x == "true").ToList();
        }

        #endregion

        #region - CSS -

        public async Task<Dom> CssAsync(string PropertyName, string Value)
        {
            await _Module.InvokeAsync<string>("Css", selector, selectors, PropertyName, Value);
            return this;
        }

        public async Task<T> CssAsync<T>(string PropertyName)
        {
            var data = await _Module.InvokeAsync<string>("Css", selector, selectors, PropertyName);

            if (!string.IsNullOrEmpty(data))
            {
                var list = JsonSerializer.Deserialize<List<string>>(data);

                if (typeof(T) == typeof(string))
                    return (T)(object)(list.FirstOrDefault() ?? string.Empty);
                else if (typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(List<>)
                      || typeof(T) == typeof(IList<string>) || typeof(T) == typeof(IEnumerable<string>))
                    return (T)(object)list;
            }

            return default(T);
        }

        #endregion

        // برای راحتی: متدهای اختصاصی برای display, opacity و ...
        //public async Task<Dom> ShowAsync() => await CssAsync("display", "block");
        //public async Task<Dom> HideAsync() => await CssAsync("display", "none");
        //public async Task<Dom> FadeInAsync(int durationMs = 300) => await CssAsync("transition", $"opacity {durationMs}ms").CssAsync("opacity", "1");
        //public async Task<Dom> FadeOutAsync(int durationMs = 300) => await CssAsync("transition", $"opacity {durationMs}ms").CssAsync("opacity", "0");


        // ==========================================

        #region - Events -

        public async Task<Dom> ClickAsync()
        {
            await _Module.InvokeAsync<Task>("OnClick", selector, selectors);
            return this;
        }

        #endregion

        #region - Events (addEventListener with callback) -

        private readonly Dictionary<string, DotNetObjectReference<DomEventHelper>> _eventHelpers = new();

        public async Task<Dom> OnAsync(string eventName, Func<EventArgs, Task> callback)
        {
            var helper = new DomEventHelper(this);
            var dotNetRef = DotNetObjectReference.Create(helper);

            var key = $"{selector ?? selectors}_{eventName}";

            // حذف قبلی اگر وجود داشت
            if (_eventHelpers.TryGetValue(key, out var oldRef))
            {
                oldRef.Dispose();
                _eventHelpers.Remove(key);
            }

            _eventHelpers[key] = dotNetRef;
            helper.Callback = callback;

            await _Module.InvokeVoidAsync("AddEventListener", selector, selectors, eventName, dotNetRef);

            return this;
        }

        public async Task<Dom> OffAsync(string eventName)
        {
            var key = $"{selector ?? selectors}_{eventName}";
            if (_eventHelpers.TryGetValue(key, out var dotNetRef))
            {
                await _Module.InvokeVoidAsync("RemoveEventListener", selector, selectors, eventName);
                dotNetRef.Dispose();
                _eventHelpers.Remove(key);
            }
            return this;
        }

        #endregion

        #region -  -



        #endregion

    }
}
