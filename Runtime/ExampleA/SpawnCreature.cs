using Mirzipan.Heist.Commands;
using Reflex.Attributes;
using UnityEngine;

namespace Sandbox.Heist.ExampleA
{
    public class SpawnCreature : IActionContainer, ICommandContainer
    {
        public class Action : IAction
        {
            public string Id;
            public Vector3 Position;
            public Quaternion Rotation;

            public Action(string id, Vector3 position, Quaternion rotation)
            {
                Id = id;
                Position = position;
                Rotation = rotation;
            }
        }
        
        public class Handler : AActionHandler<Action>
        {
            [Inject]
            private World _world;
            [Inject]
            private Spawner _spawner;
            
            protected override ValidationResult Validate(Action action, ValidationOptions options)
            {
                if (string.IsNullOrEmpty(action.Id))
                {
                    return Fail();
                }

                if (_spawner.SpawnedCount >= _spawner.MaxCount)
                {
                    return Fail();
                }

                float radius = 20f;
                if (!_world.HasEmptySpace(action.Position, radius))
                {
                    return Fail();
                }

                return Pass();
            }

            protected override void Process(Action action)
            {
                Enqueue(new Command(action.Id, action.Position, action.Rotation));
            }

            private static ValidationResult Fail()
            {
                return Fail(1);
            }
        }

        public class Command : ICommand
        {
            public string Id;
            public Vector3 Position;
            public Quaternion Rotation;

            public Command(string id, Vector3 position, Quaternion rotation)
            {
                Id = id;
                Position = position;
                Rotation = rotation;
            }
        }

        public class Receiver : ACommandReceiver<Command>
        {
            [Inject]
            private Spawner _spawner;
            
            protected override void Execute(Command command)
            {
                _spawner.Spawn(command.Id, command.Position, command.Rotation);
                
                // TODO: notify someone?
            }
        }
    }
}