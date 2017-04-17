using UnityEngine;
using System.Collections;

public class Item
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }
    public Sprite Sprite { get; set; }
    
    public Item(int id, string title , string description, string slug)
    {
        this.ID = id;
        this.Title = title;
        this.Description = description;
        this.Slug = slug;
        this.Sprite = Resources.Load<Sprite>("Items/Sprites/" + slug);
    }

    public Item()
    {
        this.ID = -1;
    }
}
