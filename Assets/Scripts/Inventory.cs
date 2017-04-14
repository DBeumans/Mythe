using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour 
{
	private Dictionary <Item.ItemType,List<Item>> inventory = new Dictionary<Item.ItemType,List<Item>>();

    private InventoryUI myInventoryUI;

    private List<string> itemName = new List<string>();
    public List<string> GetItemNames { get { return itemName; } }

    private void Start()
    {
        myInventoryUI = GetComponent<InventoryUI>();
        
    }
    public void AddItem (Item item)
	{
		if (!inventory.ContainsKey (item.Type))
		{
			inventory.Add (item.Type, new List<Item> ());
		}
		inventory[item.Type].Add(item);
        updateValues(item.Type);
    }

	public void updateValues(Item.ItemType type)
	{
        
        itemName.Clear();
        List<Item> items = GetAllItemsOfType(type);

        for (int i = 0; i < items.Count; i++)
        {
            itemName.Add(items[i].Name);  
        }
        myInventoryUI.updateUI(items.Count, type.ToString(), itemName);
    }

	public void removeItem(Item.ItemType itemType, string itemName)
	{
		for (int i = 0; i < inventory[itemType].Count; i++)
		{
			if (inventory[itemType][i].Name == itemName)
			{
				inventory[itemType].RemoveAt (i);
				break;
			}
		}
		updateValues (itemType);
	}
		
	public List<Item> GetAllItemsOfType(Item.ItemType type)
	{
	    return inventory[type];
	}
}
