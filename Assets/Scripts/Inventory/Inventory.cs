using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour 
{
    [SerializeField]private List<Item> inventory = new List<Item>();
	//private Dictionary <Item, int> inventory = new Dictionary<Item,int>();

    void Start()
    {
        Item test = new Item("test", Item.ItemType.Keys);
        Item test2 = new Item("test2", Item.ItemType.Keys);

        AddItem(test);
        AddItem(test2);
    }

    public void AddItem (Item item)
	{
		/*
		if (inventory.ContainsValue ())
		{
			Debug.Log ("Already registered.");
			return;
		}*/
		if (!inventory.Contains (item))
		{
			inventory.Add (item);
			Debug.Log ("Added new item " + item.Name);
            return;
		}
		inventory.Add(item);


        Debug.Log(inventory.Count);
        //updateValues(item);

    }
    /*
	public void updateValues(Item item)
	{
		List<Item> items = GetAllItemsOfType(item);
    }

	public void removeItem(Item item, string itemName)
	{
		for (int i = 0; i < inventory.Count; i++)
		{
			if (inventory[item] == itemName)
			{
				inventory.Remove(i);
				break;
			}
		}
		updateValues (item);
	}
		
	public List<Item> GetAllItemsOfType(Item type)
	{
	    return inventory[type];
	}
    */
}
