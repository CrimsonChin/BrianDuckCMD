# BrianDuckCMD
BrianDuck is your regular, everyday, hardworking duck.  By day he sits eating bread and looking cute at the pond.  By night he's a carpenter, crafting fine furniture - all from memory.  Brian the Duck is a simple creature and he needs a little direction getting around his workshop.  Can you help him out?

## Commands
BrianDuck was inspired by Brainf-ck.  There are a few similarities in the syntax and their operations.  BUT Be warned they **aren't** the same.

Command | Description |
--- | --- |
> | Move one place right
< | Move one place left
+ | Add a breadcrumb to your current locaiton for later
- | Remove a breadcrumb from your current location.  Yum!
, | Pickup item from workbench
. | Put item on workbench
! | Build table
[ | Start loop
] | End loop

## Rules
1. It takes 4 Legs and 1 Top to build a table.
2. Workbenches are small.   They can hold all sorts of items but to build a table Brian needs room to work.  The workbench can only have the exact materials.
3. Brian can only carry one item at a time... he's a duck, he's not exactly strong.
4. When Brian takes an item from a workbench he picks the smallest items first.  They are stacked very carefully.  For example, assuming  a workbench has 1 Table, 3 Tops and 2 Legs:
  1.  Brian would first pick up and move the legs
  2. Then he'd pick up a Table Top
  3. Finally Brian would be able to move the table
5. Brian must put complete tables on the last work bench ready for collection.
6. Brian doesn't mind repetition.  He can handle loops now.  Its pretty simple, Brian works for bread.  If you leave bread at a workbench Brian will go back to get it.  For example: ++[>+<-] means
  1. "+" Leave a pieces of bread on a workbench as a snack.
  2. "+" Leave a second piece of bread.
  3. "[" Then start the loop.  
  4.  ">" He moves one space right
  5. "+" And drops another piece of bread. 
  9. "<" He goes back to the orignal bench
  10. "-" and eats the bread. 
  11. "]" Time to go back to where we started But there is still one piece of bread on that workbench so he continues the loop again until there is no more bread left.  Bryan has moved all the bread one place to the right. (Note: see brainf-ck for a better explanation)
