using Mirzipan.Heist.Processors;
using Reflex.Attributes;
using UnityEngine;

namespace Sandbox.Heist.ExampleB
{
    public class ProcessorTicker : MonoBehaviour
    {
        [Inject]
        private IProcessor _processor;

        private void FixedUpdate()
        {
            _processor?.Tick();
        }
    }
}