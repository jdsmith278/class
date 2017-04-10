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
        private List<GameObject> _gameObjects;

        public List<AtlasLocations> AtlasLocationsList
        {
            get { return _atlaslocations; }
            set { _atlaslocations = value; }
        }

        public List<GameObject> GameObjects
        {
            get { return _gameObjects; }
            set { _gameObjects = value; }
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
            _gameObjects = WorldObjects.gameObjects;
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

        public bool IsValidGameObjectByLocationId(int gameObjectId, int currentAtlasLocation)
        {
            List<int> gameObjectIds = new List<int>();

            //
            // create a list of game object ids in current space-time location
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.AtlasLocationId == currentAtlasLocation)
                {
                    gameObjectIds.Add(gameObject.Id);
                }

            }

            //
            // determine if the game object id is a valid id and return the result
            //
            if (gameObjectIds.Contains(gameObjectId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public GameObject GetGameObjectById(int Id)
        {
            GameObject gameObjectToReturn = null;

            //
            // run through the game object list and grab the correct one
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.Id == Id)
                {
                    gameObjectToReturn = gameObject;
                }
            }

            //
            // the specified ID was not found in the universe
            // throw and exception
            //
            if (gameObjectToReturn == null)
            {
                string feedbackMessage = $"The Game Object ID {Id} does not exist in the current World.";
                throw new ArgumentException(Id.ToString(), feedbackMessage);
            }

            return gameObjectToReturn;
        }

        public List<GameObject> GetGameObjectsBySpaceTimeLocationId(int atlasLocationId)
        {
            List<GameObject> gameObjects = new List<GameObject>();

            //
            // run through the game object list and grab all that are in the current space-time location
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.AtlasLocationId == atlasLocationId)
                {
                    gameObjects.Add(gameObject);
                }
            }

            return gameObjects;
        }

        public bool IsValidTravelerObjectByLocationId(int travelerObjectId, int currentSpaceTimeLocation)
        {
            List<int> travelerObjectIds = new List<int>();

            //
            // create a list of traveler object ids in current space-time location
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.AtlasLocationId == currentSpaceTimeLocation && gameObject is TravelerObject)
                {
                    travelerObjectIds.Add(gameObject.Id);
                }

            }

            //
            // determine if the game object id is a valid id and return the result
            //
            if (travelerObjectIds.Contains(travelerObjectId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<TravelerObject> GetTravelerObjectsBySpaceTimeLocationId(int spaceTimeLocationId)
        {
            List<TravelerObject> travelerObjects = new List<TravelerObject>();

            //
            // run through the game object list and grab all that are in the current space-time location
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.AtlasLocationId == spaceTimeLocationId && gameObject is TravelerObject)
                {
                    travelerObjects.Add(gameObject as TravelerObject);
                }
            }

            return travelerObjects;
        }


        #endregion
    }
}
