using System;
using Models.TreasureHunter;

namespace TreasureHunter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Player player = new Player("Michael");
            Boundary boundary = new Boundary("Main", "You're in the Main Cavern.  It's dark, cold, and smells like sweaty gym socks!  You look around and notice that you can go in several different directions.  Collect items in the surrounding caves, and come back to this location to climb out of this cave.  Be careful!!");
            App app = new App();
            app.Player = player;
            app.Location = boundary;
            app.Setup();
            app.Run();
        }
    }
}
