using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.UI
{
    
	public class UIManager : MonoBehaviour {

    [SerializeField]
		private TitleScreen titleScreen;

		[SerializeField]
		private GameScreen gameScreen;

		[SerializeField]
		private ScoreScreen scoreScreen;

		[SerializeField]
		private RectTransform transitionOverlay;

		[SerializeField]
		private float  transitionDuration = 0.5f;

		[SerializeField]
		private float  initialFadeDuration = 2.0f;

		private GameObject current;
		
		void Awake() {
			titleScreen.EventComplete += OnTitleScreenComplete;
			scoreScreen.EventComplete += OnScoreScreenComplete;
		}

		public void ShowTitleScreen( bool firstTime = false ) {
			if( firstTime ) {
				current = titleScreen.gameObject;
				titleScreen.gameObject.SetActive( true );
				FadeOutOverlay();
			} else {
				TransitionScreen( titleScreen.gameObject );
			}
		}

		public void ShowGameScreen() {
			TransitionScreen( gameScreen.gameObject );
		}

		public void ShowScoreScreen() {
			TransitionScreen( scoreScreen.gameObject );
		}

		public void UpdatePoints( int points ) {
			gameScreen.UpdatePoints( points );
		}

		public void UpdateLives( int lives ) {
			gameScreen.UpdateLives( lives );
		}

		public void ShowLevelStart() {
			gameScreen.ShowLevelStart();
		}

		private void FadeOutOverlay() {
			transitionOverlay.gameObject.SetActive( true );
			// LeanTween.alpha( transitionOverlay, 0.0f, initialFadeDuration )
			// 	.setEase( LeanTweenType.easeOutSine )
			// 	.setOnComplete( () => {
			// 		transitionOverlay.gameObject.SetActive( false );
			// 	} );
		}

		private void TransitionScreen( GameObject screen ) {
			transitionOverlay.gameObject.SetActive( true );

			// LeanTween.alpha( transitionOverlay, 1.0f, transitionDuration )
			// 	.setEase( LeanTweenType.easeOutSine )
			// 	.setOnComplete( () => {
			// 		screen.SetActive( true );
			//
			// 		if( current != null ) {
			// 			current.SetActive( false );
			// 		}
			// 		current = screen;
			//
			// 		LeanTween.alpha( transitionOverlay, 0.0f, transitionDuration )
			// 			.setEase( LeanTweenType.easeOutSine )
			// 			.setOnComplete( () => {
			// 				transitionOverlay.gameObject.SetActive( false );
			// 			} );
			//
			// 	} );
		}

		private void OnTitleScreenComplete() {
			ShowGameScreen();
		}

		private void OnGameScreenComplete() {
			ShowScoreScreen();
		}
		
		private void OnScoreScreenComplete() {
			ShowTitleScreen();
		}
	}
}
