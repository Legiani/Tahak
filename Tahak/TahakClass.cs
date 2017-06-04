using System;
using SQLite;

namespace Tahak
{
    /// <summary>
    /// Main class for control activity save/delete/send
    /// </summary>
    public class TahakClass
    {
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Predmet { get; set; }
        public DateTime Datum { get; set; }
        public string Obsah { get; set; }
    }
}
