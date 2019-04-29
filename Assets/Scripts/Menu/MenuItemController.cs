using HoloToolkit.Unity.InputModule;
using UnityEngine;
using HoloToolkitExtensions.Messaging;

public class MenuItemController : MonoBehaviour, IInputClickHandler {

    private TextMesh _textMesh;
    private IMenuItemData _menuItemData;

    public IMenuItemData MenuItemData
    {
        get { return _menuItemData; }
        set
        {
            if (_menuItemData == value)
            {
                return;
            }
            _menuItemData = value;
            _textMesh = GetComponentInChildren<TextMesh>();
            if(_menuItemData != null && _textMesh != null)
            {
                _textMesh.text = _menuItemData.Title;
            }
        }
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (MenuItemData != null)
        {
            Messenger.Instance.Broadcast(
                new MenuSelectedMessage { MenuItem = MenuItemData });
            
        }
        
    }
}
