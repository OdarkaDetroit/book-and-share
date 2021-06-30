using BooksApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace WebApp.Services
{
    public class UsersBooksLikesService
    {
        private readonly IMongoCollection<UsersBooksLikes> _users;

        public UsersBooksLikesService(IUsersLikeCollectionName settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _likes = database.GetCollection<UsersBooksLikes>(settings.UsersLikeCollectionName);
        }


        public List<UsersBooksLikes> Get() =>
            _likes.Find(like => true).ToList();

        public User Get(string id) =>
            _likes.Find<UsersBooksLikes>(like => like.Id == id).FirstOrDefault();


        public User Create(UsersBooksLikes like)
        {
            _likes.InsertOne(like);
            return like;
        }


        public void Update(string id, UsersBooksLikes likeIn) =>
            _likes.ReplaceOne(like => like.Id == id, likeIn);

        public void Remove(UsersBooksLikes likeIn) =>
            _likes.DeleteOne(like => like.Id == likeIn.Id);

        public void Remove(string id) =>
            _likes.DeleteOne(like => like.Id == id);
    }
}