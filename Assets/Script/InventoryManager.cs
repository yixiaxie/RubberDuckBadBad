using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<Item> items = new List<Item>(); // Changed Duck to Item

    private void Awake()
    {
        // Ensure only one instance exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object alive between scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(Item newItem)
    {
        items.Add(newItem); // Adjusted to match the type
    }
}
