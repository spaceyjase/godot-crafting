using System.Collections.Generic;
using Godot;

public class Item : Resource
{
  [Export] public string Title { get; set;  }
  [Export] public string Description { get; set; }
  [Export] public Sprite Icon { get; set; }
  [Export] public Dictionary<string, int> Stats { get; set; }

  public Item() { } // required by godot

  public Item(string title = "", string description = "", Sprite icon = null, Dictionary<string, int> stats = null)
  {
    Title = title;
    Description = description;
    Icon = icon;
    Stats = stats;
  }

  public Item(Item item)
  {
    Title = item.Title;
    Description = item.Description;
    Icon = item.Icon;
    Stats = item.Stats;
  }
}
