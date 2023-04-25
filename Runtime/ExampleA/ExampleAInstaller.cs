using Reflex.Core;
using UnityEngine;

namespace Sandbox.Heist.ExampleA
{
    public class ExampleAInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerDescriptor descriptor)
        {
            descriptor.AddInstance(new World());
            descriptor.AddInstance(new Spawner());
        }
    }
}