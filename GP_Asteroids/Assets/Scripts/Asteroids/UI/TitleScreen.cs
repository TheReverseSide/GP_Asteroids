using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

namespace Asteroids.UI
{
    
    public class TitleScreen : MonoBehaviour {

        public event Action EventComplete;

        [SerializeField]
        private Text startText;

        [SerializeField]
        private AudioClip music;

        [SerializeField]
        private AudioClip startSFX;

        private bool isComplete;
        
        void OnEnable() {
            isComplete = false;
            // FIXME AudioManager.Instance.PlayMusic( music );
        }
        
        void Update() {
            if( !isComplete ) {
                if( Input.GetKeyDown( KeyCode.Space ) ) {
                    StartPressed();
                }
            }
        }

        private void StartPressed() {
            isComplete = true;
            // FIXME AudioManager.Instance.PlaySFX( startSFX );

            
            if( EventComplete != null ) {
                EventComplete();
            }
        }
    }
}
