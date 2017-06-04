using Foundation;
using System;
using UIKit;
using System.CodeDom.Compiler;

namespace Tahak
{
    partial class CustomCell : UITableViewCell
	{
        /// <summary>
        /// Help class to control designet Table Cell
        /// </summary>
        /// <param name="handle">Handle.</param>
		public CustomCell(IntPtr handle) : base(handle)
		{
		}
        public void UpdateCell(string nadps, string podps)
		{
            nad.Text = nadps;
            pod.Text = podps;
		}
	}
}