using Godot;
using System;
using System.Collections.Generic;

public class CraftingManager : Node
{
  private ItemDatabase itemDatabase;
  private CraftRecipeDatabase craftRecipeDatabase;
  
  private UIInventory inventoryUi;

  private static CraftingManager Instance { get; set; }

  public override void _Ready()
  {
    if (Instance != null) return;
    
    Instance = this;
    
    itemDatabase = new ItemDatabase();
    craftRecipeDatabase = new CraftRecipeDatabase(itemDatabase);

    inventoryUi = GetNode<UIInventory>("UIInventory");
    
    // TODO: test
    var item = itemDatabase.GetItem("Diamond Axe");
    inventoryUi.AddItem(item);
    item = itemDatabase.GetItem("Diamond");
    inventoryUi.AddItem(item);
    inventoryUi.AddItem(item);
    item = itemDatabase.GetItem("Wood");
    inventoryUi.AddItem(item);
    inventoryUi.AddItem(item);
    inventoryUi.AddItem(item);
    inventoryUi.AddItem(item);
    inventoryUi.AddItem(item);
    item = itemDatabase.GetItem("Gold");
    inventoryUi.AddItem(item);
    inventoryUi.AddItem(item);
  }

  public static Item GetItem(string itemName)
  {
    return Instance.itemDatabase.GetItem(itemName);
  }

  public static Item HasRecipe(IEnumerable<Item> items)
  {
    return Instance.craftRecipeDatabase.CheckRecipe(items);
  }
}