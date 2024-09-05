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

    public void RemoveItem()
    {


        // 
        if (item != null)
        {
            int index = Inventory.instance.items.IndexOf(item);
            if (index >= 0)
            {
                Inventory.instance.RemoveItemAtIndex(index);
                string duckInfo = item.duckInfo;
                ChatGptManager chatGptManager = FindObjectOfType<ChatGptManager>();
                if (chatGptManager != null)
                {
                    //chatGptManager.AskChatGPT(duckInfo);
                }
                else
                {
                    Debug.LogError("ChatGptManager not found.");
                }
            }

            
        }
        else
        {
            Debug.LogWarning("nothing in this slot");
        }

    }
}
