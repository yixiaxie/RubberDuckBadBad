
using UnityEngine;

public class PickupItem : MonoBehaviour
{

    public Item item;
    public LayerMask ItemLayer;

    private void OnMouseDown()
    {
        Debug.Log("Object has been clicked: " + gameObject.name);
        PickUp();
    }

    void PickUp()
    {
        if (item != null)  // 
        {
            Debug.Log("Picking up " + item.Itemname);
            bool wasPickedUp = Inventory.instance.Add(item);
            Debug.Log("wasPickedUp=" + wasPickedUp);
            if (wasPickedUp)
            {
                Destroy(gameObject);  // ;  // 
            }
        }
        else
        {
            Debug.Log("No item attached to this object.");
        }
    }
}
