using UnityEngine;

namespace Root
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Level _level;
        
        [SerializeField] private SpawnObjects _spawnObjects;

        [SerializeField] private GameConfig _gameConfig;

        private void Awake()
        {
            InitComponentSystem();

            Run();
        }

        private void InitComponentSystem()
        {
            _level.Construct();

            _spawnObjects.Construct(_level, _gameConfig);
        }

        private void Run()
        {
            _spawnObjects.Run();
        }
    }
}