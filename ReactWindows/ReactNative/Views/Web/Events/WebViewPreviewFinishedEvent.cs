using Newtonsoft.Json.Linq;
using ReactNative.UIManager.Events;
using System;
using Windows.Web;

namespace ReactNative.Views.Web.Events
{
    class WebViewPreviewFinishedEvent : Event
    {
        private readonly string base64bmp;

        public WebViewPreviewFinishedEvent(int viewTag, string base64bmp)
            : base(viewTag, TimeSpan.FromTicks(Environment.TickCount))
        {
            this.base64bmp = base64bmp;
        }

        public override string EventName
        {
            get
            {
                return "topPreviewCaptureFinished";
            }
        }

        public override void Dispatch(RCTEventEmitter eventEmitter)
        {
            var eventData = new JObject
            {
                { "target", ViewTag },
                { "base64bmp", base64bmp },
            };

            eventEmitter.receiveEvent(ViewTag, EventName, eventData);
        }
    }
}
