using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using TheAionProject.Models; // !!Not a good way to do it!!

namespace TheAionProject
{
    /// <summary>
    /// controller for the MVC pattern in the application
    /// </summary>
    public class Controller : Exile
    {
        #region FIELDS

        private ConsoleView _gameConsoleView;
        private Exile _gameTraveler;
        private Atlas _gameWorld; // game universe
        private AtlasLocations _currentLocation;
        private bool _playingGame;

        #endregion


        #region CONSTRUCTORS

        public Controller()
        {
            //
            // setup all of the objects in the game
            //
            InitializeGame();

            //
            // begins running the application UI
            //
            ManageGameLoop();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize the major game objects
        /// </summary>
        private void InitializeGame()
        {
            _gameTraveler = new Exile();
            _gameWorld = new Atlas(); // game universe new universe
            _gameConsoleView = new ConsoleView(_gameTraveler, _gameWorld); // ADDED game universe
            _playingGame = true;

            //
            // add initial items to the traveler's inventory
            //
            _gameTraveler.Inventory.Add(_gameWorld.GetGameObjectById(8) as TravelerObject);
            _gameTraveler.Inventory.Add(_gameWorld.GetGameObjectById(9) as TravelerObject);

            Console.CursorVisible = false;
        }

        /// <summary>
        /// method to manage the application setup and game loop
        /// </summary>
        private void ManageGameLoop()
        {
            ExileAction travelerActionChoice = ExileAction.None;

            //
            // display splash screen
            //
            _playingGame = _gameConsoleView.DisplaySpashScreen();

            //
            // player chooses to quit
            //
            if (!_playingGame)
            {
                Environment.Exit(1);
            }

            //
            // display introductory message
            //
            _gameConsoleView.DisplayGamePlayScreen("Intro", Text.MissionIntro(), ActionMenu.MissionIntro, "");
            _gameConsoleView.GetContinueKey();

            //
            // initialize the mission traveler
            // 
            InitializeMission();

            //
            // prepare game play screen
            //

            _currentLocation = _gameWorld.GetSpaceTimeLocationByID(_gameTraveler.AtlasLocationsID);
            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");

            //_gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(), ActionMenu.MainMenu, ""); // bugged

            //
            // game loop
            //
            while (_playingGame)
            {
                //
                // process all flags, events, and stats
                //
                UpdateGameStatus();

                //
                // get next game action from player
                //
                if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.MainMenu)
                {
                    travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);
                }
                else if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.AdminMenu)
                {
                    travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.AdminMenu);
                }


                travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);

                //
                // choose an action based on the user's menu choice
                //
                switch (travelerActionChoice)
                {
                    case ExileAction.None:
                        break;

                    case ExileAction.ExileInfo:
                        _gameConsoleView.DisplayTravelerInfo();
                        break;

                    case ExileAction.LookAround:
                        _gameConsoleView.DisplayLookAround();
                        break;

                    case ExileAction.AtlasLocationsVisited:
                        _gameConsoleView.DisplayLocationsVistied();
                        break;

                    case ExileAction.LookAt:
                        LookAtAction();
                        break;

                    case ExileAction.PickUp:
                        PickUpAction();
                        break;

                    case ExileAction.PutDown:
                        PutDownAction();
                        break;
                        
                    case ExileAction.ListGameObjects:
                        _gameConsoleView.DisplayListOfAllGameObjects();
                        break;

                    case ExileAction.Exit:
                        _playingGame = false;
                        break;

                    case ExileAction.AdminMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.AdminMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Admin Menu", "Select an operation from the menu.", ActionMenu.AdminMenu, "");
                        break;

                    case ExileAction.ReturnToMainMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");
                        break;

                    case ExileAction.Inventory:
                        _gameConsoleView.DisplayInventory();
                        break;

                    default:
                        break;
                    case ExileAction.ListAtlasLocations:
                        _gameConsoleView.DisplayListOfAtlasLocations();
                        break;
                    case ExileAction.Travel:
                        //
                        //Display Locations visted method
                        //
                        _gameConsoleView.DisplayLocationsVistied();
                        //
                        //get new location choice and update the current location property
                        //
                        _gameTraveler.AtlasLocationsID = _gameConsoleView.DisplayGetNextAtlasLocation();
                        _currentLocation = _gameWorld.GetSpaceTimeLocationByID(_gameTraveler.AtlasLocationsID);

                        //
                        //set the game play screen to the curren location info format
                        //

                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");
                        break;
                }

            }

            //
            // close the application
            //
            Environment.Exit(1);
        }

        /// <summary>
        /// initialize the player info
        /// </summary>
        private void InitializeMission()
        {
            Exile traveler = _gameConsoleView.GetInitialTravelerInfo();

            _gameTraveler.Name = traveler.Name;
            _gameTraveler.Age = traveler.Age;
            _gameTraveler.Faction = traveler.Faction;
            _gameTraveler.WeaponType = traveler.WeaponType;
            _gameTraveler.AtlasLocationsID = 1;

            _gameTraveler.ExperiencePoints = -1000;
            _gameTraveler.Health = 50;
            _gameTraveler.Lives = 1;
        }

        private void UpdateGameStatus()
        {
            if (!_gameTraveler.HasVisited(_currentLocation.AtlasLocationID))
            {
                //
                // add new location to the list of visited locations if this is a first visit
                //
                _gameTraveler.AtlasLocationsVisited.Add(_currentLocation.AtlasLocationID);

                //
                // update experience points for visiting locations
                //

                _gameTraveler.ExperiencePoints += _currentLocation.ExperiencePoints;
            }
        }

        private void LookAtAction()
        {
            //
            // display a list of game objects in space-time location and get a player choice
            //
            int gameObjectToLookAtId = _gameConsoleView.DisplayGetGameObjectToLookAt();

            //
            // display game object info
            //
            if (gameObjectToLookAtId != 0)
            {
                //
                // get the game object from the universe
                //
                GameObject gameObject = _gameWorld.GetGameObjectById(gameObjectToLookAtId);

                //
                // display information for the object chosen
                //
                _gameConsoleView.DisplayGameObjectInfo(gameObject);
            }
        }

        private void PickUpAction()
        {
            //
            // display a list of traveler objects in space-time location and get a player choice
            //
            int travelerObjectToPickUpId = _gameConsoleView.DisplayGetTravelerObjectToPickUp();

            //
            // add the traveler object to traveler's inventory
            //
            if (travelerObjectToPickUpId != 0)
            {
                //
                // get the game object from the universe
                //
                TravelerObject travelerObject = _gameWorld.GetGameObjectById(travelerObjectToPickUpId) as TravelerObject;

                //
                // note: traveler object is added to list and the space-time location is set to 0
                //
                _gameTraveler.Inventory.Add(travelerObject);
                travelerObject.AtlasLocationId = 0;

                //
                // display confirmation message
                //
                _gameConsoleView.DisplayConfirmTravelerObjectAddedToInventory(travelerObject);
            }
        }

        private void PutDownAction()
        {
            //
            // display a list of traveler objects in inventory and get a player choice
            //
            int inventoryObjectToPutDownId = _gameConsoleView.DisplayGetInventoryObjectToPutDown();

            //
            // get the game object from the universe
            //
            TravelerObject travelerObject = _gameWorld.GetGameObjectById(inventoryObjectToPutDownId) as TravelerObject;

            //
            // remove the object from inventory and set the space-time location to the current value
            //
            _gameTraveler.Inventory.Remove(travelerObject);
            travelerObject.AtlasLocationId = _gameTraveler.AtlasLocationsID;

            //
            // display confirmation message
            //
            _gameConsoleView.DisplayConfirmTravelerObjectRemovedFromInventory(travelerObject);

        }

        #endregion
    }
}
