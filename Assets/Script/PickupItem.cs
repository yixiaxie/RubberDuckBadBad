
using UnityEngine;

public class PickupItem : MonoBehaviour
{

    public Item item;
    public LayerMask ItemLayer;
    public float pickupRange = 3f;

    //private void OnMouseDown()
    //{
    //    Debug.Log("Object has been clicked: " + gameObject.name);
    //    PickUp();
    //}


    private void Update()
    {
        // 
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E key pressed");
            // 
            if (IsPlayerInRange())
            {
                PickUp();
                Debug.Log("playerinrange");
            }
            else
            {
                Debug.Log("Player not in range");
            }
        }
    }

    bool IsPlayerInRange()
    {
        // 
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, pickupRange, ItemLayer);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                return true;
            }
        }

        return false;
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
