using System.Collections;
using UnityEngine;

namespace Root
{
    public class SpawnObjects : MonoBehaviour
    {
        public BaseUnit[] objects;

        private Level _level;
    
        private GameConfig _gameConfig;

        public void Construct(Level level, GameConfig gameConfig)
        {
            _level = level;

            _gameConfig = gameConfig;
        }

        public void Run()
        {
            StartCoroutine(SpawnRandomObject());
        }

        private IEnumerator SpawnRandomObject()
        {
            yield return new WaitForSeconds(1);

            while(_level.gameIsOver == false)
            {
                InstantiateRandomObject();

                yield return new WaitForSeconds(RandomRepeatrate());

            }
        }

        private float RandomRepeatrate()
        {
            float timeWait = Random.Range(0.5f, 3f);

            return timeWait;
        }


        private void InstantiateRandomObject()
        {
            int objectIndex = Random.Range(0, objects.Length);

            IUnit unit = Instantiate(objects[objectIndex], transform.position, objects[objectIndex].transform.rotation);

            unit.Construct(_gameConfig);

            unit.Push();
        }
    }
}
