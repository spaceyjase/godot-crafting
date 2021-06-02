using Godot;
using System.Collections.Generic;
using System.Linq;

public class CraftRecipeDatabase
{
  private readonly ItemDatabase itemDatabase;

  private readonly List<CraftRecipe> recipes = new List<CraftRecipe>();

  public CraftRecipeDatabase(ItemDatabase itemDatabase)
  {
    this.itemDatabase = itemDatabase;
    BuildCraftRecipeDatabase();
  }

  public Item CheckRecipe(IEnumerable<int> recipe)
  {
    return (from craftRecipe in recipes
      where craftRecipe.RequiredItems.SequenceEqual(recipe)
      select itemDatabase.GetItem(craftRecipe.ItemToCraft)).FirstOrDefault();
  }

  private void BuildCraftRecipeDatabase()
  {
    foreach (var resource in ResourceGrabber.GetResources("res://Resources/Recipes/"))
    {
      if (!(resource is CraftRecipe recipe)) continue;

      recipes.Add(recipe);
      GD.Print($"Loaded recipe: {recipe}");
    }
  }
}