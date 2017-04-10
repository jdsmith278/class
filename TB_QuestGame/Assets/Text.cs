using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAionProject
{
    /// <summary>
    /// class to store static and to generate dynamic text for the message and input boxes
    /// </summary>
    public static class Text
    {
        public static List<string> HeaderText = new List<string>() { "Atlas" };
        public static List<string> FooterText = new List<string>() { "C-sharp Major, 2017" };

        #region INTITIAL GAME SETUP

        public static string MissionIntro()
        {
            string messageBoxText =
            "You've woken from a long sleep into a world completely new to you. \n" +
            "As you look around as bits of memory start trickling back. \n" +
            " \n" +
            "Who were you? \n" +
            "Your story begins now.\n" +
            " \n" +
            "\tPress the Esc key to exit the game at any point.\n" +
            "\n" +
            "\tPress any key to continue.\n";

            return messageBoxText;
        }

        public static string LookAround(AtlasLocations atlasLocation)
        {
            string messageBoxText =

                          $"Current Location: {atlasLocation.CommonName}\n" +
                          " \n" +
                        atlasLocation.GeneralContents;

            return messageBoxText;
        }

        #region Initialize Mission Text

        public static string InitializeMissionIntro()
        {
            string messageBoxText =
                "Now it's time to reflect on your place and purpose in this world.\n" +
                " \n" +
                "You will be prompted for information. Please enter the information below.\n" +
                " \n" +
                "\tPress any key to begin.";

            return messageBoxText;
        }

        public static string InitializeMissionGetTravelerName()
        {
            string messageBoxText =
                "Enter your 5 digit Citizen ID, exile.\n";

            //"Please use the name you wish to be referred during your mission.";

            return messageBoxText;
        }

        public static string InitializeMissionGetTravelerAge(Exile gameTraveler)
        {
            string messageBoxText =
                /*$"Very good then, we will call you {gameTraveler.Name} on this mission.\n"*/
                //" \n" +
                "Enter your age.\n" +
                " \n";
            //"Please use the standard Earth year as your reference.";

            return messageBoxText;
        }

        public static string InitializeMissionGetTravelerDiety(Exile gameTraveler)
        {
            string messageBoxText =
                $" Citizen {gameTraveler.Name}, what diety do you follow?\n" +
                " \n" +
                "Enter your faction below.\n" +
                " 0. Unaffiliated\n" +
                " 1. Crom\n" +
                " 2. Brokkr\n" +
                " 3. Hephaestus\n" +
                " \n";

            //string factionList = null;

            //foreach (Character.FactionType faction in Enum.GetValues(typeof(Character.FactionType)))
            //{
            //    if (faction != Character.FactionType.None)
            //    {
            //        factionList += $"\t{faction}\n";
            //    }
            //}

            /*messageBoxText += factionList*/
            ;

            return messageBoxText;
        }
        public static string InitializeMissionGetTravelerSkill(Exile gameTraveler)
        {
            string messageBoxText =
                $"What weapon did you master {gameTraveler.Name}?" +
                "\n" +
                "\n" +
                "\t 1. Axe\n" +
                "\t 2. Sword\n" +
                "\t 3. Maul\n";


            return messageBoxText;
        }

        public static string InitializeMissionEchoTravelerInfo(Exile gameTraveler)
        {
            string messageBoxText =
               $"{gameTraveler.Name}, is this information correct?\n" +
               "..if not, we will again reflect on your place and purpose in this world.\n" +
               //"It appears we have all the necessary data to begin your mission. You will find it" +
               //" listed below.\n" +
               " \n" +
               $"\tAlias: {gameTraveler.Name}\n" +
               $"\tAge: {gameTraveler.Age}\n" +
               $"\tDiety: {gameTraveler.Faction}\n" +
               $"\tMastery: {gameTraveler.WeaponType}\n"
              /* "Press any key to begin."*/;

            return messageBoxText;

        }

        #endregion

        #endregion

        #region MAIN MENU ACTION SCREENS

        public static string TravelerInfo(Exile gameTraveler, AtlasLocations currentLocation)
        {
            string messageBoxText =
                $"\t\t\t\t\t\t\t{gameTraveler.Name} Information\n" +
                $"\t\t\t\t\t______________________________________________\n" +
                $"\t\t\t\t\t\t\tAlias: {gameTraveler.Name}\n" +
                $"\t\t\t\t\t\t\tAge: {gameTraveler.Age}\n" +
                $"\t\t\t\t\t\t\tDiety: {gameTraveler.Faction}\n" +
                $"\t\t\t\t\t\t\tMastery: {gameTraveler.WeaponType}\n" +
                $"\t\t\t\t\t\t\tCurrent Location: {currentLocation.CommonName} \n\n";

            return messageBoxText;
        }

        public static string CurrentLocationInfo(AtlasLocations spaceTimeLocation)
        {
            string messageBoxText =
                $"Current Location: {spaceTimeLocation.CommonName}\n" +
                " \n" +
                spaceTimeLocation.Description;

            return messageBoxText;
        }

        public static string LookAroundID(AtlasLocations spaceTimeLocation)
        {
            string messageBoxText =
                $"Current Location: {spaceTimeLocation.CommonName}\n" +
                " \n" +
                spaceTimeLocation.GeneralContents;

            return messageBoxText;
        }

        public static string Travel(Exile gametraveler, List<AtlasLocations> spaceTimeLocations)
        {
            string messageBoxText =
                $"{gametraveler.Name}, touch the place on the Atlas you'd like to travel.\n" +
                " \n" +
                "Enter the ID number of your desired location from the table below.\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) + "Name".PadRight(30) + "Accessible".PadRight(10) + "\n" +
                "---".PadRight(10) + "----------------------".PadRight(30) + "-------".PadRight(10) + "\n";

            //
            // display all locations except the current location
            //
            string spaceTimeLocationList = null;
            foreach (AtlasLocations spaceTimeLocation in spaceTimeLocations)
            {
                if (spaceTimeLocation.AtlasLocationID != gametraveler.AtlasLocationsID)
                {
                    spaceTimeLocationList +=
                        $"{spaceTimeLocation.AtlasLocationID}".PadRight(10) +
                        $"{spaceTimeLocation.CommonName}".PadRight(30) +
                        $"{spaceTimeLocation.Accessable}".PadRight(10) +
                        Environment.NewLine;
                }
            }

            messageBoxText += spaceTimeLocationList;

            return messageBoxText;
        }

        public static string VisitedLocations(IEnumerable<AtlasLocations> spaceTimeLocations)
        {
            string messageBoxText =
                "Atlas Locations Visited\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) + "Name".PadRight(30) + "\n" +
                "---".PadRight(10) + "----------------------".PadRight(30) + "\n";

            //
            // display all locations
            //
            string atlasLocationsList = null;
            foreach (AtlasLocations atlasLocation in spaceTimeLocations)
            {
                atlasLocationsList +=
                    $"{atlasLocation.AtlasLocationID}".PadRight(10) +
                    $"{atlasLocation.CommonName}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += atlasLocationsList;

            return messageBoxText;
        }

        public static string ListAllAtlasLocations(IEnumerable<AtlasLocations> atlasLocations)
        {
            string messageBoxText =
                "Atlas Locations\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) + "Name".PadRight(30) + "\n" +
                "---".PadRight(10) + "--------------------".PadRight(30) + "\n";
            //
            //display all locations
            //

            string atlasLocationList = null;
            foreach (AtlasLocations atlasLocation in atlasLocations) // atlasLocation and atlasLocation"S" must be understood.
            {
                atlasLocationList +=
                    $"{atlasLocation.AtlasLocationID}".PadRight(10) +
                    $"{atlasLocation.CommonName}".PadRight(30) +
                    Environment.NewLine;
            }
            messageBoxText += atlasLocationList;

            return messageBoxText;
        }

        public static List<string> StatusBox(Exile exile, Atlas atlas)
        {
            List<string> statusBoxText = new List<string>();

            statusBoxText.Add($"Experience Points: {exile.ExperiencePoints}\n");
            statusBoxText.Add($"Health: {exile.Health}\n");
            statusBoxText.Add($"Lives: {exile.Lives}\n");

            return statusBoxText;
        }

        public static string ListAllGameObjects(IEnumerable<GameObject> gameObjects)
        {
            //
            // display table name and column headers
            //
            string messageBoxText =
                "Game Objects\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) +
                "Name".PadRight(30) +
                "Space-Time Location Id".PadRight(10) + "\n" +
                "---".PadRight(10) +
                "----------------------".PadRight(30) +
                "----------------------".PadRight(10) + "\n";

            //
            // display all traveler objects in rows
            //
            string gameObjectRows = null;
            foreach (GameObject gameObject in gameObjects)
            {
                gameObjectRows +=
                    $"{gameObject.Id}".PadRight(10) +
                    $"{gameObject.Name}".PadRight(30) +
                    $"{gameObject.AtlasLocationId}".PadRight(10) +
                    Environment.NewLine;
            }

            messageBoxText += gameObjectRows;

            return messageBoxText;
        }

        public static string LookAt(GameObject gameObject)
        {
            string messageBoxText = "";

            messageBoxText =
                $"{gameObject.Name}\n" +
                " \n" +
                gameObject.Description + " \n" +
                " \n";

            if (gameObject is TravelerObject)
            {
                TravelerObject travelerObject = gameObject as TravelerObject;

                messageBoxText += $"The {travelerObject.Name} has a value of {travelerObject.Value} and ";

                if (travelerObject.CanInventory)
                {
                    messageBoxText += "may be added to your inventory.";
                }
                else
                {
                    messageBoxText += "may not be added to your inventory.";
                }
            }
            else
            {
                messageBoxText += $"The {gameObject.Name} may not be added to your inventory.";
            }

            return messageBoxText;
        }

        public static string CurrentInventory(IEnumerable<TravelerObject> inventory)
        {
            string messageBoxText = "";

            //
            // display table header
            //
            messageBoxText =
            "ID".PadRight(10) +
            "Name".PadRight(30) +
            "Type".PadRight(10) +
            "\n" +
            "---".PadRight(10) +
            "----------------------------".PadRight(30) +
            "----------------------".PadRight(10) +
            "\n";

            //
            // display all traveler objects in rows
            //
            string inventoryObjectRows = null;
            foreach (TravelerObject inventoryObject in inventory)
            {
                inventoryObjectRows +=
                    $"{inventoryObject.Id}".PadRight(10) +
                    $"{inventoryObject.Name}".PadRight(30) +
                    $"{inventoryObject.Type}".PadRight(10) +
                    Environment.NewLine;
            }

            messageBoxText += inventoryObjectRows;

            return messageBoxText;
        }

        public static string GameObjectsChooseList(IEnumerable<GameObject> gameObjects)
        {
            //
            // display table name and column headers
            //
            string messageBoxText =
                "Game Objects\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) +
                "Name".PadRight(30) + "\n" +
                "---".PadRight(10) +
                "----------------------".PadRight(30) + "\n";

            //
            // display all traveler objects in rows
            //
            string gameObjectRows = null;
            foreach (GameObject gameObject in gameObjects)
            {
                gameObjectRows +=
                    $"{gameObject.Id}".PadRight(10) +
                    $"{gameObject.Name}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += gameObjectRows;

            return messageBoxText;
        }

        #endregion
        //
        // "traveler" version
        //

        //public static List<string> StatusBox(Exile traveler, Atlas universe)
        //{
        //    List<string> statusBoxText = new List<string>();

        //    statusBoxText.Add($"Experience Points: {traveler.ExperiencePoints}\n");
        //    statusBoxText.Add($"Health: {traveler.Health}\n");
        //    statusBoxText.Add($"Lives: {traveler.Lives}\n");

        //    return statusBoxText;
        //}
    }
}


//        internal static string LookAround()
//        {
//            throw new NotImplementedException();
//        }

//public static string CurrentLocationInfo()
//        {
//            string messageBoxText =
//                   "Here I am!"; 

//                   return messageBoxText;
//        }

//        #endregion
//    }
//}
