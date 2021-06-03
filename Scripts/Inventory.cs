using Godot;
using System;
using System.Collections.Generic;

public class Inventory : Node
{
  private List<Item> inventoryItems = new List<Item>();

  public void AddItem(int id)
  {
    var itemToAdd = CraftingManager.GetItem(id);
    if (itemToAdd != null)
    {
      inventoryItems.Add(itemToAdd);
    }
  }
  
  public void AddItem(string itemName)
  {
    var itemToAdd = CraftingManager.GetItem(itemName);
    if (itemToAdd != null)
    {
      inventoryItems.Add(itemToAdd);
    }
  }

  public Item CheckForItem(int id)
  {
    return inventoryItems.Find(item => item.Id == id);
  }
  
  public Item CheckForItem(string itemName)
  {
    return inventoryItems.Find(item => item.Title == itemName);
  }

  public void RemoveItem(int id)
  {
    var itemToRemove = CheckForItem(id);
    if (itemToRemove != null)
    {
      inventoryItems.Remove(itemToRemove);
    }
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
