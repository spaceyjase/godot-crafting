using Godot;
using System.Collections.Generic;
using System.Linq;
using crafting.Scripts.Extensions;

public class SlotPanel : Node
{
  [Export] private bool crafting;
  
  [Signal] public delegate void InventoryClick(SlotPanel panel, Slot slot);
  [Signal] public delegate void ItemCrafted(Item newItem);
  
  private readonly List<Slot> slots = new List<Slot>();

  public bool IsCrafting => crafting;

  public override void _Ready()
  {
    base._Ready();

    var grid = GetChild(1);
    slots.AddRange(grid.GetChildren<Slot>());
    foreach (var slot in slots)
    {
      slot.Connect(nameof(Slot.OnClick), this, nameof(OnSlot_Clicked));
    }
  }

  private void UpdateSlot(int slot, Item item)
  {
    slots[slot].Item = item;
  }
  
  public void CraftItem()
  {
    if (!crafting) return;
    
    var craftableItem = CraftingManager.HasRecipe(slots.Select(s => s.Item));
    if (craftableItem == null) return;
    
    GD.Print($"Crafted: {craftableItem.Title}");
    EmitSignal(nameof(ItemCrafted), new Item(craftableItem));
    EmptyAllSlots();
  }

  private void EmptyAllSlots()
  {
    slots.ForEach(slot => slot.Item = null);
  }

  public void AddNewItem(Item item)
  {
    UpdateSlot(slots.FindIndex(slot => slot.Item == null), item);
  }
  
  public void RemoveItem(Item item)
  {
    UpdateSlot(slots.FindIndex(slot => slot.Item == item), item);
  }

  public bool HasEmptySlot => slots.Any(slot => slot.Item == null);

  public void OnSlot_Clicked(Slot slot)
  {
    EmitSignal(nameof(InventoryClick), this, slot);
  }
}
