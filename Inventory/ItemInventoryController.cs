using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemInventoryController : MonoBehaviour
{
    Item item;
    public Button removeItemButton;
    public void removeItem()
    {
        try
        {
            InventoryManager.Instance.Remove(item);
            Destroy(gameObject);
        }
        catch (Exception)
        {

            throw;
        }
       
    }
    public void useItem()
    {
        switch (item.Type)
        {
            case Item.itemType.potion:
                print(item.name + " Used!");
                break;
            case Item.itemType.tool:
                print(item.name + " Used!");
                break;
            case Item.itemType.book:
                print(item.name + " Used!");
                break;
        }
        removeItem();
    }

    public void addItem(Item newItem)
    {
        item = newItem;
    }
}
