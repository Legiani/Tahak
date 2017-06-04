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
			content.Placeholder = NSBundle.MainBundle.LocalizedString("Placeholder", "");

		}

        public override void ViewDidUnload()
        {
            base.ViewDidUnload();
			// Perform any additional setup after ulloading the view, typically from a nib.
			WCSessionManager.SharedManager.ApplicationContextUpdated -= DidReceiveApplicationContext;
        }

        public void DidReceiveApplicationContext(WCSession session, Dictionary<string, object> applicationContext)
        {
			// Update after recive data at runtime
            // Default traciver identificator
			var message = (string)applicationContext["MessageWatch"];
            if (message != null)
            {
                //Debug
                Console.WriteLine($"Application context update received : {message}");
                //Use recive data
                InvokeOnMainThread(() =>
                {
				    //label.Text = $"⌚️ : {message}";
				});
            }
        }

        /// <summary>
        /// ToWatch and save to database context
        /// </summary>
        /// <param name="sender">Sender.</param>
        partial void UIBarButtonItemrUK6T87x_Activated(UIBarButtonItem sender)
        {
			//
			// Share an image 
			//
			var item = UIActivity.FromObject("lolololol");
            var activityItems = new NSObject[] { item };
			var controller = new UIActivityViewController(activityItems, null);
            this.PresentViewController(controller, true, null);

			// 
			// Now share the image, but explicitly exclude posting as a message
			//
						controller = new UIActivityViewController(activityItems, null)
			{
				ExcludedActivityTypes = new NSString[] {
					UIActivityType.PostToWeibo,
					UIActivityType.Message,
                    UIActivityType.AirDrop,



				}
			};
            this.PresentViewController(controller, true, null);

            //Debug
            Console.WriteLine($"Odeslano: {text.Text}");
            //Create new instanc 
            TahakClass ts = new TahakClass();
	            ts.Obsah = text.Text;
	            ts.Predmet = content.Text;
	            ts.Datum = DateTime.Now.ToLocalTime();
            //Create database concet
            Database db = new Database();
            //Save new instanc
            db.SaveItemAsync(ts);
            //Send instance to watch
            WCSessionManager.SharedManager.UpdateApplicationContext(new Dictionary<string, object>() { { "MessagePhone", ts.Obsah } });

        }
    }
}
