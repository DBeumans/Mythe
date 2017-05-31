using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
using LitJson to decode json file.
*/
using LitJson;

public class Inventory : MonoBehaviour
{
    /// <summary>
    /// A List (array) to store all the items from an online JSON file.
    /// </summary>
    private List<Item> database = new List<Item>();

    /// <summary>
    /// 
    /// </summary>
    private JsonData itemData;

    /// <summary>
    /// Getting json file from online.
    /// </summary>
    /// <returns></returns>
    IEnumerator Start()
    {
        string jsonUrl = "http://13103.hosts.ma-cloud.nl/Mythe/Items.json";
        WWW www = new WWW(jsonUrl);
        yield return www;

        if (www.error == null) // no error
        {
            ProcessJsonFile(www.text);
            StopCoroutine(Start());
        }
        else
        {
            Debug.LogError("ERROR: " + www.error);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="jsonFile"></param>
    private void ProcessJsonFile(string jsonFile)
    {
        itemData = JsonMapper.ToObject(jsonFile);

        MakeItemDatabase();
    }

    /// <summary>
    /// Get a item from the database by item ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Item FetchItemByID(int id)
    {
        for (int i = 0; i < database.Count; i++)
        {
            if (database[i].ID == id)
                return database[i];
        }
        return null;
    }

    /// <summary>
    /// Get a item from the database by item name.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Item FetchItemByName(string name)
    {
        for (int i = 0; i < database.Count; i++)
        {
            if (database[i].Slug == name)
                return database[i];
        }
        return null;
    }

    /// <summary>
    /// Saving the items in the JSON file in the database list.
    /// </summary>
    private void MakeItemDatabase()
    {
        for (int i = 0; i < itemData.Count; i++)
        {
            database.Add(new Item((int)itemData[i]["id"], itemData[i]["title"].ToString(), itemData[i]["description"].ToString() , itemData[i]["slug"].ToString() ));
        }
        
    }
}
