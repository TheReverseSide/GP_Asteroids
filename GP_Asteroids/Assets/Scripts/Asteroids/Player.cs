using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    
    [RequireComponent( typeof( PlayerController ) )]
    [RequireComponent( typeof( WrapScreen ) )]
    [RequireComponent( typeof( FireWeapon ) )]
    [RequireComponent( typeof( CollisionWithAsteroid ) )]
    [RequireComponent( typeof( PlayerDeath ) )]
    // [RequireComponent( typeof( PlayerShield ) )]

    public class Player : MonoBehaviour
    {

        public event Action EventDied;
        public AudioInputManager audioInputManager;

        private PlayerController controller;
        private CollisionWithAsteroid collisionWithAsteroid;
        private PlayerDeath playerDeath;
        // private PlayerShield shield;

        void Awake()
        {
            controller = GetComponent<PlayerController>();

            collisionWithAsteroid = GetComponent<CollisionWithAsteroid>();
            collisionWithAsteroid.EventCollision += OnCollisionWithAsteroid; //What does EventCollision do?

            playerDeath = GetComponent<PlayerDeath>();
            playerDeath.EventDieComplete += OnDeathComplete; //What do?

            // shield = GetComponent<PlayerShield>();
        }

        public void Spawn()
        {
            gameObject.transform.position = Vector3.zero; //Place at center
            gameObject.SetActive(true);
            //shield.Show();
        }

        private void OnCollisionWithAsteroid(Asteroid asteroid)
        {
            //Destroy asteroid
            asteroid.Collision(int.MaxValue); //Overkill with MaxValue to be sure

            // Kill the player
            controller.Reset();
            playerDeath.Die();
            var children = new List<GameObject>();
            foreach (Transform child in transform) children.Add(child.gameObject);
            children.ForEach(child => child.gameObject.SetActive(false));
            audioInputManager.enabled = false;
                // SetActive(false);
            gameObject.SetActive(false);
        }

        private void OnDeathComplete()
        {
            if (EventDied != null) //if someone is listening...
            {
                EventDied();
            }
        }
    }
}

