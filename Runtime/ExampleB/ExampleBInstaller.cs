using Mirzipan.Clues;
using Reflex.Core;
using UnityEngine;

namespace Sandbox.Heist.ExampleB
{
    public class ExampleBInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField]
        private string _pathToLoadFrom = string.Empty;

        public void InstallBindings(ContainerDescriptor descriptor)
        {
            var definitions = new Mirzipan.Clues.Definitions();
            definitions.LoadAtPath(_pathToLoadFrom);
            descriptor.AddInstance(definitions, definitions.GetType(), typeof(IDefinitions));
            
            descriptor.AddInstance(new Inventory());
        }
    }
}