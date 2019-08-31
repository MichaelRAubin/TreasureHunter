using System;
using System.Collections.Generic;
using TreasureHunter.Interfaces;

namespace Models.TreasureHunter
{
    public class Player : IPlayer
    {
        public string Name { get; set; }
        public List<IItem> Inventory { get; set; }



        public Player(string name)
        {
            Name = name;
            Inventory = new List<IItem>();
        }
    }
}