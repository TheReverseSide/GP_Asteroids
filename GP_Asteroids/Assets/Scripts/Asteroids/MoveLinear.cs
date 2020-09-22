using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    
    public class MoveLinear : MonoBehaviour {

        [SerializeField]
        private float speed = 1.0f;

        void Update() {
            transform.Translate( transform.up * speed * Time.deltaTime, Space.World );
        }
    }
}

