using Godot;
using System;

public class Slot : Control
{
  [Signal] public delegate void OnClick(Slot slot);
  
  private TextureRect itemImage;

  private Item item;

  public Item Item
  {
    get => item;
    set
    {
      item = value;
      if (item != null)
      {
        itemImage.Texture = item.Icon;
        itemImage.Modulate = Colors.White;
      }
      else
      {
        itemImage.Texture = null;
        itemImage.Modulate = new Color(1f, 1f, 1f, 0f);
      }
    }
  }

  public override void _Ready()
  {
    base._Ready();

    itemImage = GetNode<TextureRect>("Item");
  }

  public void OnSlot_GuiInput(InputEvent @event)
  {
    if (!(@event is InputEventMouseButton mouseButton)) return;

    if (mouseButton.Pressed && mouseButton.ButtonIndex == (int)ButtonList.Left)
    {
      EmitSignal(nameof(OnClick), this);
    }
  }
}
