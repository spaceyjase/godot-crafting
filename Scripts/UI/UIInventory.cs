using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using crafting.Scripts.Extensions;
using Godot.Collections;
using Array = Godot.Collections.Array;

public class UIInventory : Node2D
{
  [Export] private readonly PackedScene selectedItemScene;
  
  private readonly List<SlotPanel> panels = new List<SlotPanel>();
  private SelectedItem selectedItem;
  
  public override void _Ready()
  {
    base._Ready();
    foreach (var panel in this.GetChildren<SlotPanel>())
    {
      panels.Add(panel);
      panel.Connect(nameof(SlotPanel.InventoryClick), this,
        nameof(OnSlotPanel_Clicked));
      if (panel.IsCrafting)
      {
        panel.Connect(nameof(SlotPanel.ItemCrafted), this,
          nameof(OnSlotPanel_ItemCrafted));
      }
    }

    selectedItem = selectedItemScene.Instance<SelectedItem>();
    AddChild(selectedItem);
  }

  public void AddItem(Item item)
  {
    panels.FirstOrDefault(panel => panel.HasEmptySlot)?.AddNewItem(item);
  }

  private void OnSlotPanel_Clicked(SlotPanel panel, Slot slot)
  {
    var item = selectedItem.Item;
    selectedItem.Item = slot.Item;
    slot.Item = item;

    panel.CraftItem();
  }

  private void OnSlotPanel_ItemCrafted(Item newItem)
  {
    AddItem(newItem);
  }
}
