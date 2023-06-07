using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
   public Item Item;
    public void pickupItem()
    {
        InventoryManager.Instance.Add(Item);
        Destroy(gameObject);
    }
    private void OnMouseDown()
    {
        pickupItem();
    }

}
