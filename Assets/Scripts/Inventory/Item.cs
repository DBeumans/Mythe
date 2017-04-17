using UnityEngine;
using System.Collections;

public class Item
{
	private string name;
	public string Name { get { return name.ToLower (); } }

	private ItemType myType;
	public ItemType Type { get { return myType; } }


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


	public Item(string name)
	{
		this.name = name;
		this.myType = myType;
	}
}
