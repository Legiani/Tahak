using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Foundation;
using UIKit;
using WatchConnectivity;

namespace Tahak
{
    /// <summary>
    /// Class for comunication with storeyboard designet UI
    /// </summary>
    public class TableSource : UITableViewSource
    {
        List<string> tableItems = new List<string>();
        List<string> tableItemso = new List<string>();
        string cellIdentifier = "TableCell";


        public TableSource(List<string> items, List<string> itemso)
        {
            //titles
            tableItems = items;
            //contents
            tableItemso = itemso;
        }
        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return tableItems.Count;
        }
        /// <summary>
        /// Get stiled cells
        /// </summary>
        /// <returns>The cell.</returns>
        /// <param name="tableView">Table view.</param>
        /// <param name="indexPath">Index path.</param>
        public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(cellIdentifier) as CustomCell;
            if (cell != null)
            {
                cell.UpdateCell(tableItems[indexPath.Row],tableItemso[indexPath.Row]);
                return cell;
            }
            //
            return null;

        }
        /// <summary>
        /// Reaction to tap on item
        /// </summary>
        /// <param name="tableView">Table view.</param>
        /// <param name="indexPath">Index path.</param>
        public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
			Task.Factory.StartNew(async () =>
			{
				bool accepted = await ShowAlert(NSBundle.MainBundle.LocalizedString("UploadToWatch", ""), tableItems[indexPath.Row]);
				Console.WriteLine("Selected button {0}", accepted ? "Accepted" : "Canceled");
				if (accepted)
				{
					//DB conect and delete select item
					Database db = new Database();
					string s = tableItems[indexPath.Row];
					TahakClass item = db.GetItemAsync(s);

                    WCSessionManager.SharedManager.UpdateApplicationContext(new Dictionary<string, object>() { { "MessagePhone", item.Obsah } });
				}
			});

			tableView.DeselectRow(indexPath, true); // iOS convention is to remove the highlight
        }
        /// <summary>
        /// Reaction to switch "Delete"
        /// </summary>
        /// <param name="tableView">Table view.</param>
        /// <param name="editingStyle">Editing style.</param>
        /// <param name="indexPath">Index path.</param>
        public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, Foundation.NSIndexPath indexPath)
        {
            switch (editingStyle)
            {
                case UITableViewCellEditingStyle.Delete:

                    //DB conect and delete select item
					Database db = new Database();
                    string s = tableItems[indexPath.Row];
                    TahakClass item = db.GetItemAsync(s);
                    db.DeleteItemAsync(item);

					// remove the item from the underlying data source
					tableItems.RemoveAt(indexPath.Row);
					// delete the row from the table
					tableView.DeleteRows(new Foundation.NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade);
                    break;
                case UITableViewCellEditingStyle.None:
                    Console.WriteLine("CommitEditingStyle:None called");
                    break;
            }
        }
        /// <summary>
        /// Hepl class to show alert
        /// </summary>
        /// <returns>The alert.</returns>
        /// <param name="title">Title.</param>
        /// <param name="message">Message.</param>
		public Task<bool> ShowAlert(string title, string message)
		{
			var tcs = new TaskCompletionSource<bool>();

			UIApplication.SharedApplication.InvokeOnMainThread(new Action(() =>
			{
				UIAlertView alert = new UIAlertView(title, message, null, NSBundle.MainBundle.LocalizedString("Cancel", ""),
									NSBundle.MainBundle.LocalizedString("ToWatch", ""));
				alert.Clicked += (sender, buttonArgs) => tcs.SetResult(buttonArgs.ButtonIndex != alert.CancelButtonIndex);
				alert.Show();
			}));

			return tcs.Task;
		}

    }

}

