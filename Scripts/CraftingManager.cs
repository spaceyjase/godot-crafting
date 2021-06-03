using Godot;
using System;

public class CraftingManager : Node
{
  private ItemDatabase itemDatabase;
  private CraftRecipeDatabase craftRecipeDatabase;

  private static CraftingManager Instance { get; set; }

  public override void _Ready()
  {
    if (Instance != null) return;
    
    itemDatabase = new ItemDatabase();
    craftRecipeDatabase = new CraftRecipeDatabase(itemDatabase);

    Instance = this;
  }

  public static Item GetItem(int id)
  {
    return Instance.itemDatabase.GetItem(id);
  }
  
  public static Item GetItem(string itemName)
  {
    return Instance.itemDatabase.GetItem(itemName);
  }
}