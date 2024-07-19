using UnityEngine;

namespace Root
{
    [CreateAssetMenu(fileName ="NewGameConfig", menuName = "Configs", order =11)]
    public class GameConfig : ScriptableObject
    {
        public float RightLimit => _rightLimit;

        public float LeftLimit => _leftLimit;

        [SerializeField] [Range(-10, 10)] private float _rightLimit;

        [SerializeField] [Range(-10, 10)] private float _leftLimit;

    }
}