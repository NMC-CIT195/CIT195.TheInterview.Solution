using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT195.TheInterview.Solution
{
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


        #endregion


        #region FIELDS

        private string _name;
        private int _age;
        private GalacticRace _race;
        private bool _feelingPositive;
        private string _positiveGreeting;
        private string _negativeGreeting;   

        #endregion


        #region PROPERTIES

        public GalacticRace Race
        {
            get { return _race; }
            set { _race = value; }
        }
        

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public bool FeelingPositive
        {
            get { return _feelingPositive; }
            set { _feelingPositive = value; }
        }

        public string PositiveGreeting
        {
            get { return _positiveGreeting; }
            set { _positiveGreeting = value; }
        }
        public string NegativeGreeting
        {
            get { return _negativeGreeting; }
            set { _negativeGreeting = value; }
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

        public string Greeting()
        {
            if (_feelingPositive)
            {
                return _positiveGreeting;
            }
            else
            {
                return _negativeGreeting;
            }
        }

        #endregion
                       
    }
}
