using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]

public class Item : ScriptableObject
{
    public string Itemname = "New Item";
    public Sprite icon = null;
    public string duckInfo;
   
  



    public virtual void Use()
    {
        Debug.Log("using" + name);

    }

    

}
