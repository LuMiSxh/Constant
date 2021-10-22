using System.Collections.Generic;

namespace RavenDB.Models.Hitman
{
    // Interface for Weapon Perks
    public interface IPerks : IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string IconId { get; set; }
    }

    // Interface for creating Firearm Models
    public interface IFirearm: IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<IPerks> Perks { get; set; }
        public double SuccessRate { get; set; }
    }

    public class Firearm : IFirearm
    {
        public int Id { get; set; } = 1;

        public string Name { get; set; } = "Namee";
        public string Description { get; set; } = "Descriptiooooon";
        public List<IPerks> Perks { get; set; } = new List<IPerks>();
        public string ImageUrl { get; set; } = JsonHandler.E"Perks:Subsonic";
        public double SuccessRate { get; set; } = 0.1;
    }
}
