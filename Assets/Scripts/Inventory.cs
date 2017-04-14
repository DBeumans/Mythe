using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour 
{
	private Dictionary <Item.ItemType,List<Item>> inventory = new Dictionary<Item.ItemType,List<Item>>();

    public void AddItem (Item item)
	{
		if (!inventory.ContainsKey (item.Type))
		{
			inventory.Add (item.Type, new List<Item> ());
			Debug.Log ("Added new type");
		}
		inventory[item.Type].Add(item);
        updateValues(item.Type);

    }

	public void updateValues(Item.ItemType type)
	{
        List<Item> items = GetAllItemsOfType(type);
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
