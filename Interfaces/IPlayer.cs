using System.Collections.Generic;

namespace TreasureHunter.Interfaces
{
    public interface IPlayer
    {
        string Name { get; set; }
        List<IItem> Inventory { get; set; }
        // int HealthPoints { get; set; } //NOTE you might not use this but could be useful for extension ideas
    }
}