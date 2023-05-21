using Mirzipan.Heist;
using Reflex.Attributes;

namespace Sandbox.Heist.ExampleC.Commands
{
    public class ApplySoundSettings : IActionContainer, ICommandContainer
    {
        public class Action : IAction
        {
            public float MusicVolume;
            public float VFXVolume;
        }
        
        public class Handler : AActionHandler<Action>
        {
            protected override ValidationResult Validate(Action action, int clientId, ValidationOptions options)
            {
                return Pass();
            }

            protected override void Process(Action action, int clientId)
            {
                Enqueue(new Command
                {
                    MusicVolume = action.MusicVolume,
                    VFXVolume = action.VFXVolume,
                }, clientId, ExecuteOn.OneClient);
            }
        }

        public class Command : ICommand
        {
            public float MusicVolume;
            public float VFXVolume;
        }
        
        public class Receiver : ACommandReceiver<Command>
        {
            [Inject]
            private AudioManager _audioManager;
            
            protected override void Execute(Command command, ExecutionOptions options)
            {
                _audioManager.SetMusicVolume(command.MusicVolume);
                _audioManager.SetVFXVolume(command.VFXVolume);
            }
        }
    }
}