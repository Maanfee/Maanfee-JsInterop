namespace Maanfee.JsInterop
{
    public static class DomHelpers
    {
        // ========== Content Manipulation ==========

        #region - Text -

        public static async Task<Dom> TextAsync(this Task<Dom> dom, string Text) => await (await dom).TextAsync(Text);

        public static async Task<T> TextAsync<T>(this Task<Dom> dom) => await (await dom).TextAsync<T>();

        #endregion

        #region - HTML -

        public static async Task<Dom> HTMLAsync(this Task<Dom> dom, string Text) => await (await dom).HTMLAsync(Text);

        public static async Task<T> HTMLAsync<T>(this Task<Dom> dom) => await (await dom).HTMLAsync<T>();


        #endregion

        #region - Val -

        public static async Task<Dom> ValAsync(this Task<Dom> dom, string Text) => await (await dom).ValAsync(Text);

        public static async Task<T> ValAsync<T>(this Task<Dom> dom) => await (await dom).ValAsync<T>();

        #endregion

        #region - Attr -

        public static async Task<T> AttrAsync<T>(this Task<Dom> dom, string AttributeName) => await (await dom).AttrAsync<T>(AttributeName);

        public static async Task<Dom> AttrAsync(this Task<Dom> dom, string AttributeName, string AttributeValue) => await (await dom).AttrAsync(AttributeName, AttributeValue);

        #endregion

        #region - ClassList -

        public static async Task<Dom> AddClassAsync(this Task<Dom> dom, string className)
            => await (await dom).AddClassAsync(className);

        public static async Task<Dom> RemoveClassAsync(this Task<Dom> dom, string className)
            => await (await dom).RemoveClassAsync(className);

        public static async Task<Dom> ToggleClassAsync(this Task<Dom> dom, string className)
            => await (await dom).ToggleClassAsync(className);

        public static async Task<bool> HasClassAsync(this Task<Dom> dom, string className)
            => await (await dom).HasClassAsync(className);

        #endregion

        #region - CSS -

        public static async Task<Dom> CssAsync(this Task<Dom> dom, string propertyName, string value)
            => await (await dom).CssAsync(propertyName, value);

        public static async Task<T> CssAsync<T>(this Task<Dom> dom, string propertyName)
            => await (await dom).CssAsync<T>(propertyName);

        #endregion

        //public static async Task<Dom> ShowAsync(this Task<Dom> dom) => await (await dom).ShowAsync();
        //public static async Task<Dom> HideAsync(this Task<Dom> dom) => await (await dom).HideAsync();
        //public static async Task<Dom> FadeInAsync(this Task<Dom> dom, int durationMs = 300) => await (await dom).FadeInAsync(durationMs);
        //public static async Task<Dom> FadeOutAsync(this Task<Dom> dom, int durationMs = 300) => await (await dom).FadeOutAsync(durationMs);


        // ==========================================

        #region - Events -

        public static async Task ClickAsync(this Task<Dom> dom) => await (await dom).ClickAsync();

        #endregion

        #region - Events (addEventListener with callback) -

        public static async Task OnAsync(this Task<Dom> dom, string eventName, Func<EventArgs, Task> callback)
            => await (await dom).OnAsync(eventName, callback);

        public static async Task OffAsync(this Task<Dom> dom, string eventName)
            => await (await dom).OffAsync(eventName);

        #endregion

    }
}
