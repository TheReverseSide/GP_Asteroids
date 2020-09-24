using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class PlayerDeath : MonoBehaviour {

        public event Action EventDieComplete; //This is talking to Player

        [SerializeField] private GameObject explosionPrefab;
        [SerializeField] private float duration = 1.0f;
        [SerializeField] private AudioClip deathSound;

        private GameObject explosionGO;
        
        public void Die()
        {
            // explosionGO = Instantiate(explosionPrefab, transform.position, Quaternion.identity) as GameObject;
            // I wonder why typecasting is necessary here

            // AudioManager.Instance.PlaySFX(deathSound);
            
            Invoke("DieComplete", duration); //Corout cause we are waiting for explosion to finish (?)
        }
        
        
        private void DieComplete()
        {
            // Destroy(explosionGO);

            if (EventDieComplete != null) //if someone is listening...
            {
                // Debug.Log("Someone is listening");
                EventDieComplete(); //When is something added to this?
            }
        }
    }
}

