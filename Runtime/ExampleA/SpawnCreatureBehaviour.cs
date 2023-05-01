using Mirzipan.Heist.Processors;
using Reflex.Attributes;
using UnityEngine;

namespace Sandbox.Heist.ExampleA
{
    public class SpawnCreatureBehaviour : MonoBehaviour
    {
        [SerializeField]
        private float _retryCooldown = 30f;
        [SerializeField]
        private string _creatureId;
        [SerializeField]
        private Transform _spawnPoint;
        
        [Inject]
        private IClientProcessor _processor;

        private float _lastTriedAt = 0f;
        
        private void OnCollisionEnter(Collision other)
        {
            // we only spawn thing when player enters
            if (!other.gameObject.CompareTag("player"))
            {
                return;
            }

            // we are on cooldown
            if (_lastTriedAt + _retryCooldown > Time.fixedTime)
            {
                return;
            }
            
            // we don't care if we succeed
            _lastTriedAt = Time.fixedTime;
            
            var action = new SpawnCreature.Action(_creatureId, _spawnPoint.position, _spawnPoint.rotation);
            if (!_processor.Validate(action).Success)
            {
                return;
            }

            _processor.Process(action);
        }
    }
}