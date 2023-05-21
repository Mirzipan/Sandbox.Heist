using Mirzipan.Bibliotheca.Identifiers;
using Mirzipan.Heist;
using Reflex.Attributes;

namespace Sandbox.Heist.ExampleB.Commands
{
    public class AddToInventory : ICommandContainer
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
            
            protected override void Execute(Command command, ExecutionOptions options)
            {
                _inventory.Add(command.Id, command.Amount);
                
                // TODO: notify someone?
            }
        }
    }
}