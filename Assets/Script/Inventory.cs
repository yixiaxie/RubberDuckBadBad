using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }

    #endregion 

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public List<Item> items = new List<Item>();

    public int space = 10;

    public bool Add(Item item)
    {
        if (items.Count >= space)
        {
            Debug.Log("Not enough room");
            return false;

        }

        items.Add(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
            Debug.Log("Calling onItemChangedCallback...");
        }
        else
        {
            Debug.LogError("onItemChangedCallback is null.");
        }

        return true;


    }

    //public void Remove(Item item)

    //{
      //  items.Remove(item);

      //  if (onItemChangedCallback != null)
      //  {
       //     onItemChangedCallback.Invoke();
       // }
   // }

    public void RemoveItemAtIndex(int index)
    {
        if (index >= 0 && index < items.Count)
        {
            items.RemoveAt(index);

            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
        }
    }
}
