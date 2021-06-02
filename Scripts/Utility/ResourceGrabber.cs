using System.Collections.Generic;
using System.Linq;
using Godot;

public abstract class ResourceGrabber
{
  public static IEnumerable<Resource> GetResources(string folder)
  {
    var resources = new List<Resource>();
    var directory = new Directory();
    directory.Open(folder);
    directory.ListDirBegin();
    while (true)
    {
      var file = directory.GetNext();
      if (!string.IsNullOrEmpty(file))
      {
        if (file.BeginsWith(".") || file.EndsWith(".import"))
        {
          continue;
        }
        resources.Add(ResourceLoader.Load(folder + file));
      }
      else
      {
        break;
      }
    }

    return resources;
  }
}