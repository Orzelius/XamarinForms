using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Authorizator.Data {
    public class UserDb {
        SQLiteAsyncConnection _database;

        public UserDb(string dbPath) {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
        }

        public Task<List<User>> GetAsync() {
            return _database.Table<User>().ToListAsync();
        }

        public Task<User> GetAsync(int id) {
            return _database.Table<User>()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveAsync(User note) {
            if (note.Id != 0) {
                return _database.UpdateAsync(note);
            }
            else {
                return _database.InsertAsync(note);
            }
        }

        public Task<int> DeleteAsync(User note) {
            return _database.DeleteAsync(note);
        }
    }

    public class User {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public  string Username { get; set; }
        public string Password { get; set; }

        public override string ToString() {
            return Username;
        }
    }
}
