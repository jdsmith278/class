using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAionProject
{
    /// <summary>
    /// static class to hold key/value pairs for menu options
    /// </summary>
    public static class ActionMenu
    {

        public enum CurrentMenu
        {
            MissionIntro,
            InitializeMission,
            MainMenu,
            AdminMenu
        }

        public static CurrentMenu currentMenu = CurrentMenu.MainMenu;

        public static Menu MissionIntro = new Menu()
        {
            MenuName = "MissionIntro",
            MenuTitle = "",
            MenuChoices = new Dictionary<char, ExileAction>()
                    {
                        { ' ', ExileAction.None }
                    }
        };

        public static Menu InitializeMission = new Menu()
        {
            MenuName = "InitializeMission",
            MenuTitle = "Initialize Mission",
            MenuChoices = new Dictionary<char, ExileAction>()
                {
                    { '1', ExileAction.Exit }
                }
        };

        public static Menu MainMenu = new Menu()
        {
            MenuName = "MainMenu",
            MenuTitle = "Main Menu",
            MenuChoices = new Dictionary<char, ExileAction>()
                {
                    { '1', ExileAction.ExileInfo },
                    { '2', ExileAction.LookAround},
                    { '3', ExileAction.LookAt },
                    { '4', ExileAction.PickUp},
                    { '5', ExileAction.PutDown},
                    { '6', ExileAction.Inventory},
                    { '7', ExileAction.Travel },
                    { '8', ExileAction.AtlasLocationsVisited },
                    { '9', ExileAction.ListAtlasLocations },
                    { 'a', ExileAction.ListGameObjects }, // no more numbers :) todo
                    { 'b', ExileAction.AdminMenu },
                    { '0', ExileAction.Exit }
                }
        };

        public static Menu AdminMenu = new Menu()
        {
            MenuName = "AdminMenu",
            MenuTitle = "Admin Menu",
            MenuChoices = new Dictionary<char, ExileAction>()
                {
                    { '1', ExileAction.ListAtlasLocations },
                    { '2', ExileAction.ListGameObjects},
                    { '3', ExileAction.ReturnToMainMenu }
                }
        };

        //public static Menu ManageTraveler = new Menu()
        //{
        //    MenuName = "ManageTraveler",
        //    MenuTitle = "Manage Traveler",
        //    MenuChoices = new Dictionary<char, PlayerAction>()
        //            {
        //                PlayerAction.MissionSetup,
        //                PlayerAction.TravelerInfo,
        //                PlayerAction.Exit
        //            }
        //};
    }
}
