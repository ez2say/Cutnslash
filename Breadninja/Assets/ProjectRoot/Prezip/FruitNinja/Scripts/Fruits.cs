using UnityEngine;

namespace Root
{
    public class Fruits : BaseUnit
    {
        public Level gm;
        public GameObject slicedFruits;
        public GameObject fruitJuice;

        private float rotationForce = 200;

        public int scorePoints;

        private Rigidbody _rb;


        public void Start()
        {
            _rb = GetComponent<Rigidbody>();
            gm = FindObjectOfType<Level>();
        }


        void Update()
        {
            transform.Rotate(Vector2.right * Time.deltaTime * rotationForce);
        }


        private void InstantiateSlicedFruit()
        {
            GameObject instantiatedFruit = Instantiate(slicedFruits, transform.position, transform.rotation);
            GameObject instantiatedJuice = Instantiate(fruitJuice, new Vector3(transform.position.x, transform.position.y, 0), fruitJuice.transform.rotation);

            Rigidbody[] slicedRb = instantiatedFruit.transform.GetComponentsInChildren<Rigidbody>();

            foreach (Rigidbody srb in slicedRb)
            {
                srb.AddExplosionForce(130f, transform.position, 10);
                srb.velocity = _rb.velocity * 1.2f;
            }

            Destroy(instantiatedFruit, 5);
            Destroy(instantiatedJuice, 20);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Blade")
            {
                gm.UpdateTheScore(scorePoints);
                Destroy(gameObject);
                InstantiateSlicedFruit();
            }

            if (other.tag == "BottomTrigger")
            {
                gm.UpdateLives();
            }
        }

        public void Push()
        {
            throw new System.NotImplementedException();
        }
    }
}
