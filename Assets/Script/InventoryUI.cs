using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    Inventory inventory;
    InventorySlot[] slots;

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        UpdateUI();

    }

    void UpdateUI()
    {
        Debug.Log("Updating Inventory UI...");
        Debug.Log($"Slots length: {slots.Length}, Inventory items count: {inventory.items.Count}");

        // Iterate through the slots and update them based on the inventory items
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                // Add item to the slot if there is an item in the inventory
                slots[i].AddItem(inventory.items[i]);
                Debug.Log("additem_updatingui");
            }
            else
            {
                // Clear the slot if there is no item in the inventory for that slot
                slots[i].ClearSlot();
                Debug.Log("clearitem_updatingui");
            }
        }
    }

}
