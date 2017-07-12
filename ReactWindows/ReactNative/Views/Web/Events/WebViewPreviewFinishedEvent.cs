using Newtonsoft.Json.Linq;
using ReactNative.UIManager.Events;
using System;
using Windows.Web;

namespace ReactNative.Views.Web.Events
{
    class WebViewPreviewFinishedEvent : Event
    {
        private readonly string base64img;

        public WebViewPreviewFinishedEvent(int viewTag, string base64img)
            : base(viewTag, TimeSpan.FromTicks(Environment.TickCount))
        {
            this.base64img = base64img;
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
                { "base64img", base64img },
            };

            eventEmitter.receiveEvent(ViewTag, EventName, eventData);
        }
    }
}
