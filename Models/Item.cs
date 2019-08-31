using System;
using System.Collections.Generic;
using TreasureHunter.Interfaces;

namespace Models.TreasureHunter
{
    public class Item : IItem
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Item(string name, string description)
        {
            Name = name;
            Description = description;
        }

    }
}