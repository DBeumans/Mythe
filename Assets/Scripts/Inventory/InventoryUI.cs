﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{

    private Inventory itemDatabase;

    [SerializeField]
    private GameObject inventoryPanel;
    [SerializeField]
    private GameObject slotPanel;
    [SerializeField]
    private GameObject inventorySlot;
    [SerializeField]
    private GameObject inventoryItem;


    private List<Item> items = new List<Item>();
    private List<GameObject> slots = new List<GameObject>();

    private List<GameObject> itemSlots = new List<GameObject>();

    private void Awake()
    {
        itemDatabase = GetComponent<Inventory>();

        // itemSlots = GameObject.FindGameObjectsWithTag("ItemSlot");


        foreach (GameObject item in GameObject.FindGameObjectsWithTag("ItemSlot").OrderBy(name => name.name))
        {
            itemSlots.Add(item);
        }


        Debug.Log(itemSlots.Count);

        for (int i = 0; i < itemSlots.Count - 1; i++)
        {
            items.Add(new Item());
            slots.Add(itemSlots[i]);

        }


    }

    private void Start()
    {
        AddItemByID(0);
        //AddItemByName("key_2");
    }

    public void AddItemByID(int id)
    {
        Item item = itemDatabase.FetchItemByID(id);
        loopThroughItems(item);
    }
    public void AddItemByName(string name)
    {
        Item item = itemDatabase.FetchItemByName(name);
        loopThroughItems(item);
    }

    private void loopThroughItems(Item itemToAdd)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ID == -1)
            {
                items[i] = itemToAdd;
                GameObject itemObject = Instantiate(inventoryItem);
                itemObject.transform.SetParent(slots[i].transform);
                itemObject.transform.position = slots[i].transform.position;
                itemObject.GetComponent<SpriteRenderer>().sprite = itemToAdd.Sprite;
                itemObject.name = itemToAdd.Title;
                break;
            }
        }
    }
}