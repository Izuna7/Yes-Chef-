Unity Version - 6000.3.2f1
Input System- Old + new(Both)

Controls-
Move - WASD
Choose which item to throw in trash - left click
Interact - Get in close range.

External Package dependency - Textmeshpro package for UI texts

About Project System-
Components-
  1-Chef
  2-Interactables(Table , Fridge, Stove, Trash Can , Counters)
  3-Ingredients(Carrot , Chopped Carrot , Cheese , Raw Meat , Cooked Meat)
  4-Game Manager(Highscore,Game timer,Game Over UI)

Store static data(High Score) - PlayerPrefs used

System Connectors-
Chef-
  •Chef (Handles Movement)
  •Chef Inventory (Handles Ingredient [Storing, adding ,removing])
  •Inventory UI (UI script- Responsible for hands UI)

Interactables-
  •Table (OnTriggerStay2D- checks if table full,accepts ingredient according to enum base check (ForTable))
  •Fridge (Interacting enables Fridge UI which lends ingredients with no limit)
  •Stove (Same process as table, accepts ingredient according to enum base check (ForStove) , accepts 2 meats)
  •Trash Can (Shows trash UI-lets you choose one of the 2 ingredients to throw in trash)
  •Counter (Shows required 3 ingredients (Received, Not Received), Post requirement process - shows a score)

Ingredients-
  •Carrot- Ingredient Process(Script)
  •Raw Meat-Ingredient Process(Script)
  •
  •
  •

Game Manager-
  •
  •
  •
