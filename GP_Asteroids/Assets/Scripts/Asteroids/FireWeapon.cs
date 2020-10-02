using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    [RequireComponent( typeof( ObjectPool ) )]

    public class FireWeapon : MonoBehaviour {

        [SerializeField]
        private float fireRate = 0.5f;

        [SerializeField]
        private Transform emitterTransform;

        [SerializeField]
        private AudioClip sound;

        [SerializeField]
        private float soundVolume = 0.4f;

        private ObjectPool weaponPool;
        private float nextFire = 1.25f;

        private float startTime = 0.0f;
        private float endTime = 0.0f; 
        
        void Awake() {
            weaponPool = GetComponent<ObjectPool>();
            weaponPool.Init();
            
            startTime = Time.time;
        }
        
        void Update() {
            // mouse button and Space.
            // if( Input.GetButton( "Fire1" ) )
            // {
            //     Fire();
            // } 
        }

        public void Fire()
        {
            endTime = Time.time;

            // checks against the firerate and fires laser from objectpool.
            if( Time.time > nextFire && (endTime - startTime) > 1f) {//Second part prevents that first erroneus firing
                Debug.Log("Firing");
                nextFire = Time.time + fireRate;

                // get game object from pool.
                GameObject weaponGO = weaponPool.GetGameObject();
                weaponGO.transform.position = emitterTransform.position;
                weaponGO.transform.rotation = gameObject.transform.rotation;

                // needed to pass the weapon pool in without having to "Find" it in the scene.
                Laser weapon = weaponGO.GetComponent<Laser>();
                weapon.Init(weaponPool, 1);

                AudioManager.Instance.PlaySFX(sound, soundVolume);
            }
            else {
                nextFire = Time.time;
                Debug.Log("Didnt fire");
            }
        }
    }
}
