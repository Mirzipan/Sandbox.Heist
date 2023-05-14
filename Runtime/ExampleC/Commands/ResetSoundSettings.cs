using Mirzipan.Heist.Commands;
using Reflex.Attributes;

namespace Sandbox.Heist.ExampleC.Commands
{
    public class ResetSoundSettings : IActionContainer, ICommandContainer
    {
        public class Action : IAction
        {
        }
        
        public class Handler : AActionHandler<Action>
        {
            protected override ValidationResult Validate(Action action, ValidationOptions options)
            {
                return Pass();
            }

            protected override void Process(Action action)
            {
                Enqueue(new Command());
            }
        }

        public class Command : ICommand
        {
        }
        
        public class Receiver : ACommandReceiver<Command>
        {
            [Inject]
            private AudioManager _audioManager;
            
            protected override void Execute(Command command)
            {
                _audioManager.ResetMusicVolume();
                _audioManager.ResetVFXVolume();
            }
        }
    }
}