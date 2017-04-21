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

    private GameObject[] itemSlots;

    private List<Item> items = new List<Item>();
    private List<GameObject> slots = new List<GameObject>();

    private void Awake()
    {
        itemDatabase = GetComponent<Inventory>();
        
        itemSlots = GameObject.FindGameObjectsWithTag("ItemSlot");
        Debug.Log(itemSlots.Length);

        for (int i = 0; i < itemSlots.Length; i++)
        {
            slots.Add(itemSlots[i]);
            items.Add(new Item());
        }

        
    }

    private void Start()
    {
       // AddItem(0);
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
                itemObject.GetComponent<SpriteRenderer>().sprite = itemToAdd.Sprite;
                print("added");
                break;
            }
        }

    }
}
