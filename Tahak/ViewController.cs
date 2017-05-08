using System;
using System.Collections.Generic;
using Foundation;
using WatchConnectivity;
using UIKit;


namespace Tahak
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            WCSessionManager.SharedManager.ApplicationContextUpdated += DidReceiveApplicationContext;
        }

        public override void ViewDidUnload()
        {
            base.ViewDidUnload();
            WCSessionManager.SharedManager.ApplicationContextUpdated -= DidReceiveApplicationContext;
        }

        public void DidReceiveApplicationContext(WCSession session, Dictionary<string, object> applicationContext)
        {
            var message = (string)applicationContext["MessageWatch"];
            if (message != null)
            {
                Console.WriteLine($"Application context update received : {message}");
                InvokeOnMainThread(() =>
                {
                    //label.Text = $"⌚️ : {message}";
                });
            }
        }

		partial void OnButtonPress(UIButton sender)
		{
            Console.WriteLine($"Odeslano: {text.Text}");

            WCSessionManager.SharedManager.UpdateApplicationContext(new Dictionary<string, object>() { { "MessagePhone", $"lol{text.Text}" } });
		}
    }
}
