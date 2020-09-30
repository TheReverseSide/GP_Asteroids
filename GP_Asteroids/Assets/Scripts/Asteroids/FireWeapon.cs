using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    [RequireComponent( typeof( ObjectPool ) )]

    public class FireWeapon : MonoBehaviour {

        [SerializeField]
        private float fireRate = 0.25f;

        [SerializeField]
        private Transform emitterTransform;

        [SerializeField]
        private AudioClip sound;

        [SerializeField]
        private float soundVolume = 0.4f;

        private ObjectPool weaponPool;
        private float nextFire = 0.0f;
        
        void Awake() {
            weaponPool = GetComponent<ObjectPool>();
            weaponPool.Init();
        }
        
        void Update() {
            // mouse button and Space.
            if( Input.GetButton( "Fire1" ) ) {

                // checks against the firerate and fires laser from objectpool.
                if( Time.time > nextFire ) {
                    nextFire = Time.time + fireRate;

                    // get game object from pool.
                    GameObject weaponGO = weaponPool.GetGameObject();
                    weaponGO.transform.position = emitterTransform.position;
                    weaponGO.transform.rotation = gameObject.transform.rotation;

                    // needed to pass the weapon pool in without having to "Find" it in the scene.
                    Laser weapon = weaponGO.GetComponent<Laser>();
                    weapon.Init( weaponPool, 1 );

                    AudioManager.Instance.PlaySFX( sound, soundVolume );
                }
            } else {
                nextFire = Time.time;
            }
        }
    }
}
