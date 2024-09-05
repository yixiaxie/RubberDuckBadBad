using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // Required for TextMeshPro components


public class DialogueManager : MonoBehaviour
{
    public Transform itemsParent;  // The parent object for the inventory buttons
    public GameObject duckButtonPrefab;  // The prefab for the duck buttons
    public TMP_Text npcDialogueText;  // Updated to use TMP_Text for TextMeshPro
    private InventoryManager inventoryManager;  // Reference to the InventoryManager

    void Start()
    {
        // Find the InventoryManager instance
        inventoryManager = InventoryManager.Instance;

        // Check if the InventoryManager is null (potential issue if not persisting across scenes)
        if (inventoryManager == null)
        {
            Debug.LogError("InventoryManager not found! Make sure it is persistent between scenes.");
            return;
        }

        // Populate the inventory with the ducks (items) from the InventoryManager
        PopulateInventory();
    }

    // This method populates the inventory UI with buttons for each collected duck (item)
    void PopulateInventory()
    {
        //debug the process and ensure that items are correctly transferred and buttons are created.
        Debug.Log("Populating Inventory...");

        foreach (Item item in inventoryManager.items)
        {
            Debug.Log("Found item: " + item.Itemname);
            // The rest of the code to create buttons...
        }


        // Clear previous items in the inventory panel (in case of scene reload)
        foreach (Transform child in itemsParent)
        {
            Destroy(child.gameObject);  // Remove any existing buttons
        }

        // Loop through the items in the inventory and create a button for each one
        foreach (Item item in inventoryManager.items)
        {
            if (item == null)
            {
                Debug.LogWarning("Item is null in the inventory list.");
                continue;
            }

            // Instantiate a new button using the duckButtonPrefab
            GameObject button = Instantiate(duckButtonPrefab, itemsParent);

            // Get the Text component of the button to set the item name
            TMP_Text buttonText = button.GetComponentInChildren<TMP_Text>();
            if (buttonText != null)
            {
                buttonText.text = item.Itemname;  // Display the item's name on the button
            }
            else
            {
                Debug.LogError("Button prefab is missing a TMP_Text component.");
            }

            // Add a listener to the button to call ShowDuckToNPC when clicked
            button.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => ShowDuckToNPC(item));
        }
    }

    // This method is called when a player clicks on a duck in the inventory
    public async void ShowDuckToNPC(Item item)
    {
        if (item == null)
        {
            Debug.LogWarning("The selected item is null.");
            return;
        }

        // Assuming ChatGptManager is properly set up and handles the GPT responses
        ChatGptManager chatGptManager = ChatGptManager.Instance;
        if (chatGptManager != null)
        {
            string npcResponse = await chatGptManager.AskChatGPT(item.duckInfo);  // Wait for the response
            npcDialogueText.text = npcResponse;  // Update the NPC's dialogue text with the response
        }
        else
        {
            Debug.LogError("ChatGptManager instance not found!");
        }
    }
}
