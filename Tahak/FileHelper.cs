using System;
using System.IO;

namespace Tahak
{
    public class FileHelper
	{
        /// <summary>
        /// Metod to creat database in local storage
        /// </summary>
        /// <returns>The local file path.</returns>
        /// <param name="filename">Filename.</param>
        public string GetLocalFilePath(string filename)
		{
			string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

			if (!Directory.Exists(libFolder))
			{
				Directory.CreateDirectory(libFolder);
			}

            string derp = Path.Combine(libFolder, filename).ToString();
            return derp;
		}
	}
}