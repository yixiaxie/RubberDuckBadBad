using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Item item;
    public Image icon;

    public void AddItem(Item newItem)
    {
        item = newItem;
        Debug.Log("AddItem" + item.Itemname);

        if (icon == null)
        {
            Debug.LogError("Icon is null in InventorySlot");
            return;
        }

        if (item.icon == null)
        {
            Debug.LogError("Item icon is null for: " + item.Itemname);
        }
        else
        {
            icon.sprite = item.icon;
            icon.enabled = true;
            Debug.Log("Item added: " + item.Itemname + ", Icon set.");
        }
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    //public void RemoveItem()
    //{
    //    Debug.Log("RemoveItem called.");
    //    if (item == null)
    //    {
    //        Debug.LogWarning("Item is null. Cannot proceed.");
    //        return;
    //    }
    //    // 
    //    if (item != null)
    //    {
    //        int index = Inventory.instance.items.IndexOf(item);
    //        if (index >= 0)
    //        {
    //            Inventory.instance.RemoveItemAtIndex(index);
    //            string duckInfo = item.duckInfo;
    //            Debug.Log("Duck info: " + duckInfo);
    //            ChatGptManager chatGptManager = FindObjectOfType<ChatGptManager>();
    //            if (chatGptManager != null)
    //            {
    //                chatGptManager.AskChatGPT(duckInfo);
    //            }
    //            else
    //            {
    //                Debug.LogError("ChatGptManager not found.");
    //            }
    //        }


    //    }
    //    else
    //    {
    //        Debug.LogWarning("nothing in this slot");
    //    }
    //  }

    public void RemoveItem()
    {
        Debug.Log("RemoveItem called.");

        if (item == null)
        {
            Debug.LogWarning("Item is null. Cannot proceed.");
            return;
        }

        // Check if the item exists in the inventory
        int index = Inventory.instance.items.IndexOf(item);
        if (index >= 0 && index < Inventory.instance.items.Count)
        {
            //GPT
            string duckInfo = item.duckInfo;
            Debug.Log("Duck info: " + duckInfo);
            
            ChatGptManager chatGptManager = FindObjectOfType<ChatGptManager>();
            if (chatGptManager != null)
            {
               // chatGptManager.AskChatGPT(duckInfo); 
            }
            else
            {
                Debug.LogError("ChatGptManager not found.");
            }

            Inventory.instance.RemoveItemAtIndex(index);

        }
        else
        {
            Debug.LogError("Item index out of range or item is not found in inventory.");
        }
    }


}
