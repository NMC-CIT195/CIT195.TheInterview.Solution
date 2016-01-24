using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT195.TheInterview.Solution
{
    /// <summary>
    /// Class for backpack items
    /// </summary>
    public class Item
    {
        #region ENUMERABLES



        #endregion


        #region FIELDS

        private string _name;
        private string _description;
        private int _count;
        
        #endregion


        #region PROPERTIES
        
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        #endregion


        #region CONSTRUCTORS

        public Item()
        {

        }

        public Item(string name)
        {
            _name = name;
        }

        #endregion


        #region METHODS



        #endregion
    }
}
