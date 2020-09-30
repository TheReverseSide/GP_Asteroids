using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    
    public class TransformOffscreen : MonoBehaviour {

        [SerializeField]
        private float padding = 0.1f;

        protected bool isOffscreen;
        protected Vector3 viewportPos;

        private float top;
        private float bottom;
        private float left;
        private float right;

        //===================================================
        // UNITY METHODS
        //===================================================

        /// <summary>
        /// Awake.
        /// </summary>
        public virtual void Awake() {
            top = 0.0f - padding;
            bottom = 1.0f + padding;
            left = 0.0f - padding;
            right = 1.0f + padding;
        }

        /// <summary>
        /// Update.
        /// </summary>
        public virtual void Update() { // convert transform position to viewport position.
            
            //NOTICE OVERRIDING NOTES
            // The method in the parent class has 'virtual' in it
            // The children receive 'override'
            // ANy child 'override' can override the virtual parent
            // Then is the base keyword some way to refer back to the original virtual method, but allows for the addition of other functionality
            
            
            viewportPos = Camera.main.WorldToViewportPoint( transform.position );
            isOffscreen = false;

            // check x
            if( viewportPos.x < left ) {
                viewportPos.x = right;
                isOffscreen = true;
            } else if( viewportPos.x > right ) {
                viewportPos.x = left;
                isOffscreen = true;
            }

            // check y
            if( viewportPos.y < top ) {
                viewportPos.y = bottom;
                isOffscreen = true;
            } else if( viewportPos.y > bottom ) {
                viewportPos.y = top;
                isOffscreen = true;
            }
        }
    }
}

