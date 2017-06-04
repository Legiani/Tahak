using System;
using WatchKit;
using Foundation;
using System.Collections.Generic;
using WatchConnectivity;
using Newtonsoft.Json.Linq;

namespace Tahak.TahacekExtension
{
    public partial class InterfaceController : WKInterfaceController
    {
        protected InterfaceController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void Awake(NSObject context)
        {
            base.Awake(context);

            // Configure interface objects here.
            Console.WriteLine("{0} awake with context", this);
            WCSessionManager.SharedManager.ApplicationContextUpdated += DidReceiveApplicationContext;
        }

        public override void WillActivate()
        {
            // This method is called when the watch view controller is about to be visible to the user.
            Console.WriteLine("{0} will activate", this);
        }

        public override void DidDeactivate()
        {
            // This method is called when the watch view controller is no longer visible to the user.
            Console.WriteLine("{0} did deactivate", this);
            WCSessionManager.SharedManager.ApplicationContextUpdated -= DidReceiveApplicationContext;
        }


        public void DidReceiveApplicationContext(WCSession session, Dictionary<string, object> applicationContext)
        {
			

			var message = (string)applicationContext["MessagePhone"];

            Console.WriteLine($"Přijato: {message}");

            if (message != null)
            {
                Console.WriteLine($"Application context update received : {message}");
                echo.SetText(message);
            }
        }

        //private void sendEmoji(string emoji)
        //{WCSessionManager.SharedManager.UpdateApplicationContext(new Dictionary<string, object>() { { "MessageWatch", $"{emoji}" } });}
    }
}
