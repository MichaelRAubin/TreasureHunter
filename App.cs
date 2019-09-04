using System;
using System.Collections.Generic;
using System.Threading;
using TreasureHunter.Interfaces;

namespace Models.TreasureHunter
{
    public class App : IApp
    {
        public IPlayer Player { get; set; }
        public IBoundary Location { get; set; }
        public bool Playing { get; set; }

        public void CaptureUserInput()
        {
            while (Playing)
            {
                Console.Clear();
                Console.Write("What do you want to do?  ");
                string userInput = Console.ReadLine().ToLower();
                string[] words = userInput.Split(' ');
                string command = words[0];
                string option = "";
                if (words.Length > 1)
                {
                    option = words[1];
                }
                switch (command)
                {
                    case "menu":

                        DisplayMenu();

                        break;

                    case "go":

                        ChangeLocation(option);

                        break;

                    case "take":

                        TakeItem(option);

                        break;

                    case "look":

                        DisplayRoomDescription();
                        Console.ReadLine();

                        break;

                    case "peek":

                        DisplayPlayerInventory();

                        break;

                    case "help":

                        DisplayHelpInfo();

                        break;

                    case "use":

                        UseItem(option);

                        break;

                    case "quit":

                        Console.Clear();
                        Console.Write("Are you sure want to quit?\nPress Y(es) or N(o)");
                        string quitResponse = Console.ReadLine().ToLower();
                        if (quitResponse == "y")
                        {
                            Console.Clear();
                            Console.WriteLine("Goodby!!");
                            Playing = false;
                        }
                        else if (quitResponse == "n")
                        {
                            Console.Clear();
                            DisplayMenu();
                        }
                        else
                        {
                            Console.Clear();
                            Console.Write("Please select (Y)es or (N)o.");
                            Console.ReadLine();
                        }
                        break;

                    default:
                        Console.WriteLine("I'm not sure what you mean");
                        break;
                }
            }

        }

        public void ChangeLocation(string locationName)
        {
            string firstLetter = locationName[0].ToString().ToUpper();
            locationName = firstLetter + locationName.Substring(1);
            if (Location.NeighborBoundaries.ContainsKey(locationName))
            {
                Location = Location.NeighborBoundaries[locationName];
                DisplayRoomDescription();
                if (Location.Name == "South")
                {
                    Console.WriteLine(@"You shimmy your way on your stomach through a tight tunnel into th south cave.  When you go to stand up
you bash your head on a low rock ceiling.  You stumble around in a daze and take a wrong step into a deep crevasse...aaaahhhhh");
                    Console.WriteLine("\n\nSorry your gone!!!");
                    Playing = false;
                }

            }
            else
            {
                Console.WriteLine("You can't go that way! You can only pass through the main cavern!!\n");
                Console.Write("Press Enter to continue");
            }
            Console.ReadLine();
        }

        public void DisplayHelpInfo()
        {
            Console.Clear();
            Console.WriteLine("More Information and Help\n\n");
            Console.WriteLine(@"This screen provides helpful information for playing and moving around in the game.  You can access this screen at any time by typing HELP.

To move around the caves simply type GO then the direction. For example GO WEST.  You can go MAIN, NORTH, SOUTH, EAST, or WEST.
One important note!  Everytime you want to explore another cave you must pass back through the main cave (HINT: GO MAIN).");
            Console.WriteLine("To go back the way you came simply type GO MAIN\n");
            Console.WriteLine(@"If you stumble across an item that you want to collect then type TAKE and then the name of the item.
For example, TAKE ROPE would add the rope to your backpack.");
            Console.WriteLine("");
            Console.WriteLine(@"Fortunately you came prepared with a backpack. 
When you want to see what's in your backpack simply type PEEK.
IMPORTANT NOTE - This is a good thing to check from time to time as you may find some helpful items.");
            Console.WriteLine("\nIf you wish to quit the game simply type QUIT at any time.\n");
            Console.WriteLine("To display the Main Menu simply type MENU at any time.\n");
            Console.Write("Press enter to continue");
            Console.ReadLine();

        }

        public void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("GAME MENU\n\n");
            Console.WriteLine("GO + Location -> moves you to a new location (e.g GO WEST).\n");
            Console.WriteLine("TAKE + Item -> picks up an item and adds it to your backpack (e.g. TAKE Rope).\n");
            Console.WriteLine("USE + Item -> takes an item from your backpack (e.g. USE Rope).\n");
            Console.WriteLine("LOOK -> shows the description of the current cave that you're in.\n");
            Console.WriteLine("PEEK -> shows the contents of your backpack.\n");
            Console.WriteLine("HELP -> displays help information.  Type this command at anytime for assistance.\n");
            Console.WriteLine("QUIT -> Ends the game.  Type this command at anytime to leave.\n");
            Console.Write("Press enter to continue");
            Console.ReadLine();
            Console.Clear();
        }



        public void DisplayPlayerInventory()
        {
            Console.Clear();
            Console.WriteLine("Here's what's in your Backpack\n");
            foreach (var Item in Player.Inventory)
            {
                Console.WriteLine($"{Item.Name}");

            }
            Console.WriteLine();
            Console.Write("Press enter to continue");
            Console.ReadLine();
        }

        public void DisplayRoomDescription()
        {
            Console.Clear();
            Console.WriteLine($"{Location.Description}\n");
        }

        public void Greeting()
        {
            Console.Clear();
            Console.WriteLine("Escape from Kuna Caves\n");
            Thread.Sleep(1000);
            Console.WriteLine(@"It's late on a Saturday night. You and several of your friends get a wild hair and decide to explore the Kuna Caves.
You head out first down the steep ladder into the main crevasse.  About half way down the ladder breaks and you tumble to the ground.
Fortunately you're not seriously hurt, however the ladder is now useless and you need to find a way to escape!  Your objective is to explore the
various caverns throughout the caves, and find whatever you can to help you climb to safety.  Once you've successfully found the items
you need, return to the main cavern to start your accent!!  WARNING...there may be pitfalls along the way!!");
            Thread.Sleep(1000);
            Console.WriteLine(" ");
            Console.WriteLine("Adventure awaits!  Do you want to go for it?\n");
            Console.Write("Press (N)o to leave or enter to continue.");
            string playResponse = Console.ReadLine().ToLower();
            if (playResponse == "n")
            {

                Console.Clear();
                Console.WriteLine("Goodby!!");
                Playing = false;
            }
            else
            {
                Console.Clear();
                DisplayMenu();
            }

        }

        public void Run()
        {
            Greeting();
            CaptureUserInput();
        }

        public void Setup()
        {
            Boundary north = new Boundary("North", "\nThe north cave is filled with hundreads of stalactites hanging from the ceiling.  Watch your head as you roam around this cave, and be careful not to step in anything!!");
            Boundary south = new Boundary("South", " ");
            Boundary east = new Boundary("East", "\nThe east cave is full of stalagmites.  Probably not the safest place to be.  You don't want to fall on any of those...they look awfully sharp!  Get out of this cave while you can!");
            Boundary west = new Boundary("West", "\nWatch your head!  The west cave has a low ceiling and is being supported by old dried out timbers on the side of the cave.  However, they look to be pretty secure from the ROPE that's holding them together.");

            Item rope = new Item("rope", "Rope for climbing");
            Item flashlight = new Item("flashlight", "Used for light");
            Item compass = new Item("compass", "Used for direction");



            west.Items.Add(rope);
            west.Items.Add(flashlight);
            west.Items.Add(compass);


            Location.Items.Add(flashlight);
            Location.Items.Add(compass);

            north.Items.Add(flashlight);
            north.Items.Add(compass);

            east.Items.Add(flashlight);
            east.Items.Add(compass);


            Location.NeighborBoundaries.Add(north.Name, north);
            north.NeighborBoundaries.Add(Location.Name, Location);
            Location.NeighborBoundaries.Add(south.Name, south);
            south.NeighborBoundaries.Add(Location.Name, Location);
            Location.NeighborBoundaries.Add(east.Name, east);
            east.NeighborBoundaries.Add(Location.Name, Location);
            Location.NeighborBoundaries.Add(west.Name, west);
            west.NeighborBoundaries.Add(Location.Name, Location);

            Player.Inventory.Add(flashlight);
            Player.Inventory.Add(compass);
        }

        public void TakeItem(string itemName)
        {
            IItem item = Location.Items.Find(i => i.Name.ToLower() == itemName);
            if (item is null)
            {
                Console.WriteLine("You typed in an invalid item");
                Console.Write("Press enter to continue");
                Console.ReadLine();
            }
            else
            {
                Location.Items.Remove(item);
                Player.Inventory.Add(item);
                Console.WriteLine($"You added a {itemName} to your backpack");
                Console.Write("Press enter to continue");
                Console.ReadLine();
            }

        }

        public void UseItem(string itemName)
        {
            IItem item = Player.Inventory.Find(i => i.Name.ToLower() == itemName);
            if (item is null)
            {
                Console.WriteLine("You typed in an invalid item");
                Console.Write("Press enter to continue");
                Console.ReadLine();
            }
            else if (itemName == "rope" && Location.Name == "Main")
            {
                Console.WriteLine("Throw it to your friends to pull you to safety!!\n");
                Console.Write("Press enter to continue\n");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Congratulations!  You Won!!");
                Playing = false;
            }
            else
            {
                Player.Inventory.Remove(item);
                Console.WriteLine($"You removed {itemName} from your backpack\n");
                Console.Write("Press enter to continue\n");
                Console.ReadLine();
            }

        }
        public App(bool playing = true)
        {
            Playing = playing;
        }

    }
}