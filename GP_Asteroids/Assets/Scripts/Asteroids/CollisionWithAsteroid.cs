using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Asteroids
{
    public class CollisionWithAsteroid : MonoBehaviour {

        public event Action<Asteroid> EventCollision;

        void OnTriggerEnter2D( Collider2D collider ) {
            string tag = collider.tag.ToLower();

            // check collision against lasers and ship. Dispatch event if collision.
            if( tag == Tags.Asteroid ) {
                Asteroid asteroid = collider.gameObject.GetComponentInParent<Asteroid>();

                // disptach event.
                if( EventCollision != null ) {
                    EventCollision( asteroid );
                }
            }
        }
    }
}

