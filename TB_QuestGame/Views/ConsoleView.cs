using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAionProject
{
    /// <summary>
    /// view class
    /// </summary>
    public class ConsoleView
    {

        public enum ViewStatus
        {
            ExileInitialization,
            PlayingGame
        }
        #region FIELDS

        //
        // declare game objects for the ConsoleView object to use
        //
        Exile _gameTraveler;
        Atlas _gameWorld; // game universe

        ViewStatus _viewStatus;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>
        public ConsoleView(Exile gameTraveler, Atlas gameWorld) // needed to give access to Universe "PARAMETER"
        {
            _gameTraveler = gameTraveler;
            _gameWorld = gameWorld; // game universe


            _viewStatus = ViewStatus.PlayingGame; // CHANGED FROM ExileInitialization to get Stats to show up!



            InitializeDisplay();


        }

        public void DisplayListOfAtlasLocations()
        {
            DisplayGamePlayScreen("List: Atlas Locations", Text.ListAllAtlasLocations
                (_gameWorld.AtlasLocationsList), ActionMenu.AdminMenu, "");  /// HAD MAIN MENU BEFORE //todo
        }

        #endregion

        #region METHODS
        /// <summary>
        /// display all of the elements on the game play screen on the console
        /// </summary>
        /// <param name="messageBoxHeaderText">message box header title</param>
        /// <param name="messageBoxText">message box text</param>
        /// <param name="menu">menu to use</param>
        /// <param name="inputBoxPrompt">input box text</param>
        public void DisplayGamePlayScreen(string messageBoxHeaderText, string messageBoxText, Menu menu, string inputBoxPrompt)
        {
            //
            // reset screen to default window colors
            //
            Console.BackgroundColor = ConsoleTheme.WindowBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.WindowForegroundColor;
            Console.Clear();

            ConsoleWindowHelper.DisplayHeader(Text.HeaderText);
            ConsoleWindowHelper.DisplayFooter(Text.FooterText);

            DisplayMessageBox(messageBoxHeaderText, messageBoxText);
            DisplayMenuBox(menu);
            DisplayInputBox();
            DisplayStatusBox();
        }

        /// <summary>
        /// wait for any keystroke to continue
        /// </summary>
        public void GetContinueKey()
        {
            Console.ReadKey();
        }

        /// <summary>
        /// get a action menu choice from the user
        /// </summary>
        /// <returns>action menu choice</returns>
        public ExileAction GetActionMenuChoice(Menu menu)
        {
            ExileAction choosenAction = ExileAction.None;
            Console.CursorVisible = false;

            //
            //create an array of valid keys from menu dictionary
            //
            char[] valuidKeys = menu.MenuChoices.Keys.ToArray();

            //
            //validate key pressed as in MenuChoices dictionary
            //
            char keyPressed;
            do
            {
                ConsoleKeyInfo keyPressedInfo = Console.ReadKey(true);
                keyPressed = keyPressedInfo.KeyChar;
            } while (!valuidKeys.Contains(keyPressed));

            choosenAction = menu.MenuChoices[keyPressed];
            Console.CursorVisible = true;

            return choosenAction;
        }

        /// <summary>
        /// get a string value from the user
        /// </summary>
        /// <returns>string value</returns>
        public string GetString()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// get an integer value from the user
        /// </summary>
        /// <returns>integer value</returns>
        private bool GetInteger(string prompt, int minimumValue, int maximumValue, out int integerChoice)
        {
            bool validResponse = false;
            integerChoice = 0;

            //
            // validate on range if either minimumValue and maximumValue are not 0
            //
            bool validateRange = (minimumValue != 0 || maximumValue != 0);

            DisplayInputBoxPrompt(prompt);
            while (!validResponse)
            {
                if (int.TryParse(Console.ReadLine(), out integerChoice))
                {
                    if (validateRange)
                    {
                        if (integerChoice >= minimumValue && integerChoice <= maximumValue)
                        {
                            validResponse = true;
                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                            DisplayInputBoxPrompt(prompt);
                        }
                    }
                    else
                    {
                        validResponse = true;
                    }
                }
                else
                {
                    ClearInputBox();
                    DisplayInputErrorMessage($"You must enter an integer value. Please try again.");
                    DisplayInputBoxPrompt(prompt);
                }
            }

            Console.CursorVisible = false;

            return true;
        }

        public void DisplayLocationsVistied()
        {
            //
            // generate a list of space time locations that have been visited
            //
            List<AtlasLocations> visitedAtlasLocations = new List<AtlasLocations>();
            foreach (int atlasLocationsId in _gameTraveler.AtlasLocationsVisited)
            {
                visitedAtlasLocations.Add(_gameWorld.GetSpaceTimeLocationByID(atlasLocationsId));
            }

            DisplayGamePlayScreen("Atlas Locations Visited Recently", Text.VisitedLocations(visitedAtlasLocations), ActionMenu.MainMenu, "");
        }

        /// <summary>
        /// get a character race value from the user
        /// </summary>
        /// <returns>character race value</returns>
        public Character.FactionType GetFaction()
        {
            Character.FactionType factionType;

            Enum.TryParse<Character.FactionType>(Console.ReadLine(), out factionType);

            return factionType;
        }
        //
        // get Weapon Type value from user
        //
        public Exile.Weapon GetWeaponType()
        {
            Exile.Weapon weapon;

            Enum.TryParse<Exile.Weapon>(Console.ReadLine(), out weapon);

            return weapon;
        }

        /// <summary>
        /// display splash screen
        /// </summary>
        /// <returns>player chooses to play</returns>
        public bool DisplaySpashScreen()
        {
            bool playing = true;
            ConsoleKeyInfo keyPressed;

            Console.BackgroundColor = ConsoleTheme.SplashScreenBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.SplashScreenForegroundColor;
            Console.Clear();
            Console.CursorVisible = false;


            Console.SetCursorPosition(0, 10);
            string tabSpace = new String(' ', 35);
            Console.WriteLine(tabSpace + @"                    _____     __   .__                   ");
            Console.WriteLine(tabSpace + @"                   /  _  \  _/  |_ |  |  _____     ______");
            Console.WriteLine(tabSpace + @"                  /  /_\  \ \   __\|  |  \__  \   /  ___/");
            Console.WriteLine(tabSpace + @"                 /    |    \ |  |  |  |__ / __ \_ \___ \ ");
            Console.WriteLine(tabSpace + @"                 \____|__  / |__|  |____/(____  //____  >");
            Console.WriteLine(tabSpace + @"                         \/                   \/      \/ ");
            Console.WriteLine();
            Console.WriteLine(tabSpace + @"                      C-sharp Major");
            //Console.WriteLine(tabSpace + @" _____ _              ___  _               ______          _           _   ");
            //Console.WriteLine(tabSpace + @"|_   _| |            / _ \(_)              | ___ \        (_)         | |  ");
            //Console.WriteLine(tabSpace + @"  | | | |__   ___   / /_\ \_  ___  _ __    | |_/ _ __ ___  _  ___  ___| |_ ");
            //Console.WriteLine(tabSpace + @"  | | | '_ \ / _ \  |  _  | |/ _ \| '_ \   |  __| '__/ _ \| |/ _ \/ __| __|");
            //Console.WriteLine(tabSpace + @"  | | | | | |  __/  | | | | | (_) | | | |  | |  | | | (_) | |  __| (__| |_ ");
            //Console.WriteLine(tabSpace + @"  \_/ |_| |_|\___|  \_| |_|_|\___/|_| |_|  \_|  |_|  \___/| |\___|\___|\__|");
            //Console.WriteLine(tabSpace + @"                                                         _/ |              ");
            //Console.WriteLine(tabSpace + @"                                                        |__/             ");

            Console.SetCursorPosition(80, 25);
            Console.Write("Press any key to continue or Esc to exit.");
            keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.Escape)
            {
                playing = false;
            }

            return playing;
        }

        /// <summary>
        /// initialize the console window settings
        /// </summary>
        private static void InitializeDisplay()
        {
            //
            // control the console window properties
            //
            ConsoleWindowControl.DisableResize();
            ConsoleWindowControl.DisableMaximize();
            ConsoleWindowControl.DisableMinimize();
            Console.Title = "Atlas";

            //
            // set the default console window values
            //
            ConsoleWindowHelper.InitializeConsoleWindow();

            Console.CursorVisible = false;
        }

        /// <summary>
        /// display the correct menu in the menu box of the game screen
        /// </summary>
        /// <param name="menu">menu for current game state</param>
        private void DisplayMenuBox(Menu menu)
        {
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuBorderColor;

            //
            // display menu box border
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MenuBoxPositionTop,
                ConsoleLayout.MenuBoxPositionLeft,
                ConsoleLayout.MenuBoxWidth,
                ConsoleLayout.MenuBoxHeight);

            //
            // display menu box header
            //
            Console.BackgroundColor = ConsoleTheme.MenuBorderColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 2, ConsoleLayout.MenuBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(menu.MenuTitle, ConsoleLayout.MenuBoxWidth - 4));

            //
            // display menu choices
            //
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            int topRow = ConsoleLayout.MenuBoxPositionTop + 3;

            foreach (KeyValuePair<char, ExileAction> menuChoice in menu.MenuChoices)
            {
                if (menuChoice.Value != ExileAction.None)
                {
                    string formatedMenuChoice = ConsoleWindowHelper.ToLabelFormat(menuChoice.Value.ToString());
                    Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 3, topRow++);
                    Console.Write($"{menuChoice.Key}. {formatedMenuChoice}");
                }
            }
        }

        /// <summary>
        /// display the text in the message box of the game screen
        /// </summary>
        /// <param name="headerText"></param>
        /// <param name="messageText"></param>
        private void DisplayMessageBox(string headerText, string messageText)
        {
            //
            // display the outline for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxBorderColor;
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MessageBoxPositionTop,
                ConsoleLayout.MessageBoxPositionLeft,
                ConsoleLayout.MessageBoxWidth,
                ConsoleLayout.MessageBoxHeight);

            //
            // display message box header
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBorderColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, ConsoleLayout.MessageBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(headerText, ConsoleLayout.MessageBoxWidth - 4));

            //
            // display the text for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            List<string> messageTextLines = new List<string>();
            messageTextLines = ConsoleWindowHelper.MessageBoxWordWrap(messageText, ConsoleLayout.MessageBoxWidth - 4);

            int startingRow = ConsoleLayout.MessageBoxPositionTop + 3;
            int endingRow = startingRow + messageTextLines.Count();
            int row = startingRow;
            foreach (string messageTextLine in messageTextLines)
            {
                Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, row);
                Console.Write(messageTextLine);
                row++;
            }

        }

        /// <summary>
        /// draw the input box on the game screen
        /// </summary>
        public void DisplayStatusBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            //
            // display the outline for the status box
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.StatusBoxPositionTop,
                ConsoleLayout.StatusBoxPositionLeft,
                ConsoleLayout.StatusBoxWidth,
                ConsoleLayout.StatusBoxHeight);

            //
            // display the text for the status box if playing game
            //
            if (_viewStatus == ViewStatus.PlayingGame)
            {
                //
                // display status box header with title
                //
                Console.BackgroundColor = ConsoleTheme.StatusBoxBorderColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
                Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 2, ConsoleLayout.StatusBoxPositionTop + 1);
                Console.Write(ConsoleWindowHelper.Center("Game Stats", ConsoleLayout.StatusBoxWidth - 4));
                Console.BackgroundColor = ConsoleTheme.StatusBoxBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;

                //
                // display stats
                //
                int startingRow = ConsoleLayout.StatusBoxPositionTop + 3;
                int row = startingRow;
                foreach (string statusTextLine in Text.StatusBox(_gameTraveler, _gameWorld))
                {
                    Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 3, row);
                    Console.Write(statusTextLine);
                    row++;
                }
            }
            else
            {
                //
                // display status box header without header
                //
                Console.BackgroundColor = ConsoleTheme.StatusBoxBorderColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
                Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 2, ConsoleLayout.StatusBoxPositionTop + 1);
                Console.Write(ConsoleWindowHelper.Center("", ConsoleLayout.StatusBoxWidth - 4));
                Console.BackgroundColor = ConsoleTheme.StatusBoxBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
            }
        }

        /// <summary>
        /// draw the input box on the game screen
        /// </summary>
        public void DisplayInputBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.InputBoxPositionTop,
                ConsoleLayout.InputBoxPositionLeft,
                ConsoleLayout.InputBoxWidth,
                ConsoleLayout.InputBoxHeight);
        }

        /// <summary>
        /// display the prompt in the input box of the game screen
        /// </summary>
        /// <param name="prompt"></param>
        public void DisplayInputBoxPrompt(string prompt)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 1);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.Write(prompt);
            Console.CursorVisible = true;
        }

        /// <summary>
        /// display the error message in the input box of the game screen
        /// </summary>
        /// <param name="errorMessage">error message text</param>
        public void DisplayInputErrorMessage(string errorMessage)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 2);
            Console.ForegroundColor = ConsoleTheme.InputBoxErrorMessageForegroundColor;
            Console.Write(errorMessage);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.CursorVisible = true;
        }

        /// <summary>
        /// clear the input box
        /// </summary>
        private void ClearInputBox()
        {
            string backgroundColorString = new String(' ', ConsoleLayout.InputBoxWidth - 4);

            Console.ForegroundColor = ConsoleTheme.InputBoxBackgroundColor;
            for (int row = 1; row < ConsoleLayout.InputBoxHeight - 2; row++)
            {
                Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + row);
                DisplayInputBoxPrompt(backgroundColorString);
            }
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
        }

        /// <summary>
        /// get the player's initial information at the beginning of the game
        /// </summary>
        /// <returns>traveler object with all properties updated</returns>
        public Exile GetInitialTravelerInfo()
        {
            Exile traveler = new Exile();

            //
            // intro
            //
            DisplayGamePlayScreen("Character Parameters ", Text.InitializeMissionIntro(), ActionMenu.MissionIntro, "");
            GetContinueKey();

            //
            // get traveler's name
            //
            DisplayGamePlayScreen("Character Parameters - Name", Text.InitializeMissionGetTravelerName(), ActionMenu.MissionIntro, "");
            int gameTravelerCitizenID;

            GetInteger($"Enter your Citizen ID: ", 10000, 99999, out gameTravelerCitizenID);
            traveler.Name = gameTravelerCitizenID;

            //
            // get traveler's age
            //
            DisplayGamePlayScreen("Character Parameters - Age", Text.InitializeMissionGetTravelerAge(traveler), ActionMenu.MissionIntro, "");
            int gameTravelerAge;

            GetInteger($"Enter your age, Citizen {traveler.Name}: ", 0, 7000, out gameTravelerAge);
            traveler.Age = gameTravelerAge;

            //
            // get traveler's faction
            //
            DisplayGamePlayScreen("Character Parameters - Diety", Text.InitializeMissionGetTravelerDiety(traveler), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt($"Where does your allegiance lie, {traveler.Name}?: ");
            traveler.Faction = GetFaction();

            //
            //get traveler's skill
            //
            DisplayGamePlayScreen("Character Parameters - Mastery", Text.InitializeMissionGetTravelerSkill(traveler), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt($"Select Mastery: ");
            traveler.WeaponType = GetWeaponType();
            //
            // echo the traveler's info
            //
            int YON;
            DisplayGamePlayScreen("Mission Initialization - Complete", Text.InitializeMissionEchoTravelerInfo(traveler), ActionMenu.MissionIntro, "");

            GetInteger($"Is this information correct, {traveler.Name}?\t(1. yes 2. no): ", 1, 2, out YON);
            if (YON == 2)
            {
                GetInitialTravelerInfo();
            }
            else
            {

            }

            return traveler;

        }

        public int DisplayGetNextAtlasLocation()
        {
            int atlasLocationId = 0;
            bool validAtlasLocationId = false;

            DisplayGamePlayScreen("Travel to a new Atlas location", Text.Travel(_gameTraveler, _gameWorld.AtlasLocationsList), ActionMenu.MainMenu, "");
            while (!validAtlasLocationId)
            {
                //
                // get int from player
                //

                GetInteger($"Enter your new location {_gameTraveler.Name}:", 1, _gameWorld.GetMaxSpaceTimeLocationId(), out atlasLocationId);

                //
                //validate integer as a valid aalas location id and determine access.
                //

                if (_gameWorld.isValidAtlasLocationId(atlasLocationId))
                {
                    if (_gameWorld.IsAccessibleLocation(atlasLocationId))
                    {
                        validAtlasLocationId = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("That location is inaccessible.");
                    }
                }
                else
                {
                    DisplayInputErrorMessage("Invalid location ID.");
                }
            }
            return atlasLocationId;
        }

        #region ----- display responses to menu action choices -----

        public void DisplayTravelerInfo()
        {

            AtlasLocations currentAtlasLocation = _gameWorld.getAtlasLocationById(_gameTraveler.AtlasLocationsID);
            DisplayGamePlayScreen($"{ _gameTraveler.Name} Information", Text.TravelerInfo(_gameTraveler, currentAtlasLocation), ActionMenu.MainMenu, "");
        }

        public void DisplayLookAround()
        {
            //
            // get current space-time location
            //
            AtlasLocations currentAtlasLocation = _gameWorld.getAtlasLocationById(_gameTraveler.AtlasLocationsID);

            //
            // get list of game objects in current space-time location
            //
            List<GameObject> gameObjectsInCurrentSpaceTimeLocation = _gameWorld.GetGameObjectsBySpaceTimeLocationId(_gameTraveler.AtlasLocationsID);

            string messageBoxText = Text.LookAround(currentAtlasLocation) + Environment.NewLine + Environment.NewLine;
            messageBoxText += Text.GameObjectsChooseList(gameObjectsInCurrentSpaceTimeLocation);

            DisplayGamePlayScreen("Current Location", messageBoxText, ActionMenu.MainMenu, "");
        }
        ///public void DisplayLookAround()
        // {
        //     int atlasLocationID = _gameTraveler.AtlasLocationsID;
        //     AtlasLocations currentAtlasLocation = _gameWorld.GetSpaceTimeLocationByID(atlasLocationID);

        //     DisplayGamePlayScreen("Current Location", Text.LookAround(currentAtlasLocation, ActionMenu.MainMenu, "")); // bugged
        // }

        #endregion

        public void DisplayListOfAllGameObjects()
        {
            DisplayGamePlayScreen("List: Game Objects", Text.ListAllGameObjects(_gameWorld.GameObjects), ActionMenu.AdminMenu, "");
        }

        public int DisplayGetGameObjectToLookAt()
        {
            int gameObjectId = 0;
            bool validGamerObjectId = false;

            //
            // get a list of game objects in the current space-time location
            //
            List<GameObject> gameObjectsInSpaceTimeLocation = _gameWorld.GetGameObjectsBySpaceTimeLocationId(_gameTraveler.AtlasLocationsID);

            if (gameObjectsInSpaceTimeLocation.Count > 0)
            {
                DisplayGamePlayScreen("Look at a Object", Text.GameObjectsChooseList(gameObjectsInSpaceTimeLocation), ActionMenu.MainMenu, "");

                while (!validGamerObjectId)
                {
                    //
                    // get an integer from the player
                    //
                    GetInteger($"Enter the Id number of the object you wish to look at: ", 0, 0, out gameObjectId);

                    //
                    // validate integer as a valid game object id and in current location
                    //
                    if (_gameWorld.IsValidGameObjectByLocationId(gameObjectId, _gameTraveler.AtlasLocationsID))
                    {
                        validGamerObjectId = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered an invalid game object id. Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Look at a Object", "It appears there are no game objects here.", ActionMenu.MainMenu, "");
            }

            return gameObjectId;
        }

        public void DisplayInventory()
        {
            DisplayGamePlayScreen("Current Inventory", Text.CurrentInventory(_gameTraveler.Inventory), ActionMenu.MainMenu, "");
        }

        public int DisplayGetTravelerObjectToPickUp()
        {
            int gameObjectId = 0;
            bool validGameObjectId = false;

            //
            // get a list of traveler objects in the current space-time location
            //
            List<TravelerObject> travelerObjectsInSpaceTimeLocation = _gameWorld.GetTravelerObjectsBySpaceTimeLocationId(_gameTraveler.AtlasLocationsID);

            if (travelerObjectsInSpaceTimeLocation.Count > 0)
            {
                DisplayGamePlayScreen("Pick Up Game Object", Text.GameObjectsChooseList(travelerObjectsInSpaceTimeLocation), ActionMenu.MainMenu, "");

                while (!validGameObjectId)
                {
                    //
                    // get an integer from the player
                    //
                    GetInteger($"Enter the Id number of the object you wish to add to your inventory: ", 0, 0, out gameObjectId);

                    //
                    // validate integer as a valid game object id and in current location
                    //
                    if (_gameWorld.IsValidTravelerObjectByLocationId(gameObjectId, _gameTraveler.AtlasLocationsID))
                    {
                        TravelerObject travelerObject = _gameWorld.GetGameObjectById(gameObjectId) as TravelerObject;
                        if (travelerObject.CanInventory)
                        {
                            validGameObjectId = true;
                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage("It appears you may not inventory that object. Please try again.");
                        }
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered an invalid game object id. Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Pick Up Game Object", "It appears there are no game objects here.", ActionMenu.MainMenu, "");
            }

            return gameObjectId;
        }

        public void DisplayConfirmTravelerObjectAddedToInventory(TravelerObject objectAddedToInventory)
        {
            DisplayGamePlayScreen("Pick Up Game Object", $"The {objectAddedToInventory.Name} has been added to your inventory.", ActionMenu.MainMenu, "");
        }

        public void DisplayConfirmTravelerObjectRemovedFromInventory(TravelerObject objectRemovedFromInventory)
        {
            DisplayGamePlayScreen("Put Down Game Object", $"The {objectRemovedFromInventory.Name} has been removed from your inventory.", ActionMenu.MainMenu, "");
        }

        public int DisplayGetInventoryObjectToPutDown()
        {
            int travelerObjectId = 0;
            bool validInventoryObjectId = false;

            if (_gameTraveler.Inventory.Count > 0)
            {
                DisplayGamePlayScreen("Put Down Game Object", Text.GameObjectsChooseList(_gameTraveler.Inventory), ActionMenu.MainMenu, "");

                while (!validInventoryObjectId)
                {
                    //
                    // get an integer from the player
                    //
                    GetInteger($"Enter the Id number of the object you wish to remove from your inventory: ", 0, 0, out travelerObjectId);

                    //
                    // find object in inventory
                    // note: LINQ used, but a foreach loop may also be used 
                    //
                    TravelerObject objectToPutDown = _gameTraveler.Inventory.FirstOrDefault(o => o.Id == travelerObjectId);

                    //
                    // validate object in inventory
                    //
                    if (objectToPutDown != null)
                    {
                        validInventoryObjectId = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered the Id of an object not in the inventory. Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Pick Up Game Object", "It appears there are no objects currently in inventory.", ActionMenu.MainMenu, "");
            }

            return travelerObjectId;
        }

        public void DisplayGameObjectInfo(GameObject gameObject)
        {
            DisplayGamePlayScreen("Current Location", Text.LookAt(gameObject), ActionMenu.MainMenu, "");
        }
        #endregion
    }
}
