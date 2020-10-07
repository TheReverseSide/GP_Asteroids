using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    [RequireComponent( typeof( ObjectPool ) )]

    public class FireWeapon : MonoBehaviour {

        [SerializeField]
        private float fireRate = 0.7f;

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
            if( Input.GetButton( "Fire1" ) )
            {
                FireChecker();
            } 
        }

        public void FireChecker()
        {
            endTime = Time.time;
            
            if (fireRate == 0 && (endTime - startTime) > 1f)
            {
                //Second part prevents that first erroneus firing
                Fire();
            }
            else if (Input.GetButton("Fire1") && Time.time > nextFire && fireRate > 0)
            {
                //I added "&& fireRate > 0", because if not, this will run if the user decides
                //to hold the button, as "GetButtonDown" only returns true the frame the button
                //is pressed, and while its hold, is false, so the "else" will run, and so will this.
                nextFire = Time.time + fireRate;
                Fire();
            }
        }

        public void Fire()
        {
            // get game object from pool.
            GameObject weaponGO = weaponPool.GetGameObject();
            weaponGO.transform.position = emitterTransform.position;
            weaponGO.transform.rotation = emitterTransform.rotation;

            // needed to pass the weapon pool in without having to "Find" it in the scene.
            PlayerProjectile weapon = weaponGO.GetComponent<PlayerProjectile>();
            weapon.Init(weaponPool, 1);

            AudioManager.Instance.PlaySFX(sound, soundVolume);
        }
    }
}