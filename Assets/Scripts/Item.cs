using UnityEngine;
using System.Collections;

public class Item
{
	private string name;
	public string Name
	{
		get 
		{
			return name.ToLower();
		}
	}
    public enum ItemType
    {
		Keys,
		Painting,
		Chair,
		Table,
		Door,
		Lamp,
		Air
    };

    private ItemType myType;
	public ItemType Type
	{
		get { return myType; }
	}

	public Item(string name, ItemType myType)
	{
		this.name = name;
		this.myType = myType;
	}
}
