using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAionProject
{
    /// <summary>
    /// class for the game map locations
    /// </summary>
    public class AtlasLocations
    {
        #region FIELDS

        private string _commonName;
        private int _AtlasLocationsID; // must be a unique value for each object  EVERYTHING WILL HAVE AN ID
        private int _universalDate;
        private string _universalLocation;
        private string _description; // general descript
        private string _generalContents; // Look around
        private bool _accessable;
        private int _experiencePoints;

        #endregion


        #region PROPERTIES

        public string CommonName
        {
            get { return _commonName; }
            set { _commonName = value; }
        }

        public int AtlasLocationID
        {
            get { return _AtlasLocationsID; }
            set { _AtlasLocationsID = value; }
        }

        public int UniversalDate
        {
            get { return _universalDate; }
            set { _universalDate = value; }
        }

        public string UniversalLocation
        {
            get { return _universalLocation; }
            set { _universalLocation = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string GeneralContents
        {
            get { return _generalContents; }
            set { _generalContents = value; }
        }

        public bool Accessable
        {
            get { return _accessable; }
            set { _accessable = value; }
        }

        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set { _experiencePoints = value; }
        }
           
        #endregion


        #region CONSTRUCTORS



        #endregion


        #region METHODS



        #endregion


    }
}
