using Godot;
using System.Collections.Generic;
using System.Linq;
using crafting.Scripts.Extensions;

public class SlotPanel : Node
{
  [Signal] public delegate void InventoryClick(Slot slot);
  
  private readonly List<Slot> slots = new List<Slot>();

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

  public void UpdateSlot(int slot, Item item)
  {
    slots[slot].Item = item;
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
    EmitSignal(nameof(InventoryClick), slot);
  }
}
