﻿using System;
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

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                controller.Reset();
                playerDeath.Die();
                audioInputManager.enabled = false;
                gameObject.SetActive(false);
            }
        }

        public void Spawn()
        {
            gameObject.transform.position = Vector3.zero; //Place at center
            gameObject.SetActive(true);
            audioInputManager.enabled = true;
        }

        private void OnCollisionWithAsteroid(Asteroid asteroid)
        {
            //Destroy asteroid
            asteroid.Collision(int.MaxValue); //Overkill with MaxValue to be sure

            // Kill the player
            controller.Reset();
            playerDeath.Die();
            audioInputManager.enabled = false;
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

