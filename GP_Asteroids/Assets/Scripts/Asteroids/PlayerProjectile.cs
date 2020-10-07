using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class PlayerProjectile : MonoBehaviour {

        private CollisionWithAsteroid collision;

        private DestroyWeaponOffscreen destroyOffscreen;
        private ObjectPool weaponPool;
        private int damage;
        
        void Awake() {
            destroyOffscreen = GetComponent<DestroyWeaponOffscreen>();
            destroyOffscreen.EventDestroy += OnEventDestroy;

            collision = GetComponent<CollisionWithAsteroid>();
            collision.EventCollision += OnCollisionWithAsteroid;
        }
        
        public void Init( ObjectPool pool, int damageValue ) {
            weaponPool = pool;
            damage = damageValue;
        }
        
        private void OnEventDestroy() {
            if( weaponPool ) {
                weaponPool.ReleaseObject( gameObject );
            } else {
                Destroy( gameObject );
            }
        }
        
        private void OnCollisionWithAsteroid( Asteroid asteroid ) {
            asteroid.Collision( damage );
            OnEventDestroy();
        }
    }
    
}

