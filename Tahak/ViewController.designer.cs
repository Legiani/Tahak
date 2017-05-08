// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Tahak
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton send { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView text { get; set; }

        [Action ("OnButtonPress:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void OnButtonPress (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (send != null) {
                send.Dispose ();
                send = null;
            }

            if (text != null) {
                text.Dispose ();
                text = null;
            }
        }
    }
}