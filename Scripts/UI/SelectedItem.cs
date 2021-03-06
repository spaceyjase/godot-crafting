using Godot;
using System;

public class SelectedItem : Position2D
{
  private Slot slot;

  public Item Item
  {
    get => slot.Item;
    set => slot.Item = value;
  }

  public override void _Ready()
  {
    base._Ready();

    slot = GetNode<Slot>(nameof(Slot));
  }

  public override void _Process(float delta)
  {
    base._Process(delta);

    Position = GetViewport().GetMousePosition();
  }
}
