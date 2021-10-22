namespace RavenDB.Models
{
    public interface IEntity
    {
        public string Id { get; set; }
        public double Version { get; set; }
    }
}
