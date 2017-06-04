// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Tahak
{
    [Register ("CustomCell")]
    partial class CustomCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel nad { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel pod { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (nad != null) {
                nad.Dispose ();
                nad = null;
            }

            if (pod != null) {
                pod.Dispose ();
                pod = null;
            }
        }
    }
}