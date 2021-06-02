using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public class CraftRecipeDatabase : Node
{
  [Export] private ItemDatabase itemDatabase;
  
  private List<CraftRecipe> recipes = new List<CraftRecipe>();

  public override void _Ready()
  {
    base._Ready();
    BuildCraftRecipeDatabase();
  }
  
  public Item CheckRecipe(int[] recipe)
  {
    return (from craftRecipe in recipes
            where craftRecipe.RequiredItems.SequenceEqual(recipe)
            select itemDatabase.GetItem(craftRecipe.ItemToCraft)).FirstOrDefault();
  }

  private void BuildCraftRecipeDatabase()
  {
    recipes = new List<CraftRecipe>()
    {
      new CraftRecipe(
        new int[]{
            2, 2, 0,
            0, 2, 0,  // diamond ore
            0, 2, 0
          },
        1), // returns diamond axe
      new CraftRecipe(
        new int[]{
            0, 3, 0,
            3, 3, 3,
            0, 3, 0
          },
        2),
      new CraftRecipe(
        new int[]{
            0, 2, 0,
            0, 2, 0,
            0, 1, 0
          },
        3),
    };
  }
}
