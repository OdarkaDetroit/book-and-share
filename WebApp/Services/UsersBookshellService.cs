using BooksApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace WebApp.Services
{
    public class UsersBookshellService
    {
        private readonly IMongoCollection<UsersBookshell> _shells;

        public UsersBookshellService(IUsersBookshelfstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _shells = database.GetCollection<Book>(settings.UsersBookshelfCollectionName);
        }


        public List<UsersBookshell> Get() =>
            _shells.Find(bookshell => true).ToList();

        public UsersBookshell Get(string id) =>
            _shells.Find<UsersBookshell>(bookshell => bookshell.Id == id).FirstOrDefault();


        public UsersBookshell Create(UsersBookshell bookshell)
        {
            _shells.InsertOne(bookshell);
            return bookshell;
        }


        public void Update(string id, UsersBookshell bookshellIn) =>
            _shells.ReplaceOne(bookshell => bookshell.Id == id, bookshellIn);

        public void Remove(UsersBookshell bookshellIn) =>
            _shells.DeleteOne(bookshell => bookshell.Id == bookshellIn.Id);

        public void Remove(string id) =>
            _shells.DeleteOne(bookshell => bookshell.Id == id);
    }
}