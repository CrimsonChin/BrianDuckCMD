# BrianDuckCMD
BrianDuck is your regular, everyday, hardworking duck.  By day he sits eating bread and looking cute at the pond.  By night he's a carpenter, crafting fine furniture - all from memory.  Brian the Duck is a simple creature and he needs a little direction getting around his workshop.  Can you help him out?

## Commands
BrianDuck was inspired by Brainf-ck.  There are a few similarities in the syntax and their operations.  BUT Be warned they **aren't** the same.

Command | Description |
--- | --- |
> | Move one place right
< | Move one place left
+ | Drop breadcrumb 
- | Pickup breadcrumb
, | Pickup item from workbench
. | Put item on workbench
! | Build table

## Rules
1. It takes 4 Legs and 1 Top to build a table.
2. Workbenches are small.   They can hold all sorts of items but to build a table Brian needs room to work.  The workbench can only have the exact materials.
3. Brian can only carry one item at a time... he's a duck, he's not exactly strong.
4. When Brian takes an item from a workbench he picks the smallest items first.  They are stacked very carefully.  For example, assuming  a workbench has 1 Table, 3 Tops and 2 Legs:
  1.  Brian would first pick up and move the legs
  2. Then he'd pick up a Table Top
  3. Finally Brian would be able to move the table
5. Brian must put complete tables on the last work bench ready for collection.
6. Brian doesn't mind repetition.  He can handle loops now.  Its pretty simple, Brian works for bread.  If you leave bread at a work bench bryan will go back to get it so ++[>+<-] means leave two pieces of bread on a workbench as a snack.  Then start the loop "[".  He moves one space right ">" and drops another piece of bread "+-". He goes back to the orignal bench and eats the bread "-".  But there is still one piece of bread on that workbench so he continues the loop again until there is no more bread left.  (Note: see brainfuck for a better explanation)
