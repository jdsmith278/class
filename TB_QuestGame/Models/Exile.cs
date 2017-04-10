using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAionProject
{
    /// <summary>
    /// the character class the player uses in the game
    /// </summary>
    public class Exile : Character
    {
        #region ENUMERABLES
        public enum Weapon // enum beyond character class
        {
            None,
            Axe,
            Sword,
            Maul
        }

        #endregion

        #region FIELDS
        private int _experiencePoints;
        private int _health;
        private int _lives;
        public Weapon _weapons;
        private List<int> _atlasLocationsVisited;
        private List<TravelerObject> _inventory;

        #endregion

        #region PROPERTIES

        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set { _experiencePoints = value; }
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public int Lives
        {
            get { return _lives; }
            set { _lives = value; }
        }

        public Weapon WeaponType
        {
            get { return _weapons; }
            set { _weapons = value; }
        }

        public List<int> AtlasLocationsVisited
        {
            get { return _atlasLocationsVisited; }
            set { _atlasLocationsVisited = value; }
        }

        public List<TravelerObject> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }

        #endregion

        #region CONSTRUCTORS
                
        #endregion

        #region METHODS
        public bool HasVisited(int _atlasLocationID)
        {
            if (AtlasLocationsVisited.Contains(_atlasLocationID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Exile()
        {
            _atlasLocationsVisited = new List<int>();
            _inventory = new List<TravelerObject>();
        }

        public Exile(int name, FactionType race, int atlasLocationID) : base(name, race, atlasLocationID)
        {
            _atlasLocationsVisited = new List<int>();
            _inventory = new List<TravelerObject>();
        }


        //public Exile()
        //{
        //    _atlasLocationsVisited = new List<int>();
        //}

        //public Exile(int name, FactionType race, int atlasLocationID) : base(name, race, atlasLocationID) // should fix if improper page 12 referance guide sprint 2 did not contain 3 arguments
        //{
        //    _atlasLocationsVisited = new List<int>();
        //}


        #endregion
    }
}
