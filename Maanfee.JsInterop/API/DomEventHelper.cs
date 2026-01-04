using Microsoft.JSInterop;

namespace Maanfee.JsInterop
{
    public class DomEventHelper : IDisposable
    {
        private readonly Dom _dom;

        public DomEventHelper(Dom dom)
        {
            _dom = dom;
        }

        public Func<EventArgs, Task> Callback { get; set; }

        [JSInvokable]
        public async Task OnEventFired()
        {
            if (Callback != null)
            {
                await Callback(EventArgs.Empty);
            }
        }

        public void Dispose()
        {
            Callback = null;
        }
    }
}
