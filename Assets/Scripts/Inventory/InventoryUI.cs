using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {

    private Inventory itemDatabase;

    [SerializeField]private GameObject inventoryPanel;
    [SerializeField]private GameObject slotPanel;
    [SerializeField]private GameObject inventorySlot;
    [SerializeField]private GameObject inventoryItem;

    private int totalSlots;

    private List<Item> items = new List<Item>();
    private List<GameObject> slots = new List<GameObject>();

    private void Start()
    {
        itemDatabase = GetComponent<Inventory>();

        totalSlots = 9;

        for (int i = 0; i < totalSlots; i++)
        {
            items.Add(new Item());
            slots.Add(Instantiate(inventorySlot));
            slots[i].transform.SetParent(slotPanel.transform);
            slots[i].transform.position = slotPanel.transform.position + new Vector3(0,0,-0.05f);
        }

        AddItem(0);
    }

    public void AddItem(int id)
    {
        Item itemToAdd = itemDatabase.FetchItemByID(id);
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ID == -1)
            {
                items[i] = itemToAdd;
                GameObject itemObject = Instantiate(inventoryItem);
                itemObject.transform.SetParent(slots[i].transform);
                itemObject.transform.position = slots[i].transform.position;
                itemObject.GetComponent<Image>().sprite = itemToAdd.Sprite;
                print("added");
                break;
            }
        }

    }
}
