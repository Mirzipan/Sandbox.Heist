using Mirzipan.Clues;
using UnityEngine;

namespace Sandbox.Heist.ExampleB.Definitions
{
    [CreateAssetMenu(fileName = "Shop Offer", menuName = "Sandbox/Example B/Shop Offer Definition", order = 20)]
    public class ShopOfferDefinition : ADefinition
    {
        [SerializeField]
        private InventoryItem _item;
        [SerializeField]
        private InventoryItem[] _price;

        public InventoryItem Item => _item;
        public InventoryItem[] Price => _price;
    }
}