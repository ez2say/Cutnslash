using UnityEngine;

namespace Root
{
    public class Bomb : BaseUnit
    {
        private float rotationForce = 200;
        public ParticleSystem explosionParticle;

        void Start()
        {
            transform.rotation = Random.rotation;
        }


        void Update()
        {
            transform.Rotate(Vector2.right * Time.deltaTime * rotationForce);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Blade")
            {
                Destroy(gameObject);
                Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
                FindObjectOfType<Level>().GameOver();
            }
        }
    }
}
