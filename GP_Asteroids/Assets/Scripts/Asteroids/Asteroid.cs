using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Asteroids
{
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(MoveLinear))]
    [RequireComponent(typeof(WrapScreen))]

    public class Asteroid : MonoBehaviour
    {

        public event Action<Asteroid, int, Vector3, GameObject[]> EventDie; //This plugs into AsteroidSpawner
        //Is this how it gets the content?
        public Animator anim;

        [SerializeField] private int pointsValue;
        [SerializeField] private GameObject[] asteroids;
        [SerializeField] private GameObject[] childAsteroids;

        [SerializeField] private AudioClip collisionSound;

        [SerializeField] private GameObject explosionParticlesPrefab;

        private Health health;
        private FlashColor flashColor;

        public virtual void Awake()
        {
            ChooseAsteroid();
            health = GetComponent<Health>();
            flashColor = GetComponentInChildren<FlashColor>();
        }

        [ContextMenu("Test StartMoving")]
        public void StartMoving(float direction = 0.0f)
        {
            if (direction == 0.0f)
            {
                //If there is no direction, choose a random direction
                direction = Mathf.Floor(UnityEngine.Random.Range(0.0f, 360.0f));
            }

            Vector3 rotation = new Vector3(0.0f, 0.0f, direction);
            transform.rotation = Quaternion.Euler(rotation);
        }

        [ContextMenu("Test Collision")]
        public void Collision(int damage = 1)
        {
            health.ReduceHealth(damage);

            //FIXME AudioManager.Instance.PlaySFX(collisionSound);

            if (health.Value > 0)
            {
                //flashColor.Flash();
            }
            else
            {
                anim.SetInteger("destroyed", 1);
                GameObject particles =
                    Instantiate(explosionParticlesPrefab, transform.position, Quaternion.identity) as GameObject;
                Destroy(particles, 2.5f);

                if (EventDie != null)
                {
                    EventDie(this, pointsValue, transform.position, childAsteroids);
                }

                Destroy(gameObject, .25f);
            }
        }

        //Chooses asteroid to be displayed, hides all others
        private void ChooseAsteroid()
        {
            for (int i = 0; i < asteroids.Length; i++)
            {
                GameObject asteroid = asteroids[i];
                asteroid.SetActive(false);
            }

            GameObject chosenAsteroid = asteroids[UnityEngine.Random.Range(0, asteroids.Length)];
            chosenAsteroid.SetActive(true);
        }
    }
}
