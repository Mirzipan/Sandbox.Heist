using System;
using Mirzipan.Bibliotheca.Identifiers;

namespace Sandbox.Heist.ExampleB
{
    [Serializable]
    public struct InventoryItem
    {
        public CompositeId Id;
        public int Amount;

        public InventoryItem(CompositeId id, int amount)
        {
            Id = id;
            Amount = amount;
        }

        public static InventoryItem operator *(InventoryItem item, int amount)
        {
            return new InventoryItem(item.Id, item.Amount * amount);
        }
    }
}