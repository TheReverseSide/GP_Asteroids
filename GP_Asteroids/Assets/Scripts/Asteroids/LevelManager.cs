using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
	public class LevelManager : MonoBehaviour {

		public event Action<int> EventPoints;
		public event Action EventPlayerDied;
		public event Action EventStarted;

		[SerializeField]
		private int level;
		public int Level {
			get { return level; }
			private set { level = value; }
		}

		[SerializeField]
		private AsteroidSpawner asteroidSpawner;

		[SerializeField]
		private Player player;

		[SerializeField]
		private float startLevelDelay = 3.0f;
		
		void Awake() {
			asteroidSpawner.EventAsteroidDestroyed += OnAsteroidDestroyed;
			player.EventDied += OnPlayerDied;
		}
		
		public void Reset() {
			level = 1;
			asteroidSpawner.Reset();
		}
		
		public void StartLevel() {
			asteroidSpawner.Spawn( level );
			if( EventStarted != null ) {
				EventStarted();
			}
		}
		
		public void SpawnPlayer() {
			player.Spawn();
		}
		
		private void OnAsteroidDestroyed( int points ) {
			// add to score.
			if( EventPoints != null ) {
				EventPoints( points );
			}

			// check if there are any asteroids remaining
			if( asteroidSpawner.AsteroidsRemaining == 0 ) {
				level += 1;
				Invoke( "StartLevel", startLevelDelay );
			}
		}

		private void OnPlayerDied() {
			if( EventPlayerDied != null ) {
				EventPlayerDied();
			}
		}
	}
}

