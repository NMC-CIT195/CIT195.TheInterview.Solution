using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CIT195.TheInterview.Solution
{

    /// <summary>
    /// Application to interview the player and build-out their character
    /// </summary>
    class Program
    {
        /// <summary>
        /// Control method for the application flow
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //
            // instantiate (create) a player object
            //
            Player _myPlayer = new Player();
            _myPlayer.InitializePlayer();

            InitializeConsoleWindow();

            DisplayWelcomeScreen();

            DisplayGetInitialInfo(_myPlayer);
            DisplayGetPlayersRace(_myPlayer);
            DisplayGetPlayersAge(_myPlayer);
            DisplayGetPlayersWeapons(_myPlayer);
            DisplayGetPlayerBackpackItems(_myPlayer);

            DisplaySummary(_myPlayer);

            DisplayClosingScreen(_myPlayer);
        }

        #region CONSOLE DISPLAY UTILITIES

        /// <summary>
        /// Set the size of the console window
        /// </summary>
        private static void InitializeConsoleWindow()
        {
            Console.WindowWidth = 80;
            Console.WindowHeight = 20;
        }

        ///
        /// Display new screen with header
        /// <summary>
        private static void DisplayNewScreenHeader()
        {
            Console.Clear();

            //
            // turn the flashing cursor on
            //
            Console.CursorVisible = true;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;

            Console.Write("                                                                                ");
            Console.Write("                          Spaceport Theta Processing                            ");
            Console.Write("                                                                                ");

            Console.ResetColor();

            Console.WriteLine();
        }

        /// <summary>
        /// Display the return prompt
        /// </summary>
        private static void DisplayReturnPrompt()
        {
            //
            // turn the flashing cursor off
            //
            Console.CursorVisible = false;

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;

            Console.Write("                                                                                ");
            Console.Write("                     Press the (Enter) key to continue                          ");
            Console.Write("                                                                                ");

            Console.ResetColor();

            Console.ReadLine();
        }

        #endregion

        #region CONSOLE HELPER UTILITIES

        /// <summary>
        /// Get and validate the player response as a either a Yes or No value
        /// </summary>
        /// <returns>bool where yes equals true</returns>
        public static bool GetYesNoFromConsole()
        {
            string playerResponse;
            bool validRepsonse = false;
            bool yesResponse = false;

            while (!validRepsonse)
            {
                playerResponse = Console.ReadLine().Trim().ToUpper();

                if (playerResponse == "YES")
                {
                    yesResponse = true;
                    validRepsonse = true;
                }
                else if (playerResponse == "NO")
                {
                    yesResponse = false;
                    validRepsonse = true;
                }
                // user response not a yes or no
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(" It appears you have not entered a valid response.");
                    Console.Write(" Please enter a YES or NO.");
                }
            }

            return yesResponse;
        }

        /// <summary>
        /// Get validated integer based on a minimum and maximum value
        /// </summary>
        /// <param name="inputName">the text describing the desired input</param>
        /// <param name="minNumber">minimum value of input</param>
        /// <param name="maxNumber">maximum value of input</param>
        /// <returns>validated integer</returns>
        private static int GetIntegerFromConsole(string inputName, int minNumber, int maxNumber)
        {
            int userInteger = 0;
            string userResponse;
            bool validResponse = false;

            while (!validResponse)
            {
                userResponse = Console.ReadLine();

                if ((Int32.TryParse(userResponse, out userInteger)) && ((userInteger <= maxNumber) && (userInteger >= minNumber)))
                {
                    //
                    // User integer validated and stored in userInteger
                    //
                    validResponse = true;
                }
                // user input not an integer or out of range
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(" It appears you have entered an invalid {0}.", inputName);
                    Console.Write(" Please enter your {0} using a value between {1} and {2}.", inputName, minNumber, maxNumber);
                }
            }

            return userInteger;
        }

        #endregion

        #region CONSOLE DISPLAY METHODS

        /// 
        /// Display the opening screen
        /// </summary>
        private static void DisplayWelcomeScreen()
        {
            DisplayNewScreenHeader();

            Console.WriteLine(" Welcome to Spaceport Theta.");
            Console.WriteLine();
            Console.WriteLine(" We are glad that you have volunteered to help us in our fight to");
            Console.WriteLine(" reclaim the Galaxy from the Rashalian Hoard.");
            Console.WriteLine();
            Console.WriteLine(" To help you complete your first mission we need to know some information.");

            DisplayReturnPrompt();
        }


        /// <summary>
        /// Get the initial information from the player
        /// </summary>
        /// <param name="myPlayer">player object</param>
        private static void DisplayGetInitialInfo(Player myPlayer)
        {
            bool validResponse = false;
            string playerResponse;

            DisplayNewScreenHeader();

            Console.WriteLine();
            Console.Write(" Please enter your name: ");
            myPlayer.Name = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine(" Private, Sargent, Lieutenant, Captain, Major, Colonel, General");
            Console.Write(" Please enter your rank: ");
            Player.ServiceRank rank;

            //
            // validate player's choice of rank against the enum
            //
            playerResponse = Console.ReadLine();
            while (!validResponse)
            {
                if (Enum.TryParse(playerResponse, out rank))
                {
                    myPlayer.Rank = rank;
                    validResponse = true;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(" It appears you have not entered a valid rank.");
                    Console.WriteLine(" Please enter one of the ranks below exactly as it appears.");
                    Console.WriteLine(" Private, Sargent, Lieutenant, Captain, Major, Colonel, General");
                    Console.WriteLine();
                    Console.Write(" Please enter your rank: ");
                    playerResponse = Console.ReadLine();
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
            Console.Write(" Is this your first mission? (YES or NO): ");
            //
            // GetYesNoFromConsole() returns a bool where yes equal true
            //
            myPlayer.Rookie = GetYesNoFromConsole();

            Console.WriteLine();
            Console.WriteLine(" Welcome {0} {1}.", myPlayer.Rank, myPlayer.Name);

            if (myPlayer.Rookie == true)
            {
                Console.WriteLine(" It is a pleasure to have new blood in our ranks!");
            }
            else
            {
                Console.WriteLine(" It is a pleasure to have some experience in our ranks!");
            }

            DisplayReturnPrompt();
        }

        /// <summary>
        /// Acquire player's race from enum options
        /// </summary>
        /// <param name="myPlayer">player object</param>
        private static void DisplayGetPlayersRace(Player myPlayer)
        {
            string playerResponse;
            bool validResponse = false;
            Player.GalacticRace race;

            DisplayNewScreenHeader();

            Console.WriteLine(" Please enter one of the following races. ");
            Console.WriteLine();

            //
            // generate a list of race type names for user to choose from
            //
            foreach (string raceType in Enum.GetNames(typeof(Player.GalacticRace)))
            {
                Console.WriteLine(" " + raceType);
            }

            Console.WriteLine();
            Console.Write(" Race: ");

            //
            // validate player's choice of race against the enum
            //
            playerResponse = Console.ReadLine();
            while (!validResponse)
            {
                if (Enum.TryParse(playerResponse, out race))
                {
                    myPlayer.Race = race;
                    validResponse = true;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(" It appears you have not entered a valid race.");
                    Console.WriteLine(" Please enter one of the races below exactly as it appears.");

                    //
                    // generate a list of race type names for user to choose from
                    //
                    foreach (string raceType in Enum.GetNames(typeof(Player.GalacticRace)))
                    {
                        Console.WriteLine(" " + raceType);
                    }

                    Console.Write(" Please enter your race: ");
                    playerResponse = Console.ReadLine();
                    Console.WriteLine();
                }
            }

            DisplayReturnPrompt();

        }

        /// <summary>
        /// Acquire player's age in years
        /// </summary>
        /// <param name="myPlayer">player object</param>
        private static void DisplayGetPlayersAge(Player myPlayer)
        {
            DisplayNewScreenHeader();

            Console.Write(" Please enter your age: ");

            myPlayer.Age = GetIntegerFromConsole("age", 0, 200);

            if (myPlayer.Age > 80)
            {
                Console.WriteLine();
                Console.WriteLine(" You are either in really good shape or are an Tradaian.");
            }

            DisplayReturnPrompt();
        }

        /// <summary>
        /// Acquire the player's weapon types
        /// </summary>
        /// <param name="myPlayer">player object</param>
        private static void DisplayGetPlayersWeapons(Player myPlayer)
        {
            int playersNumWeapons = -1;

            DisplayNewScreenHeader();

            Console.WriteLine(" You are allowed a maximum of three weapons on this mission. ");
            Console.WriteLine();
            Console.Write(" Please state the number of weapons you would like to carry: ");
            playersNumWeapons = GetIntegerFromConsole("number of weapons", 0, 3);


            if (playersNumWeapons == 0)
            {
                Console.WriteLine();
                Console.WriteLine(" No, weapons eh!? What, are you Chuck Norris or something?");
            }
            else
            {
                for (int weapon = 0; weapon <= playersNumWeapons - 1; weapon++)
                {
                    Console.WriteLine();
                    Console.Write(" Enter the name of weapon {0}: ", weapon + 1);
                    myPlayer.Weapons[weapon] = Console.ReadLine();
                }

                Console.WriteLine();
                Console.WriteLine(" You will be issued the following weapons:");
                for (int weapon = 0; weapon <= playersNumWeapons - 1; weapon++)
                {
                    Console.Write(" [{0}] ", myPlayer.Weapons[weapon]);
                }
                Console.WriteLine();
            }

            DisplayReturnPrompt();
        }

        private static void DisplayGetPlayerBackpackItems(Player myPlayer)
        {
            bool done = false;
            bool addNewItem;

            DisplayNewScreenHeader();

            Console.WriteLine(" You are allowed some personal items in your backpack.");
            Console.WriteLine(" Please enter items one at a time when prompted.");
            Console.WriteLine(" You will be prompted on each time for Name, Description, and Count.");
            Console.WriteLine();

            //
            // Add items to the backpack
            //
            while (!done)
            {
                Console.Write(" Would you like to add an item to your backpack (Yes or No)");
                addNewItem = GetYesNoFromConsole();
                Console.WriteLine();

                //
                // Player would like an item added
                //
                if (addNewItem)
                {
                    //
                    // Instantiate a temporary item to hold the player's responses
                    //
                    Item newItem = new Item();

                    //
                    // Query player for item info
                    //
                    Console.Write(" Please enter an item name:");
                    newItem.Name = Console.ReadLine();

                    Console.Write(" Please enter the item's description:");
                    newItem.Description = Console.ReadLine();

                    Console.Write(" Please enter the number you will carry:");
                    newItem.Count = GetIntegerFromConsole("number of items", 1, 50);

                    Console.WriteLine();

                    //
                    // Add new item to the backpack list
                    //
                    myPlayer.Backpack.Add(newItem);

                    //
                    // set newItem to null to free memory
                    //
                    newItem = null;
                }
                //
                // Player is done adding items
                //
                else
                {
                    done = true;
                }
            }

            Console.WriteLine();

            //
            // list the items in the backpack
            //
            if (myPlayer.Backpack.Count != 0)
            {
                Console.WriteLine(" You have entered the following items in your backpack.");
                Console.WriteLine();

                foreach (Item item in myPlayer.Backpack)
                {
                    Console.WriteLine(" Item Name, Count: {0}, {1} units", item.Name, item.Count);
                    Console.WriteLine(" Item Description: {0}", item.Description);
                    Console.WriteLine();
                }
            }
            // no items in the backpack
            else
            {
                Console.WriteLine(" It appears you like to travel light.");
            }

            DisplayReturnPrompt();
        }

        /// <summary>
        /// Display a summary of the processing
        /// </summary>
        /// <param name="myPlayer">player object</param>
        private static void DisplaySummary(Player myPlayer)
        {
            string weaponsList = "";
            string backpackList = "";

            DisplayNewScreenHeader();

            Console.WriteLine();
            Console.WriteLine("We have the following information for you {0} {1}.", myPlayer.Rank, myPlayer.Name);
            Console.WriteLine();

            Console.Write(" Status       : ");
            if (myPlayer.Rookie)
            {
                Console.WriteLine("Rookie");
            }
            else
            {
                Console.WriteLine("Veteran");
            }

            Console.WriteLine(" Galactic Race: {0}", myPlayer.Race);
            Console.WriteLine(" Age          : {0}", myPlayer.Age);

            //
            // Build out and display weapons list
            //
            if (myPlayer.Weapons != null)
            {
                for (int weaponCount = 0; weaponCount <= Player.MAX_NUMBER_OF_WEAPONS - 1; weaponCount++)
                {
                    weaponsList = weaponsList + myPlayer.Weapons[weaponCount];
                    if (weaponCount != Player.MAX_NUMBER_OF_WEAPONS - 1)
                    {
                        weaponsList = weaponsList + "     ";
                    }
                }
            }
            else
            {
                weaponsList = "None";
            }
            Console.WriteLine(" Weapons      : {0}", weaponsList);

            //
            // build out and display the backpack list
            //
            if (myPlayer.Backpack.Count != 0)
            {
                foreach (Item item in myPlayer.Backpack)
                {
                    backpackList += item.Name + " ";
                }
            }
            // backpack empty
            else
            {
                backpackList = "Empty";
            }
            Console.WriteLine(" Backpack     : {0}", backpackList);

            DisplayReturnPrompt();
        }

        /// <summary>
        /// Display the Closing screen
        /// </summary>
        /// <param name="myPlayer">player object</param>
        private static void DisplayClosingScreen(Player myPlayer)
        {
            DisplayNewScreenHeader();

            Console.WriteLine(" Well {0} {1} it appears we are done here.", myPlayer.Rank, myPlayer.Name);
            Console.WriteLine();

            Console.WriteLine(myPlayer.InitialOrders());
            Console.WriteLine();

            Console.WriteLine(" Good Luck!");

            DisplayReturnPrompt();
        }

        #endregion
    }
}
