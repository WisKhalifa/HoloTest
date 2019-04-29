using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoloMenuController : MonoBehaviour {

    // Use this for initialization
    void Start() {
        var builder = GetComponent<MenuBuilder>();
        IList<IMenuItemData> list = new List<IMenuItemData>();
        list.Add(new MenuItemData {
            Title = "Create a Graph",
            MenuId = 1,
            SelectMessageObject = new WorldCoordinate(27.91282f, 86.94221f)
        });
        list.Add(new MenuItemData {
            Title = "View Test Model",
            MenuId = 2,
            SelectMessageObject = new WorldCoordinate(27.91282f, 86.94221f)
        });
        list.Add(new MenuItemData {
            Title = "Help",
            MenuId = 3,
            SelectMessageObject = new WorldCoordinate(27.91282f, 86.94221f)
        });
        list.Add(new MenuItemData {
            Title = "Quit",
            MenuId = 4,
            SelectMessageObject = new WorldCoordinate(27.91282f, 86.94221f)
        });

        builder.MenuItems = list;
	}
	
	
}
