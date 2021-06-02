using System.Collections.Generic;
using Godot;

public class Item : Resource
{
  [Export] public int Id { get; set; } // TODO: auto-generate?
  [Export] public string Title { get; set;  }
  [Export] public string Description { get; set; }
  [Export] public Sprite Icon { get; set; }
  [Export] public Dictionary<string, int> Stats { get; set; }

  public Item() { } // required by godot

  public Item(int id = 0, string title = "", string description = "", Sprite icon = null, Dictionary<string, int> stats = null)
  {
    Id = id;
    Title = title;
    Description = description;
    Icon = icon;  // TODO: load from resources
    Stats = stats;
  }

  public Item(Item item)
  {
    Id = item.Id;
    Title = item.Title;
    Description = item.Description;
    Icon = item.Icon;
    Stats = item.Stats;
  }
}
