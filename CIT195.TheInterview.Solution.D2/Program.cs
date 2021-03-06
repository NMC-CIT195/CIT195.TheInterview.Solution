﻿using System;
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

            InitializeConsoleWindow();

            DisplayWelcomeScreen();

            DisplayGetInitialInfo(_myPlayer);
            DisplayGetPlayersRace(_myPlayer);
            DisplayGetPlayersAge(_myPlayer);

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
        /// <returns>true equals yes</returns>
        public static bool GetYesNoResponse()
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
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(" It appears you have not entered a valid response.");
                    Console.Write(" Please enter a YES or NO.");
                }
            }

            return yesResponse;
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
                    Console.WriteLine();
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
            myPlayer.Rookie = GetYesNoResponse();

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
            string playerResponse;
            bool validResponse = false;
            int age;

            DisplayNewScreenHeader();

            Console.Write(" Please enter your age: ");

            //
            // Validate the player's response for age
            while (!validResponse)
            {
                playerResponse = Console.ReadLine();

                if ((Int32.TryParse(playerResponse, out age)) && ((age <= 200) && (age >= 21)))
                {
                    myPlayer.Age = age;
                    validResponse = true;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(" It appears you have not entered an invalid age.");
                    Console.Write(" Please enter your age in years using a value between 21 and 200.");
                }
            }

            if (myPlayer.Age > 80)
            {
                Console.WriteLine();
                Console.WriteLine(" You are either in really good shape or are an Tradaian.");
            }

            DisplayReturnPrompt();
        }


        /// <summary>
        /// Display a summary of the processing
        /// </summary>
        /// <param name="myPlayer">player object</param>
        private static void DisplaySummary(Player myPlayer)
        {
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
