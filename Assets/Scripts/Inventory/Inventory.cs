using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class Inventory : MonoBehaviour
{
    private List<Item> database = new List<Item>();
    private JsonData itemData;

    IEnumerator Start()
    {
        string jsonUrl = "http://13103.hosts.ma-cloud.nl/Mythe/Items.json";
        WWW www = new WWW(jsonUrl);
        yield return www;

        if (www.error == null) // no error
        {
            ProcessJsonFile(www.text);
        }
        else
        {
            Debug.LogError("ERROR: " + www.error);
        }
    }

    private void ProcessJsonFile(string jsonFile)
    {
        itemData = JsonMapper.ToObject(jsonFile);

        MakeItemDatabase();
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
