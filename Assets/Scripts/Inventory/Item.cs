using UnityEngine;
using System.Collections;

public class Item
{
    /// <summary>
    /// Item ID.
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// Item Title.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Item Description.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Item Slug ( the item file name example : key_1 ).
    /// </summary>
    public string Slug { get; set; }

    /// <summary>
    /// Item Sprite.
    /// </summary>
    public Sprite Sprite { get; set; }
    
    /// <summary>
    /// Constructor to create a new item with parameters.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="title"></param>
    /// <param name="description"></param>
    /// <param name="slug"></param>
    public Item(int id, string title , string description, string slug)
    {
        this.ID = id;
        this.Title = title;
        this.Description = description;
        this.Slug = slug;
        this.Sprite = Resources.Load<Sprite>("Items/Sprites/" + slug);
    }

    /// <summary>
    /// Another constructor to create a new item but with no parameters so it will create a NULL item.
    /// </summary>
    public Item()
    {
        this.ID = -1;
    }
}
