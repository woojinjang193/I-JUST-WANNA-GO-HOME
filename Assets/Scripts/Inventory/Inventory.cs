using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    [SerializeField] private InputActionReference OpenInventoryKey;
    [SerializeField] private GameObject inventory;

    private bool isInventoryOpen = false;

    void OnEnable()
    {
        OpenInventoryKey.action.started += OpenInventory;
        OpenInventoryKey.action.Enable();
    }

    void OnDisable()
    {
        OpenInventoryKey.action.started -= OpenInventory;
        OpenInventoryKey.action.Disable();
    }

    private void OpenInventory(InputAction.CallbackContext context) //Tab 키
    {
        isInventoryOpen = !isInventoryOpen;

        if (!isInventoryOpen)
        {
            RefreshInventory();
            inventory.SetActive(true);
        }
        else if (isInventoryOpen)
        {
            inventory.SetActive(false);
        }
    }

    private void RefreshInventory()
    {
        Debug.Log("인벤토리 초기화");
    }
}
