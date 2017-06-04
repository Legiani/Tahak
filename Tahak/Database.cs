using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tahak
{
    /// <summary>
    /// Class with base conect/control comant do DB
    /// </summary>
	public class Database
	{
		private SQLiteAsyncConnection database;

		public Database()
		{
			FileHelper fh = new FileHelper();
			database = new SQLiteAsyncConnection(fh.GetLocalFilePath("TodoSQLite.db3"));
			database.CreateTableAsync<TahakClass>().Wait();
		}

        public Task<List<TahakClass>> GetItemsAsync()
		{
			return database.Table<TahakClass>().ToListAsync();
		}

		public Task<List<TahakClass>> GetItemsNotDoneAsync()
		{
			return database.QueryAsync<TahakClass>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
		}

        /// <summary>
        /// Gets the names.
        /// </summary>
        /// <returns>List mined from db</returns>
        public List<string> GetNames()
		{
            var ff = GetItemsAsync().Result;  
            List<string> subList = new List<string>();
            foreach (var item in ff)
            {
                subList.Add(item.Predmet);
            }
            return subList;
		}
        /// <summary>
        /// Gets the names.
        /// </summary>
        /// <returns>The names.</returns>
		public List<string> GetContents()
		{
			var ff = GetItemsAsync().Result;
			List<string> subList = new List<string>();
			foreach (var item in ff)
			{
                subList.Add(item.Obsah);
			}
			return subList;
		}

		public TahakClass GetItemAsync(string predmet)
		{
            
            TahakClass x = database.Table<TahakClass>().Where(i => i.Predmet == predmet).FirstOrDefaultAsync().Result;
            Console.WriteLine($"Juuu: {x}");
            return x;
		}

		public Task<int> SaveItemAsync(TahakClass item)
		{
			if (item.ID != 0)
			{
				return database.UpdateAsync(item);
			}
			else
			{
				return database.InsertAsync(item);
			}
		}

		public Task<int> DeleteItemAsync(TahakClass item)
		{
			return database.DeleteAsync(item);
		}
	}
}
