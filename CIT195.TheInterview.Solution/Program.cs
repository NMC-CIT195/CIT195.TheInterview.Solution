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
        /// Control method for the application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //
            // instantiate (create) a player object
            //
            Player _myPlayer = new Player();

            InitializeConsoleWindow();

            DisplayWelcomeScreen();

            DisplayGetInitialInfo(_myPlayer);
            GetPlayersRace(_myPlayer);
            GetPlayersAge(_myPlayer);

            //DisplaySummary(_myPlayer);

            Console.ReadLine();
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

            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;

            Console.Write("                                                                                ");
            Console.Write("                          Spaceport Theta Processing                            ");
            Console.Write("                                                                                ");

            Console.ResetColor();

            Console.WriteLine();
        }

        /// <summary>
        /// Display the return prompt on the console
        /// </summary>
        private static void DisplayReturnPrompt()
        {
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

        /// 
        /// Display the opening screen on the console
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


        /// 
        /// Get the initial information from the player
        /// </summary>
        private static void DisplayGetInitialInfo(Player myPlayer)
        {
            DisplayNewScreenHeader();

            Console.WriteLine();
            Console.Write(" Please enter your name: ");
            myPlayer.Name = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine(" Private, Sargent, Lieutenant, Captain, Major, Colonel, General");
            Console.Write(" Please enter your rank: ");
            Player.ServiceRank rank;
            Enum.TryParse(Console.ReadLine(), out rank);
            myPlayer.Rank = rank;

            Console.WriteLine();
            Console.Write(" Is this your first mission? (YES or NO): ");
            string playerResponse;
            playerResponse = Console.ReadLine().Trim().ToUpper();
            if (playerResponse == "YES")
            {
                myPlayer.Rookie = true;
            }
            else
            {
                myPlayer.Rookie = false;
            }

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
        /// Display a summary of the processing
        /// </summary>
        //private static void DisplaySummary(Player myPlayer)
        //{
        //    DisplayNewScreenHeader();

        //    Console.WriteLine(" Name         : {0} {1} {2}", rank, firstName, lastName);
        //    Console.WriteLine();

        //    Console.Write(" Status       : ");
        //    if (rookie)
        //    {
        //        Console.WriteLine("Rookie");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Veteran");
        //    }

        //    Console.WriteLine(" Galactic Race: {0}", race);
        //    Console.WriteLine(" Age          : {0}", age);

        //    string weaponsList = "";
        //    if (playersNumWeapons != 0)
        //    {
        //        for (int weaponCount = 0; weaponCount <= MAX_NUM_WEAPONS - 1; weaponCount++)
        //        {
        //            weaponsList = weaponsList + weapons[weaponCount];
        //            if (weaponCount != MAX_NUM_WEAPONS - 1)
        //            {
        //                weaponsList = weaponsList + "     ";
        //            }
        //        }
        //    }
        //    else
        //    {
        //        weaponsList = "None";
        //    }
        //    Console.WriteLine(" Weapons      : {0}", weaponsList);
        //}

        /// <summary>
        /// Acquire player's race from enum options
        /// </summary>
        private static void GetPlayersRace(Player myPlayer)
        {
            string playerResponse;

            DisplayNewScreenHeader();

            Console.WriteLine(" Please enter one of the following races. ");
            Console.WriteLine();

            foreach (string raceType in Enum.GetNames(typeof(Player.GalacticRace)))
            {
                Console.WriteLine(" " + raceType);
            }

            Console.WriteLine();
            Console.Write(" Race: ");

            playerResponse = Console.ReadLine();
            myPlayer.Race = (Player.GalacticRace)Enum.Parse(typeof(Player.GalacticRace), playerResponse);

            DisplayReturnPrompt();

        }

        /// <summary>
        /// Acquire player's age in years
        /// </summary>
        private static void GetPlayersAge(Player myPlayer)
        {
            DisplayNewScreenHeader();

            Console.Write(" Please enter your age: ");
            myPlayer.Age = int.Parse(Console.ReadLine());

            if (myPlayer.Age > 80)
            {
                Console.WriteLine(" You are either in really good shape or are an Tradaian.");
            }

            DisplayReturnPrompt();
        }

        /// <summary>
        /// Acquire the player's weapon types
        /// </summary>
        //private static void GetPlayersWeapons()
        //{
        //    playersNumWeapons = -1;

        //    while (playersNumWeapons < 0 || playersNumWeapons > 3)
        //    {
        //        DisplayNewScreenHeader();

        //        Console.WriteLine(" You are allowed a maximum of three weapons on this mission. ");
        //        Console.WriteLine();
        //        Console.Write(" Please state the number of weapons you would like to carry: ");
        //        playersNumWeapons = int.Parse(Console.ReadLine());
        //    }

        //    if (playersNumWeapons == 0)
        //    {
        //        Console.WriteLine();
        //        Console.WriteLine(" No, weapons eh!? What, are you Chuck Norris or something?");
        //    }
        //    else
        //    {
        //        for (int weapon = 0; weapon <= playersNumWeapons - 1; weapon++)
        //        {
        //            Console.WriteLine();
        //            Console.Write(" Enter the name of weapon {0}: ", weapon + 1);
        //            weapons[weapon] = Console.ReadLine();
        //        }

        //        Console.WriteLine();
        //        Console.WriteLine(" You will be issued the following weapons:");
        //        for (int weapon = 0; weapon <= playersNumWeapons - 1; weapon++)
        //        {
        //            Console.Write(" [{0}] ", weapons[weapon]);
        //        }
        //        Console.WriteLine();
        //    }

        //    DisplayReturnPrompt();
        //}


    }
}
