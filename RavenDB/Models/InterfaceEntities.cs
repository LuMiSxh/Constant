namespace RavenDB.Models
{
    public interface IDBEntity
    {
        public string Id { get; set; }
        public double Version { get; set; }
    }

    public interface IEntity
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
    }
}
