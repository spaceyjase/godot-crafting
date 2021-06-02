using Godot;
using System;

public class CraftingManager : Node
{
    private ItemDatabase itemDatabase;
    private CraftRecipeDatabase craftRecipeDatabase;

    public override void _Ready()
    {
        itemDatabase = new ItemDatabase();
        craftRecipeDatabase = new CraftRecipeDatabase(itemDatabase);
    }
}
