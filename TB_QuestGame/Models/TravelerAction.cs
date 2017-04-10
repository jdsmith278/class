using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAionProject
{
    /// <summary>
    /// enum of all possible player actions
    /// </summary>
    public enum ExileAction
    {
        None,
        ListGameObjects,  //
        AdminMenu,        //
        ReturnToMainMenu, //
        PickUp,           //
        PutDown,          //
        Inventory,        //
        MissionSetup,
        LookAround,
        LookAt,
        PickUpItem,
        PickUpTreasure,
        PutDownItem,
        PutDownTreasure,
        Travel,
        ExileInfo,
        ExileInventory,
        ExileTreasure,
        ListDestinations,
        AtlasLocationsVisited,
        ListAtlasLocations,
        ListItems,
        ListTreasures,
        Exit
    }
}
