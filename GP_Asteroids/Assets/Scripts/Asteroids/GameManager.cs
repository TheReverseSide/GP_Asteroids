using System.Collections;
using System.Collections.Generic;
using Asteroids.UI;
using UnityEngine;

namespace Asteroids
{
	public class GameManager : MonoBehaviour {

	    private static GameManager instance;
		public static GameManager Instance {
			get { return instance; }
		}

		[SerializeField]
		private UIManager uiManager;

		[SerializeField]
		private LevelManager levelManager;

		[SerializeField]
		private GameObject gameHolder;

		[SerializeField]
		private int startingLives = 1;

		public int Lives {
			get;
			private set;
		}

		public int Points {
			get;
			private set;
		}

		public int Level {
			get { return levelManager.Level; }
		}
		
		void Awake() {
			# region - Singleton
			if( instance == null ) {
				instance = this;
			} else if( instance != this ) {
				Destroy( gameObject );
			}
			DontDestroyOnLoad( gameObject );
			# endregion

			gameHolder.SetActive( false );

			levelManager.EventPoints += OnLevelPoints;
			levelManager.EventPlayerDied += OnLevelLives;
			levelManager.EventStarted += OnLevelStarted;
		}
		
		void Start() {
			uiManager.ShowTitleScreen( true );
		}
		
		public void StartGame() {
			gameHolder.SetActive( true );

			ResetGame();
			levelManager.StartLevel();
			levelManager.SpawnPlayer();
		}
		
		public void ResetGame() {
			Points = 0;
			Lives = startingLives;
			levelManager.Reset();

			uiManager.UpdateLives( Lives );
			uiManager.UpdatePoints( Points );
		}
		
		private void OnLevelPoints( int points ) {
			Points += points;
			uiManager.UpdatePoints( Points );
		}

		private void OnLevelLives() {
			Lives -= 1;
			if( Lives >= 0 ) {
				uiManager.UpdateLives( Lives );
				levelManager.SpawnPlayer();
			} else {
				uiManager.ShowScoreScreen();
			}
		}
			
		private void OnLevelStarted() {
			uiManager.ShowLevelStart();
		}
	}
}

