using System;
using Godot;

public class CraftRecipe : Resource
{
  [Export] public Item[] RequiredItems { get; set; }
  [Export] public Item ItemToCraft { get; set; } // the item produced in return for items

  public CraftRecipe() { }

  public CraftRecipe(Item[] requiredItems, Item itemToCraft)
  {
    this.RequiredItems = requiredItems;
    this.ItemToCraft = itemToCraft;
  }
}
