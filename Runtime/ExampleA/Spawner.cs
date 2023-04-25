using UnityEngine;

namespace Sandbox.Heist.ExampleA
{
    public class Spawner
    {
        public int MaxCount => 10;
        public int SpawnedCount => 0;
    
        public void Spawn(string id, Vector3 position, Quaternion rotation)
        {
            Debug.Log($"Spawning {id} at {position}.");
        }
    }
}