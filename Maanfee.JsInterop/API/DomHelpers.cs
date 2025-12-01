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

        // ==========================================

        #region - Events -

        public static async Task ClickAsync(this Task<Dom> dom) => await (await dom).ClickAsync();

        #endregion

    }
}
