using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System.IO;

public class Inventory : MonoBehaviour 
{
    private List<Item> database = new List<Item>();
    JsonData itemData;

    private void Start()
    {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
        MakeItemDatabase();

        Debug.Log(FetchItemByID(0).Description);
    }

    public Item FetchItemByID(int id)
    {
        for (int i = 0; i < database.Count; i++)
        {
            if (database[i].ID == id)
                return database[i];
        }
        return null;
    }

    public Item FetchItemByName(string name)
    {
        for (int i = 0; i < database.Count; i++)
        {
            if (database[i].Slug == name)
                return database[i];
        }
        return null;
    }

    private void MakeItemDatabase()
    {
        for (int i = 0; i < itemData.Count; i++)
        {
            database.Add(new Item((int)itemData[i]["id"], itemData[i]["title"].ToString(), itemData[i]["description"].ToString() , itemData[i]["slug"].ToString() ));
        }
    }
}
