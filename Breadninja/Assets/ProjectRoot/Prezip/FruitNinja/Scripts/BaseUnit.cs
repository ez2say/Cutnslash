using UnityEngine;

namespace Root
{
    [RequireComponent(typeof(Rigidbody))]
    public class BaseUnit : MonoBehaviour, IUnit
    {
        private Rigidbody _rigidbody;
        
        private float _leftLimit;
        
        private float _rightLimit;

        public void Construct(GameConfig gameConfig)
        {
            _leftLimit = gameConfig.LeftLimit;

            _rightLimit = gameConfig.RightLimit;
        }

        public void Push()
        {
            _rigidbody.AddForce(RandomVector() * RandomForce(), ForceMode.Impulse);
        }

        private float RandomForce()
        {
            float force = Random.Range(14f, 18f);
            return force;
        }

        private Vector2 RandomVector()
        {
            Vector2 moveDirection = new Vector2(Random.Range(_leftLimit, _rightLimit), 1).normalized;
            return moveDirection;
        }
    }
}