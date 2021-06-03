using Godot;
using System;
using System.Collections.Generic;

public class Inventory : Node
{
  private List<Item> inventoryItems = new List<Item>();

  public void AddItem(string itemName)
  {
    var itemToAdd = CraftingManager.GetItem(itemName);
    if (itemToAdd != null)
    {
      inventoryItems.Add(itemToAdd);
    }
  }

  public Item CheckForItem(string itemName)
  {
    return inventoryItems.Find(item => item.Title == itemName);
  }

  public void RemoveItem(string itemName)
  {
    var itemToRemove = CheckForItem(itemName);
    if (itemToRemove != null)
    {
      inventoryItems.Remove(itemToRemove);
    }
  }
}
