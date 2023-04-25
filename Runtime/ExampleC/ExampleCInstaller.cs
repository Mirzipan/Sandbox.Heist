using Reflex.Core;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sandbox.Heist.ExampleC
{
    public class ExampleCInstaller : MonoBehaviour, IInstaller
    {
        [FormerlySerializedAs("_musicManager")]
        [SerializeField]
        private AudioManager _audioManager;

        public void InstallBindings(ContainerDescriptor descriptor)
        {
            descriptor.AddInstance(_audioManager);
        }
    }
}