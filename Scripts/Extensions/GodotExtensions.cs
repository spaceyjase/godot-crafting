﻿using System.Collections.Generic;
using Godot;

namespace crafting.Scripts.Extensions
{
  public static class GodotExtensions
  {
    public static IEnumerable<T> GetChildren<T>(this Node node)
    {
      foreach (var child in node.GetChildren())
      {
        if (!(child is T t)) continue;

        yield return t;
      }
    }
  }
}