using System;
using System.Collections.Generic;
using TreasureHunter.Interfaces;

namespace Models.TreasureHunter
{
    public class Boundary : IBoundary
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<IItem> Items { get; set; }
        public Dictionary<string, IBoundary> NeighborBoundaries { get; set; }

        public void AddNeighborBoundary(IBoundary neighbor, bool autoAdd)
        {
            //ask about this
        }

        public Boundary(string name, string description)
        {
            Name = name;
            Description = description;
            Items = new List<IItem>();
            NeighborBoundaries = new Dictionary<string, IBoundary>();
        }
    }
}