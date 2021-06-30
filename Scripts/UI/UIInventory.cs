using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using crafting.Scripts.Extensions;
using Godot.Collections;

public class UIInventory : Node2D
{
  private readonly List<SlotPanel> panels = new List<SlotPanel>();
  
  public override void _Ready()
  {
    base._Ready();
    panels.AddRange(this.GetChildren<SlotPanel>());

    foreach (var panel in panels)
    {
      GD.Print(panel.Name);
    }
  }

  public void AddItem(Item item)
  {
    panels.FirstOrDefault(panel => panel.HasEmptySlot)?.AddNewItem(item);
  }
}
