using Foundation;
using System;
using UIKit;

namespace Tahak
{
    public partial class MainController : UIViewController
    {
        public MainController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
			// Perform any additional setup after loading the view, typically from a nib.
			base.ViewDidLoad();
            //DB Conect
            Database db = new Database();
            //Get contents of save data
            var tableItems = db.GetNames();
            //Fill table view
            Echo.Source = new TableSource(db.GetNames(), db.GetContents());
        }


        public override void ViewDidUnload()
        {
            base.ViewDidUnload();
		}


    }
}