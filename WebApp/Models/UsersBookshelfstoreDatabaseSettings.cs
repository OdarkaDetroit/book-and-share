namespace WebApp.Models
{
    public class UsersBookshelfstoreDatabaseSettings : IUsersBookshelfstoreDatabaseSettings
    {
        public string UsersBookshelfCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IUsersBookshelfstoreDatabaseSettings
    {
        string UsersBookshelfCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}