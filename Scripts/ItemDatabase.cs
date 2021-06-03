using Godot;
using System.Collections.Generic;

public class ItemDatabase
{
  private readonly List<Item> items = new List<Item>();

  public ItemDatabase()
  {
    BuildItemDatabase();
  }

  public Item GetItem(string title)
  {
    return items.Find(item => item.Title == title);
  }
  
  public Item GetItem(Item item)
  {
    return items.Find(i => i == item);
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