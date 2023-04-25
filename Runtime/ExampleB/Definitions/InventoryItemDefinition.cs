using Mirzipan.Clues.Definition;
using Mirzipan.Clues.Meta;
using UnityEngine;

namespace Sandbox.Heist.ExampleB.Definitions
{
    [CreateAssetMenu(fileName = "Inventory Item", menuName = "Sandbox/Example B/Inventory Item Definition", order = 10)]
    [DefinitionType(typeof(VisualDefinition))]
    public class InventoryItemDefinition : VisualDefinition
    {
    }
}