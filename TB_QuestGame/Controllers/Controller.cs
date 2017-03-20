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

                    case ExileAction.Exit:
                        _playingGame = false;
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

        #endregion
    }
}
