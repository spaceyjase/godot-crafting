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
  private Position2D selectedItem;
  
  public override void _Ready()
  {
    base._Ready();
    panels.AddRange(this.GetChildren<SlotPanel>());
    selectedItem = selectedItemScene.Instance<Position2D>();
    AddChild(selectedItem);
  }

  public void AddItem(Item item)
  {
    panels.FirstOrDefault(panel => panel.HasEmptySlot)?.AddNewItem(item);
  }
}
