using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAionProject
{
    public class Atlas
    {
        #region ***** define all lists to be maintained by the Universe object *****

        //
        // list of all space-time locations
        //
        private List<AtlasLocations> _atlaslocations;

        public List<AtlasLocations> AtlasLocationsList
        {
            get { return _atlaslocations; }
            set { _atlaslocations = value; }
        }

        #endregion

        #region ***** constructor *****

        //
        // default Universe constructor
        //
        public Atlas()
        {
            //
            // add all of the universe objects to the game
            // 
            IntializeUniverse();
        }

        #endregion

        #region ***** define methods to initialize all game elements *****

        /// <summary>
        /// initialize the universe with all of the space-time locations
        /// </summary>
        private void IntializeUniverse()
        {
            _atlaslocations = WorldObjects.AtlasLocations as List<AtlasLocations>; //universeObjects as Universe Locations **as List<UniverseLocations>
        }

        #endregion

        #region ***** define methods to return game element objects and information *****

        public bool IsValidSpaceTimeLocationId(int spaceTimeLocationId)
        {
            List<int> spaceTimeLocationIds = new List<int>();

            //
            // create a list of space-time location ids
            //
            foreach (AtlasLocations stl in _atlaslocations)
            {
                spaceTimeLocationIds.Add(stl.AtlasLocationID);
            }

            //
            // determine if the space-time location id is a valid id and return the result
            //
            if (spaceTimeLocationIds.Contains(spaceTimeLocationId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// determine if a location is accessible to the player
        /// </summary>
        /// <param name="spaceTimeLocationId"></param>          /// COMMENTED OUT BECAUSE DOUBLE METHOD
        /// <returns>accessible</returns>
        /// 
        //////public bool IsAccessibleLocation(int spaceTimeLocationId)
        //////{
        //////    AtlasLocations spaceTimeLocation = GetSpaceTimeLocationByID(spaceTimeLocationId);
        //////    if (spaceTimeLocation.Accessable == true)
        //////    {
        //////        return true;
        //////    }
        //////    else
        //////    {
        //////        return false;
        //////    }
        //////}

        /// <summary>
        /// return the next available ID for a SpaceTimeLocation object
        /// </summary>
        /// <returns>next SpaceTimeLocationObjectID </returns>
        public int GetMaxSpaceTimeLocationId()
        {
            int MaxId = 0;

            foreach (AtlasLocations spaceTimeLocation in AtlasLocationsList)
            {
                if (spaceTimeLocation.AtlasLocationID > MaxId)
                {
                    MaxId = spaceTimeLocation.AtlasLocationID;
                }
            }

            return MaxId;
        }

        /// <summary>
        /// get a SpaceTimeLocation object using an ID
        /// </summary>
        /// <param name="ID">space-time location ID</param>
        /// <returns>requested space-time location</returns>
        public AtlasLocations GetSpaceTimeLocationByID(int ID)
        {
            AtlasLocations spaceTimeLocation = null;

            //
            // run through the space-time location list and grab the correct one
            //
            foreach (AtlasLocations location in _atlaslocations)
            {
                if (location.AtlasLocationID == ID)
                {
                    spaceTimeLocation = location;
                }
            }

            //
            // the specified ID was not found in the universe
            // throw and exception
            //
            if (spaceTimeLocation == null)
            {
                string feedbackMessage = $"The Space-Time Location ID {ID} does not exist in the current Universe.";
                throw new ArgumentException(ID.ToString(), feedbackMessage);
            }

            return spaceTimeLocation;
        }

        public bool isValidAtlasLocationId(int atlasLocationId)
        {
            List<int> atlasLocationIds = new List<int>();

            //
            // create a list of atlas location ids
            //
            foreach (AtlasLocations stl in _atlaslocations) // stl is SpaceTimeLocation
            {
                atlasLocationIds.Add(stl.AtlasLocationID);
            }
            //
            // determind if the atlas location id is a valid id and return the result
            //
            if (atlasLocationIds.Contains(atlasLocationId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public AtlasLocations getAtlasLocationById(int Id)
        {
            AtlasLocations atlasLocation = null;

            //
            // run through the atlas locatrion list and grab the correct one
            //

            foreach (AtlasLocations location in _atlaslocations)
            {
                if (location.AtlasLocationID == Id)
                {
                    atlasLocation = location;
                }
            }
            //
            // the specified ID was not found in the Atlas
            //throw exception
            //

            if (atlasLocation == null)
            {
                string feedbackMessage = $"The Atlas ID {Id} is unavailable.";
                throw new ArgumentException(Id.ToString(), feedbackMessage);
            }
            return atlasLocation;

        }

        public bool IsAccessibleLocation(int atlasLocationId)
        {
            AtlasLocations atlasLocation = getAtlasLocationById(atlasLocationId);
            if (atlasLocation.Accessable == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetMaxAtlasLocationId()
        {
            int MaxId = 0;
            foreach (AtlasLocations atlasLocation in _atlaslocations) // NEED TO DOUBLE CHECK THIS PAGE #9 ON HANDOUT
            {
                if (atlasLocation.AtlasLocationID > MaxId)
                {
                    MaxId = atlasLocation.AtlasLocationID;
                }

            }
            return MaxId;
        }







        #endregion
    }
}
