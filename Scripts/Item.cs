using System;
using System.Collections.Generic;
using Godot;

public class Item
{
  public int Id { get; } // TODO: auto-generate?
  public string Title { get; }
  public string Description { get; }
  public Sprite Icon { get; }
  public Dictionary<string, int> Stats { get; }

  public Item(int id, string title, string description, Sprite icon, Dictionary<string, int> stats)
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
