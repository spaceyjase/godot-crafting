using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using crafting.Scripts.Extensions;
using Godot.Collections;

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
      panel.Connect(nameof(SlotPanel.InventoryClick), this, nameof(OnSlotPanel_Clicked));
      panels.Add(panel);
      
    }

    selectedItem = selectedItemScene.Instance<SelectedItem>();
    AddChild(selectedItem);
  }

  public void AddItem(Item item)
  {
    panels.FirstOrDefault(panel => panel.HasEmptySlot)?.AddNewItem(item);
  }

  private void OnSlotPanel_Clicked(Slot slot)
  {
    if (slot.Item != null)
    {
      selectedItem.Item = slot.Item;
      slot.Item = null;
    }
    else if (selectedItem.Item != null)
    {
      slot.Item = selectedItem.Item;
      selectedItem.Item = null;
    }
  }
}
