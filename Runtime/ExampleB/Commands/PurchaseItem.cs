using Mirzipan.Bibliotheca.Identifiers;
using Mirzipan.Clues;
using Mirzipan.Heist;
using Reflex.Attributes;
using Sandbox.Heist.ExampleB.Definitions;

namespace Sandbox.Heist.ExampleB.Commands
{
    public class PurchaseItem : IActionContainer
    {
        // error codes
        public const uint CannotPurchaseZeroOrNegativeItems = 1000;
        public const uint ItemWithoutDefinition = 1010;
        public const uint InsufficientFunds = 1020;
        public const uint InventoryIsFull = 1030;
        
        public class Action : IAction
        {
            public CompositeId OfferId;
            public int Amount;

            public Action(CompositeId offerId, int amount)
            {
                OfferId = offerId;
                Amount = amount;
            }
        }

        public class Handler : AActionHandler<Action>
        {
            [Inject]
            private IDefinitions _definitions;
            
            [Inject]
            private Inventory _inventory;
            
            protected override ValidationResult Validate(Action action, int clientId, ValidationOptions options)
            {
                if (action.Amount <= 0)
                {
                    return Fail(CannotPurchaseZeroOrNegativeItems);
                }

                var definition = _definitions.Get<ShopOfferDefinition>(action.OfferId);
                if (definition == null)
                {
                    return Fail(ItemWithoutDefinition);
                }

                if (!_inventory.HasSpace)
                {
                    return Fail(InventoryIsFull);
                }

                for (int i = 0; i < definition.Price.Length; i++)
                {
                    var price = definition.Price[i] * action.Amount;
                    if (!_inventory.HasEnough(price))
                    {
                        return Fail(InsufficientFunds);
                    }
                }

                return Pass();
            }

            protected override void Process(Action action, int clientId)
            {
                var definition = _definitions.Get<ShopOfferDefinition>(action.OfferId);
                
                for (int i = 0; i < definition.Price.Length; i++)
                {
                    var price = definition.Price[i] * action.Amount;
                    Enqueue(new RemoveFromInventory.Command(price.Id, price.Amount), clientId, ExecuteOn.OneClientAndServer);
                }
                
                Enqueue(new AddToInventory.Command(definition.Item.Id, definition.Item.Amount * action.Amount),clientId, ExecuteOn.OneClientAndServer);
            }
        }
    }
}