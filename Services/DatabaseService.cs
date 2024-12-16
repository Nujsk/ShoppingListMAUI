using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpggiftMAUI.Models;

namespace UpggiftMAUI.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _connection;

        public DatabaseService()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "ShoppingList.db3");
            _connection = new SQLiteAsyncConnection(dbPath);

            _connection.CreateTableAsync<ShoppingItem>().Wait();
            _connection.CreateTableAsync<ShoppingList>().Wait();
        }
        public SQLiteAsyncConnection Connection => _connection;
    }
}
