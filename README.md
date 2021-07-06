# crafting
A simple little crafting demo in godot. The system uses a 'SlotPanel' for inventory and the crafting table. Each 'Slot' holds an 'Item' and when populating the crafting panel via drag and drop, new items are generated if they match (via sequence) a known 'Recipe'.

Items and Recipes are both resources. The 'CraftingManager' loads all resources into an in-memory database.

![Screen](/Assets/Screenshots/crafting.png)
