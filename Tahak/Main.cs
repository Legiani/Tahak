using UIKit;

namespace Tahak
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }

        //Public db conect             
        private static Database _database;
        public static Database Database
		{
			get
			{
				if (_database == null)
				{
                    _database = new Database();
				}
				return _database;
			}
		}
    }
}
