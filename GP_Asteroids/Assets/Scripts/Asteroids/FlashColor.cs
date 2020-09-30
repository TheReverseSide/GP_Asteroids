using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    
    public class FlashColor : MonoBehaviour {

        [SerializeField]
        private Color flashColor = Color.white;

        [SerializeField]
        [Range( 0.0f, 1.0f )]
        private float flashAmount = 1.0f;

        [SerializeField]
        private float duration = 0.5f;

        [SerializeField]
        private SpriteRenderer spriteRenderer;

        private Material material;
        
        void Awake() {
            if( spriteRenderer == null ) {
                spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            }
            material = spriteRenderer.material;
            material.color = flashColor;
        }
        
        [ContextMenu( "Test Flash" )]
        public void Flash() {
            ChangeColor( flashAmount );
            Invoke( "ResetColor", duration );
        }

        private void ResetColor() {
            ChangeColor( 0.0f );
        }
        
        private void ChangeColor( float value ) {
            material.SetFloat( "_FlashAmount", value );
        }
    }
}

