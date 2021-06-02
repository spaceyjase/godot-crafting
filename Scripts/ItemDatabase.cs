using Godot;
using System.Collections.Generic;

public class ItemDatabase : Node     // TODO: resource
{
    private readonly List<Item> items = new List<Item>();

    public ItemDatabase()
    {
        BuildItemDatabase();
    }

    public Item GetItem(int id)
    {
        return items.Find(item => item.Id == id);
    }
 
    public Item GetItem(string title)
    {
        return items.Find(item => item.Title == title);
    }

    private void BuildItemDatabase()
    {
        foreach (var resource in ResourceGrabber.GetResources("res://Resources/Items/"))
        {
            if (!(resource is Item item)) continue;
            
            items.Add(item);
            GD.Print($"Loaded item: {item.Title}");
        }
    }
}
