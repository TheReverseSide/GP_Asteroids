﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

namespace Asteroids.UI
{
    
    public class ScoreScreen : MonoBehaviour {

        public event Action EventComplete;

        [SerializeField]
        private Text scoreText;

        [SerializeField]
        private Text waveText;

        [SerializeField]
        private AudioClip music;

        [SerializeField]
        private AudioClip startSFX;

        private bool isComplete;

        void OnEnable() {
            isComplete = false;
            scoreText.text = GameManager.Instance.Points.ToString();
            waveText.text = GameManager.Instance.Level.ToString();

            AudioManager.Instance.PlaySFX( music );
            GameManager.Instance.ResetGame();
        }
        
        void Update() {
            if( !isComplete ) {
                if( Input.GetKeyDown( KeyCode.Space ) ) {
                    StartPressed();
                }else if (Input.GetKeyDown(KeyCode.Escape))
                {
                    QuitGame();
                }
            }
        }

        private void QuitGame()
        {
            Application.Quit();
        }
        
        private void StartPressed() {
            AudioManager.Instance.PlaySFX( startSFX );
            isComplete = true;
            if( EventComplete != null ) {
                EventComplete();
            }
        }
    }
}
