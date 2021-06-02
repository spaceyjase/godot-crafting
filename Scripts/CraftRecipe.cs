using System;
using Godot;

public class CraftRecipe : Resource
{
  [Export] public int[] RequiredItems { get; set; }
  [Export] public int ItemToCraft { get; set; } // the item produced in return for items

  public CraftRecipe() { }

  public CraftRecipe(int[] requiredItems, int itemToCraft)
  {
    this.RequiredItems = requiredItems;
    this.ItemToCraft = itemToCraft;
  }
}
