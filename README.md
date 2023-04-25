# Sandbox.Heist

Code examples for Mirzipan.Heist

## Packages
We are using the following packages:
* Mirzipan.Bibliotheca
* Mirzipan.Clues
* Mirzipan.Extensions
* Mirzipan.Heist
* Reflex

## Examples

All examples use some fictional types and game systems, in order to better illustrate possible usages, without having to take up too much space with non-essential code.

### Example A - Spawning a Creature
We are going to be spawning a creature, at a specific position and rotation.
For this example, we will re-use the same container for action and command.
We assume that we already have a `World` we can query and a `Spawner` that will be able to spawn a creature by its `Id`.

### Example B - Purchasing an Item via in-game Shop
We are going to be purchasing an item and adding it to our inventory.
For this example, we are diving actions and commands into separate containers.
We assume that we already have an `Inventory` that we can add things to and remove some as well.

### Example C - Apply and Resetting Audio Settings
We are going to be apply and resetting volume settings.
For this example, we will re-use the same container for action and command.
We assume that we already have an `AudioManager` that will be able to do the actual changes.
