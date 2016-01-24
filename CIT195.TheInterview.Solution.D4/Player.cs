using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT195.TheInterview.Solution
{
    /// <summary>
    /// Player class for game
    /// </summary>
    public class Player
    {
        #region ENUMERABLES

        public enum GalacticRace
        {
            Human,
            Falandorian,
            Elatian,
            Zoggite,
            Unknown
        };

        public enum ServiceRank
        {
            Private,
            Sargent,
            Lieutenant,
            Captain,
            Major,
            Colonel,
            General
        }

        #endregion


        #region FIELDS
        public const int MAX_NUMBER_OF_WEAPONS = 3;

        private string _name;
        private int _age;
        private GalacticRace _race;
        private ServiceRank _rank;
        private bool _rookie;
        private string[] _weapons;
        private List<Item> _backpack;

        #endregion


        #region PROPERTIES

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public GalacticRace Race
        {
            get { return _race; }
            set { _race = value; }
        }

        public ServiceRank Rank
        {
            get { return _rank; }
            set { _rank = value; }
        }

        public bool Rookie
        {
            get { return _rookie; }
            set { _rookie = value; }
        }

        public string[] Weapons
        {
            get { return _weapons; }
            set { _weapons = value; }
        }

        public List<Item> Backpack
        {
            get { return _backpack; }
            set { _backpack = value; }
        }

        #endregion


        #region CONSTRUCTORS

        public Player()
        {

        }

        public Player(string name)
        {
            _name = name;
        }

        #endregion


        #region METHODS

        /// <summary>
        /// Initialize the player at the start of the game
        /// </summary>
        public void InitializePlayer()
        {
            _weapons = new string[MAX_NUMBER_OF_WEAPONS];
            _backpack = new List<Item>();
        }


        /// <summary>
        /// Determine the players initial orders once deployed
        /// </summary>
        /// <returns>string of new orders</returns>
        public string InitialOrders()
        {
            if (_rookie)
            {
                return " As a rookie, you will be required to attend the \n Army of the Republic's boot camp.";
            }
            else
            {
                return " As a veteran, you will be immediately assigned to \n the Cantor Regiment on the Front.";
            }
        }

        #endregion

    }
}
