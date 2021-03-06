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
        
        /// 
        /// Get the initial information from the player
        /// </summary>
        private static void DisplayGetInitialInfo(Player myPlayer)
        {
            string playerResponse;

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
        /// Acquire player's race from enum options
        /// </summary>
        private static void DisplayGetPlayersRace(Player myPlayer)
        {
            string playerResponse;

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

            playerResponse = Console.ReadLine();
            myPlayer.Race = (Player.GalacticRace)Enum.Parse(typeof(Player.GalacticRace), playerResponse);

            DisplayReturnPrompt();

        }

        /// <summary>
        /// Acquire player's age in years
        /// </summary>
        private static void DisplayGetPlayersAge(Player myPlayer)
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
        /// Display a summary of the processing
        /// </summary>
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
    }
}
