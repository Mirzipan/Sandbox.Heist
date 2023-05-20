using Mirzipan.Bibliotheca.Identifiers;
using Mirzipan.Heist;
using Reflex.Attributes;

namespace Sandbox.Heist.ExampleB.Commands
{
    public class RemoveFromInventory : ICommandContainer
    {
        public class Command : ICommand
        {
            public CompositeId Id;
            public int Amount;

            public Command(CompositeId id, int amount)
            {
                Id = id;
                Amount = amount;
            }
        }

        public class Receiver : ACommandReceiver<Command>
        {
            [Inject]
            private Inventory _inventory;
            
            protected override void Execute(Command command)
            {
                _inventory.Remove(command.Id, command.Amount);
            }
        }
    }
}