using Mirzipan.Bibliotheca.Identifiers;
using UnityEngine;

namespace Sandbox.Heist.ExampleB
{
    public class Inventory
    {
        public bool HasSpace => true;

        public void Add(InventoryItem inventoryItem) => Add(inventoryItem, inventoryItem.Amount);

        public void Add(InventoryItem inventoryItem, int amount) => Add(inventoryItem.Id, amount);

        public void Add(CompositeId id, int amount)
        {
            Debug.Log($"[Inventory] Added {amount}x {id}.");
        }

        public void Remove(InventoryItem inventoryItem) => Remove(inventoryItem, inventoryItem.Amount);

        public void Remove(InventoryItem inventoryItem, int amount) => Remove(inventoryItem.Id, amount);

        public void Remove(CompositeId id, int amount)
        {
            Debug.Log($"[Inventory] Removed {amount}x {id}.");
        }

        public bool HasEnough(InventoryItem inventoryItem) => true;
    }
}