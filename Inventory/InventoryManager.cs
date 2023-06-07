using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> items = new List<Item>();

    public ItemInventoryController[] inventoryItems;
    public Transform itemContent;
    public GameObject inventoryItem;
    private void Awake()
    {
        Instance = this;
    }
    public void Add(Item item)
    {
        items.Add(item);
    }
    public void Remove(Item item)
    {
        try { items.Remove(item); } catch { throw; }
        
    }
    public void clear()
    {
        foreach (Transform item in itemContent) 
        {
            Destroy(item.gameObject);
        }
    }
    public void listItem()
    {
        foreach (Item item in items) 
        {
            GameObject obj = Instantiate(inventoryItem,itemContent);
            TextMeshProUGUI itemName =  obj.transform.Find("itemName").GetComponent<TextMeshProUGUI>();
            Image itemIcon = obj.transform.Find("itemIcon").GetComponent<Image>();
            GameObject removeButton = obj.transform.Find("RemoveButton").gameObject;

            itemName.text = item.name;
            itemIcon.sprite = item.ItemIcon;
        }
        setInventoryItem();
    }
    public void setInventoryItem()
    {
        inventoryItems = itemContent.GetComponentsInChildren<ItemInventoryController>();
        for (int i = 0; i < items.Count; i++)
        {
            inventoryItems[i].addItem(items[i]);
        }
    }
}
