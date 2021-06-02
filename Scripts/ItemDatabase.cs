using Godot;
using System.Collections.Generic;

public class ItemDatabase : Resource
{
    // TODO: alternate data structure (for lookup?)
    [Export]
    private List<Item> items = new List<Item>();

    public ItemDatabase()
    {
        BuildItemDatabase();
    }

    public Item GetItem(int id)
    {
        return items.Find(item => item.Id == id);
    }
 
    public Item GetItem(string title)
    {
        return items.Find(item => item.Title == title);
    }

    private void BuildItemDatabase()
    {
        // TODO: use resources
        items = new List<Item>()
        {
            new Item(1, "Diamond Axe", "An axe made of diamond.",
                null,
                new Dictionary<string, int> {
                    { "Power", 15 },
                    { "Defence", 7 }
                }),
            new Item(2, "Diamond Ore", "A shiny diamond.",
                null,
                new Dictionary<string, int> {
                    { "Value", 2500 }
                }),
            new Item(3, "Iron Axe", "An axe made of iron.",
                null,
                new Dictionary<string, int> {
                    { "Power", 8 },
                    { "Defence", 10 }
                })
        };
    }
}
