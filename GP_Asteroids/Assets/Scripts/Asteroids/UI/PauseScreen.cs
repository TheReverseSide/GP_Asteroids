using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

namespace Asteroids.UI
{
    
    public class PauseScreen : MonoBehaviour {

        public event Action EventComplete;
        
        [SerializeField]
        private AudioClip music;

        [SerializeField]
        private AudioClip startSFX;

        private bool isComplete;
        
        void OnEnable() {
            isComplete = false;

            AudioManager.Instance.PlayMusic( music );
        }
        
        void Update() {
            if( !isComplete ) {
                if( Input.GetKeyDown( KeyCode.Escape ) ) {
                    EscapePressed();
                }
            }
        }
        
        private void EscapePressed() {
            AudioManager.Instance.PlaySFX( startSFX );
            isComplete = true;
            if( EventComplete != null ) {
                EventComplete();
            }
        }
    }
}
